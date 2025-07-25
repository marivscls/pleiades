import { Actions, createEffect, ofType } from '@ngrx/effects';
import { inject, Injectable } from '@angular/core';
import { loginButtonClicked, loginError, loginSuccess } from './login.actions';
import { catchError, exhaustMap, map, tap } from 'rxjs/operators';
import { of } from 'rxjs';
import { Router } from '@angular/router';
import { LoginResponse } from '../../../application/dto/auth/login.dto';
import { AuthService } from '../../../data/services/auth.service';

@Injectable()
export class LoginEffects {
  private readonly router = inject(Router);
  private readonly actions$ = inject(Actions);
  private readonly authService = inject(AuthService);

  loginButtonClicked$ = createEffect(() => {
    return this.actions$.pipe(
      ofType(loginButtonClicked),
      exhaustMap((action) =>
        this.authService.login(action).pipe(
          map((response: LoginResponse | Error) => {
            if (response instanceof Error) {
              throw response;
            }

            return loginSuccess({ accessToken: response.accessToken });
          }),
          catchError((error: Error) =>
            of(loginError({ errorMessage: error.message })),
          ),
        ),
      ),
    );
  });
  loginSuccess$ = createEffect(
    () => {
      return this.actions$.pipe(
        ofType(loginSuccess),
        tap((action) => {
          localStorage.setItem('accessToken', action.accessToken);
          this.authService.updateLoginStatus(true);
          this.router.navigate(['/']).then();
        }),
      );
    },
    { dispatch: false },
  );
}
