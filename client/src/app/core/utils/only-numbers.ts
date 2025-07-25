export default function onlyNumbers(inputString: string) {
  return inputString.replace(/\D/g, '');
}
