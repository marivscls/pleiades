import { capitalize } from './capitalize';

export default function validateString(
  value: string,
  valueName: string,
  minLength: number,
  maxLength: number,
): any {
  if (value === null || value.trim().length === 0) {
    return new Error(`${capitalize(valueName)} cannot be null or empty.`);
  }

  if (value.length < minLength) {
    return new Error(
      `${capitalize(valueName)} is required with a minimum of ${minLength} characters.`,
    );
  }

  if (value.length > maxLength) {
    return new Error(
      `${capitalize(valueName)} is required with a maximum of ${maxLength} characters.`,
    );
  }
}
