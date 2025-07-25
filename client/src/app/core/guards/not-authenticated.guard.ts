import { inject } from '@angular/core';
import {
  ActivatedRouteSnapshot,
  CanActivateFn,
  Router,
  RouterStateSnapshot,
  UrlTree,
} from '@angular/router';
import { map, Observable } from 'rxjs';
import { AuthService } from '../../data/services/auth.service';

/*
 * Prevents not-authenticated users to navigate to protected pages
 */
export const notAuthenticatedGuard: CanActivateFn = (
  route: ActivatedRouteSnapshot,
  state: RouterStateSnapshot,
): Observable<boolean | UrlTree> => {
  const authService = inject(AuthService);
  const router = inject(Router);

  return authService.isLoggedIn$.pipe(
    map((isLoggedIn: boolean) => {
      console.log('isLoggedIn:', isLoggedIn);
      if (!isLoggedIn) {
        console.log('User is not logged in, redirecting to /login');
        return router.createUrlTree(['/login']);
      }

      const accessToken = localStorage.getItem('accessToken');
      console.log('accessToken:', accessToken);
      if (!accessToken) {
        console.log('No access token found, redirecting to /login');
        return router.createUrlTree(['/login']);
      }

      const decodedToken = authService.decodeToken(accessToken);
      console.log('decodedToken:', decodedToken);
      if (!decodedToken) {
        console.log('Token decoding failed, redirecting to /login');
        return router.createUrlTree(['/login']);
      }

      return true;
    }),
  );
};
