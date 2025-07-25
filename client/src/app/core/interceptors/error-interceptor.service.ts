import { inject, Injectable } from '@angular/core';
import {
  HttpErrorResponse,
  HttpEvent,
  HttpHandler,
  HttpInterceptor,
  HttpRequest,
} from '@angular/common/http';
import { catchError, Observable, throwError } from 'rxjs';
import { switchMap } from 'rxjs/operators';
import { AuthService } from '../../data/services/auth.service';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
  authService = inject(AuthService);

  intercept(
    request: HttpRequest<unknown>,
    next: HttpHandler,
  ): Observable<HttpEvent<unknown>> {
    return next.handle(request).pipe(
      catchError((error) => {
        if (error instanceof HttpErrorResponse && error.status === 401) {
          if (!request.url.includes('/login')) {
            return this.handle401Error(request, next);
          }

          return throwError(() => error);
        }

        return throwError(() => error);
      }),
    );
  }

  private addToken(request: HttpRequest<unknown>): HttpRequest<unknown> {
    const accessToken = localStorage.getItem('accessToken');
    if (accessToken) {
      return request.clone({
        setHeaders: {
          Authorization: `Bearer ${accessToken}`,
        },
      });
    }

    return request;
  }

  private handle401Error(
    request: HttpRequest<unknown>,
    next: HttpHandler,
  ): Observable<HttpEvent<unknown>> {
    return this.authService.rotateAccessToken().pipe(
      switchMap(() => {
        return next.handle(this.addToken(request));
      }),
      catchError((error) => {
        this.authService.logout();
        return throwError(() => error);
      }),
    );
  }
}
