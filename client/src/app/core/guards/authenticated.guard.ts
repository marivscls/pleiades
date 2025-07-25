import { map } from 'rxjs/operators';
import { CanActivateFn, Router } from '@angular/router';
import { inject } from '@angular/core';
import { AuthService } from '../../data/services/auth.service';

/*
 *Prevents authenticated users to navigate to auth pages
 */
export const authenticatedGuard: CanActivateFn = () => {
  const authService = inject(AuthService);
  const router = inject(Router);

  return authService.isLoggedIn$.pipe(
    map((isLoggedIn) => {
      if (isLoggedIn) {
        return router.createUrlTree(['/']);
      }

      return true;
    }),
  );
};
