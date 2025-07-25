import { Component, inject, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  FormBuilder,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';

import { Store } from '@ngrx/store';

import { Router } from '@angular/router';
import {
  selectLoginError,
  selectLoginLoading,
} from '../../../../state/login/login.selectors';
import { LoginActions } from '../../../../state/login/action.types';
import { HlmCardImports } from '@spartan-ng/helm/card';
import { HlmLabelDirective } from '@spartan-ng/helm/label';
import { HlmInputDirective } from '@spartan-ng/helm/input';
import { NgIcon } from '@ng-icons/core';

@Component({
  selector: 'app-login-page',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    HlmCardImports,
    HlmLabelDirective,
    HlmInputDirective,
    NgIcon,
  ],
  templateUrl: './login-page.html',
  styles: [
    `
      section {
        background: url('/images/login-background-full.webp');
        background-size: cover;
      }
    `,
  ],
})
export class LoginPage implements OnInit {
  private readonly store = inject(Store);
  private readonly fb = inject(FormBuilder);
  private readonly router = inject(Router);
  protected readonly loading$ = this.store.select(selectLoginLoading);
  protected readonly error$ = this.store.select(selectLoginError);

  protected loginForm!: FormGroup;

  ngOnInit() {
    this.loginForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required],
    });

    this.loginForm.statusChanges.subscribe(() => {
      this.isLoginButtonDisabled = this.loginForm.invalid;
    });
  }

  protected isLoginButtonDisabled = true;

  protected loginButtonClick() {
    if (this.loginForm.valid) {
      this.store.dispatch(
        LoginActions.loginButtonClicked({
          username: this.loginForm.controls['email'].value,
          password: this.loginForm.controls['password'].value,
        }),
      );
    }
  }

  protected get email() {
    return this.loginForm.get('email');
  }

  protected get password() {
    return this.loginForm.get('password');
  }

  protected onBlur(controlName: string) {
    const control = this.loginForm.get(controlName);
    if (control) {
      control.markAsTouched();
      control.updateValueAndValidity();
    }
  }

  protected createAccountButtonClick() {
    this.router.navigate(['/register']).then();
  }
}
