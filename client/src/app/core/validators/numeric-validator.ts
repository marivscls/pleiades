import { AbstractControl, ValidationErrors, ValidatorFn } from '@angular/forms';

/**
 * Validador que verifica se o valor contém apenas números.
 * @returns Um objeto de erro se o valor for inválido, ou null se for válido.
 */
export function numericValidator(): ValidatorFn {
  return (control: AbstractControl): ValidationErrors | null => {
    const value = control.value;
    if (!value) return null;

    const validNumberPattern = /^[0-9]+$/;
    if (!validNumberPattern.test(value)) {
      return { invalidNumber: true };
    }

    return null;
  };
}
