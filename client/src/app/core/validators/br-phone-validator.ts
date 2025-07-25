import { AbstractControl, ValidationErrors, ValidatorFn } from '@angular/forms';
import onlyNumbers from '../utils/only-numbers';

export function phoneValidator(): ValidatorFn {
  return (control: AbstractControl): ValidationErrors | null => {
    const value = control.value;
    if (!value) return null;

    const phone = onlyNumbers(value);

    if (phone.length !== 10 && phone.length !== 11)
      return { invalidPhone: true };

    // Se for telefone fixo, deve ter 10 dígitos e não começar com 9
    if (phone.length === 10 && !/^(\d{2})[2-5](\d{7})$/.test(phone))
      return { invalidPhone: true };

    // Se for telefone celular, deve ter 11 dígitos e o terceiro dígito deve ser 9
    if (phone.length === 11 && !/^(\d{2})9(\d{8})$/.test(phone))
      return { invalidPhone: true };

    return null;
  };
}
