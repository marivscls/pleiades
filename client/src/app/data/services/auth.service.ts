import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { BehaviorSubject, Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import {
  LoginRequest,
  LoginResponse,
} from '../../application/dto/auth/login.dto';
import {
  RegisterRequest,
  RegisterResponse,
} from '../../application/dto/auth/register.dto';
import { AccessTokenDto } from '../../application/dto/auth/access-token.dto';

@Injectable({ providedIn: 'root' })
export class AuthService {
  private readonly API_URL = 'https://localhost:5100/api';
  private readonly httpClient = inject(HttpClient);
  private readonly router = inject(Router);
  private refreshTokenInProgress = false;

  // isLoggedIn
  private isLoggedInSubject = new BehaviorSubject<boolean>(
    this.hasValidToken(),
  );

  get isLoggedIn$(): Observable<boolean> {
    return this.isLoggedInSubject.asObservable();
  }

  /**
   * Logs in a user with the provided credentials.
   * @param credentials The login request containing the user's email and password.
   * @returns An observable that emits the login response or an error.
   */
  login(credentials: LoginRequest): Observable<LoginResponse | Error> {
    return this.httpClient
      .post<LoginResponse>(`${this.API_URL}/AdminAuth/login`, credentials, {
        withCredentials: true,
      })
      .pipe(
        map((response) => {
          localStorage.setItem('accessToken', response.accessToken);
          this.isLoggedInSubject.next(true);
          return response;
        }),
        catchError((error) => {
          let errorMessage =
            'Erro desconhecido. Por favor entre em contato o nosso suporte.';
          if (error.status === 401) {
            errorMessage = 'E-mail ou senha inválidos. Tente novamente.';
          }
          return of(new Error(errorMessage));
        }),
      );
  }

  /**
   * Logs out the current user by clearing the local storage and navigating to the login page.
   */
  logout(): void {
    localStorage.clear();
    this.isLoggedInSubject.next(false);
    this.router.navigate(['/login']).then();
  }

  /**
   * Updates isLoggedIn Observable
   */
  updateLoginStatus(status: boolean) {
    this.isLoggedInSubject.next(status);
  }

  /**
   * Registers a new user with the provided data.
   * @param req User data to be registered.
   * @returns An observable that emits the registration response or an error.
   */
  register(req: RegisterRequest): Observable<RegisterResponse | Error> {
    return this.httpClient
      .post<RegisterResponse>(`${this.API_URL}/AdminAuth/register`, req, {
        withCredentials: true,
      })
      .pipe(
        map((response: RegisterResponse) => {
          console.log('Registro bem-sucedido:', response);
          return response;
        }),
        catchError((error) => {
          console.error('Erro na chamada HTTP de registro:', error);
          let errorMessage =
            'Erro desconhecido. Por favor entre em contato o nosso suporte.';
          if (error.status === 400) {
            errorMessage =
              'Dados inválidos. Verifique os campos e tente novamente.';
          }
          return of(new Error(errorMessage));
        }),
      );
  }

  /**
   * Rotates the access token by requesting a new one from the server.
   * @returns An observable that emits true if the token was successfully rotated, otherwise false.
   */
  rotateAccessToken(): Observable<boolean> {
    if (!this.refreshTokenInProgress) {
      this.refreshTokenInProgress = true;
      return this.httpClient
        .post<{
          accessToken: string;
        }>(
          `${this.API_URL}/AdminAuth/rotate-access-token`,
          {},
          { withCredentials: true },
        )
        .pipe(
          tap((response) => {
            localStorage.setItem('accessToken', response.accessToken);
            this.updateLoginStatus(true);
          }),
          map(() => true),
          catchError(() => of(false)),
          tap(() => {
            this.refreshTokenInProgress = false;
            if (localStorage.getItem('accessToken')) {
              this.router.navigate(['/']).then();
            }
          }),
        );
    }
    return of(false);
  }

  /**
   * Decodes a JWT token to extract its payload.
   * @param token The JWT token to decode.
   * @returns The decoded payload or null if the token is invalid.
   */
  decodeToken(token: string): AccessTokenDto | null {
    try {
      return JSON.parse(atob(token.split('.')[1]));
    } catch {
      return null;
    }
  }

  /**
   * Checks if the user has a valid token.
   * @returns True if the user has a valid token, otherwise false.
   */
  hasValidToken(): boolean {
    const token = localStorage.getItem('accessToken');
    if (!token) {
      return false;
    }

    const decodedToken = this.decodeToken(token);
    if (!decodedToken) {
      return false;
    }

    return decodedToken && decodedToken.exp * 1000 > Date.now();
  }
}
