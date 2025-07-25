import { AbstractControl, ValidationErrors, ValidatorFn } from '@angular/forms';

export function nameValidator(): ValidatorFn {
  return (control: AbstractControl): ValidationErrors | null => {
    const value = control.value;
    if (!value) return null;

    if (value.length < 2 || value.length > 255) {
      return { invalidName: true };
    }

    const validNamePattern = /^[A-Za-zÀ-ÖØ-öø-ÿ\s]+$/;
    if (!validNamePattern.test(value)) {
      return { invalidName: true };
    }

    return null;
  };
}
