import {
  ChangeDetectionStrategy,
  Component,
  inject,
  OnInit,
} from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  FormBuilder,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { Store } from '@ngrx/store';

import { RegisterActions } from '../../../../state/register/action.types';

import { Router } from '@angular/router';
import {
  selectRegisterError,
  selectRegisterLoading,
} from '../../../../state/register/register.selectors';
import {
  PasswordErrors,
  passwordValidator,
} from '../../../../../core/validators/password-validator';
import { HlmInputDirective } from '@spartan-ng/helm/input';
import { HlmCardImports } from '@spartan-ng/helm/card';
import { NgIcon } from '@ng-icons/core';
import { HlmButtonDirective } from '@spartan-ng/helm/button';
import { HlmLabelDirective } from '@spartan-ng/helm/label';

export type PasswordCriteria = {
  key: string;
  label: string;
};

@Component({
  changeDetection: ChangeDetectionStrategy.OnPush,
  selector: 'app-register-page',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    HlmInputDirective,
    HlmCardImports,
    NgIcon,
    HlmButtonDirective,
    HlmLabelDirective,
  ],
  templateUrl: './register-page.html',
  styles: [
    `
      section {
        background: url('/images/login-background-full.webp');
        background-size: cover;
      }
    `,
  ],
})
export class RegisterPage implements OnInit {
  private readonly router = inject(Router);
  private readonly store = inject(Store);
  private readonly fb = inject(FormBuilder);
  protected readonly loading$ = this.store.select(selectRegisterLoading);
  protected readonly error$ = this.store.select(selectRegisterError);

  protected registerForm!: FormGroup;

  protected passwordErrors: PasswordErrors | null = {
    hasUpperCase: true,
    hasLowerCase: true,
    hasNumber: true,
    hasSpecialChar: true,
    isValidLength: true,
  };

  protected passwordCriteria: PasswordCriteria[] = [
    { key: 'isValidLength', label: 'Mínimo de 6 caracteres' },
    { key: 'hasUpperCase', label: 'Pelo menos uma letra maiúscula' },
    { key: 'hasLowerCase', label: 'Pelo menos uma letra minúscula' },
    { key: 'hasNumber', label: 'Pelo menos um número' },
    { key: 'hasSpecialChar', label: 'Pelo menos um caractere especial' },
  ];

  protected isPasswordVisible = false;

  ngOnInit() {
    this.registerForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, passwordValidator()]],
    });

    this.registerForm.get('password')?.valueChanges.subscribe(() => {
      this.passwordErrors = this.registerForm.get('password')
        ?.errors as PasswordErrors;
    });

    this.registerForm.statusChanges.subscribe(() => {
      this.isLoginButtonDisabled = this.registerForm.invalid;
    });
  }

  protected isLoginButtonDisabled = true;

  protected registerButtonClick() {
    if (this.registerForm.valid) {
      this.store.dispatch(
        RegisterActions.createAccountButtonClicked({
          email: this.registerForm.controls['email'].value,
          password: this.registerForm.controls['password'].value,
        }),
      );
    }
  }

  protected get email() {
    return this.registerForm.get('email');
  }

  protected get password() {
    return this.registerForm.get('password');
  }

  protected onBlur(controlName: string) {
    const control = this.registerForm.get(controlName);
    if (control) {
      control.markAsTouched();
      control.updateValueAndValidity();
    }
  }

  protected accessExistingAccountButtonClick() {
    this.router.navigate(['/login']).then();
  }

  protected togglePasswordVisibilityButtonClick() {
    this.isPasswordVisible = !this.isPasswordVisible;
  }
}
