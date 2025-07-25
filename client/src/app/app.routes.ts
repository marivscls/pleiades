import { Routes } from '@angular/router';
import { authenticatedGuard } from './core/guards/authenticated.guard';
import { notAuthenticatedGuard } from './core/guards/not-authenticated.guard';
import { LoginPage } from './presentation/ui/pages/auth/login/login-page';
import { RegisterPage } from './presentation/ui/pages/auth/register/register-page';
import { DashboardPage } from './presentation/ui/pages/dashboard/dashboard-page';

export const routes: Routes = [
  {
    path: 'login',
    component: LoginPage,
    canActivate: [authenticatedGuard],
  },
  {
    path: 'register',
    component: RegisterPage,
    canActivate: [authenticatedGuard],
  },
  {
    path: '',
    component: DashboardPage,
    canActivate: [notAuthenticatedGuard],
  },
];
