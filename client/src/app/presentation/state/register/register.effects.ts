import { Actions, createEffect, ofType } from '@ngrx/effects';
import { inject, Injectable } from '@angular/core';
import { catchError, delay, exhaustMap, map, tap } from 'rxjs/operators';
import { of } from 'rxjs';
import { Router } from '@angular/router';
import { RegisterActions } from './action.types';
import { AuthService } from '../../../data/services/auth.service';
import { RegisterResponse } from '../../../application/dto/auth/register.dto';

@Injectable()
export class RegisterEffects {
  private readonly actions$ = inject(Actions);
  private readonly router = inject(Router);
  private readonly authService = inject(AuthService);

  createAccountButtonClicked$ = createEffect(() => {
    return this.actions$.pipe(
      ofType(RegisterActions.createAccountButtonClicked),
      exhaustMap((action) =>
        this.authService.register(action).pipe(
          delay(700),
          map((response: RegisterResponse | Error) => {
            if (response instanceof Error) {
              throw response;
            }

            return RegisterActions.registerSuccess({
              accessToken: response.accessToken,
            });
          }),
          catchError((error: Error) =>
            of(
              RegisterActions.registerError({
                errorMessage: error.message,
              }),
            ),
          ),
        ),
      ),
    );
  });

  registerSuccess$ = createEffect(
    () => {
      return this.actions$.pipe(
        ofType(RegisterActions.registerSuccess),
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
