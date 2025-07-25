import { inject, Injectable } from '@angular/core';
import {
  HttpEvent,
  HttpHandler,
  HttpInterceptor,
  HttpRequest,
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { switchMap, take } from 'rxjs/operators';
import { AuthService } from '../../data/services/auth.service';

@Injectable()
export class JwtInterceptor implements HttpInterceptor {
  authService = inject(AuthService);

  intercept(
    request: HttpRequest<unknown>,
    next: HttpHandler,
  ): Observable<HttpEvent<unknown>> {
    return this.authService.isLoggedIn$.pipe(
      take(1),
      switchMap((isLoggedIn) => {
        if (isLoggedIn) {
          request = request.clone({
            setHeaders: {
              Authorization: `Bearer ${localStorage.getItem('accessToken')}`,
            },
          });
        }
        return next.handle(request);
      }),
    );
  }
}
