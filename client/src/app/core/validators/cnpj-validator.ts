import { AbstractControl, ValidationErrors, ValidatorFn } from '@angular/forms';
import onlyNumbers from "../utils/only-numbers";

export function cnpjValidator(): ValidatorFn {
  return (control: AbstractControl): ValidationErrors | null => {
    const value = control.value;
    if (!value) return null;

    const cnpj = onlyNumbers(value);

    // Verifica se o tamanho do CNPJ é válido.
    if (cnpj.length !== 14) return { invalidCompanyCnpj: true };

    // CNPJs inválidos conhecidos.
    const invalidCnpjs = [
      '00000000000000',
      '11111111111111',
      '22222222222222',
      '33333333333333',
      '44444444444444',
      '55555555555555',
      '66666666666666',
      '77777777777777',
      '88888888888888',
      '99999999999999',
    ];
    if (invalidCnpjs.includes(cnpj)) return { invalidCompanyCnpj: true };

    let sum = 0;
    const weights = [5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2]; // Pesos para cálculo.
    for (let i = 0; i < 12; i++) {
      sum += parseInt(cnpj.charAt(i)) * weights[i];
    }
    let remainder = sum % 11;
    const digit1 = remainder < 2 ? 0 : 11 - remainder;

    if (digit1 !== parseInt(cnpj.charAt(12))) {
      return { invalidCompanyCnpj: true };
    }

    // Cálculo do segundo dígito verificador.
    sum = 0;
    weights.unshift(6); // Adiciona o peso 6 na posição inicial para o segundo dígito.
    for (let i = 0; i < 13; i++) {
      sum += parseInt(cnpj.charAt(i)) * weights[i];
    }
    remainder = sum % 11;
    const digit2 = remainder < 2 ? 0 : 11 - remainder;

    if (digit2 !== parseInt(cnpj.charAt(13))) {
      return { invalidCompanyCnpj: true }; // Segundo dígito verificador inválido.
    }

    return null;
  };
}
