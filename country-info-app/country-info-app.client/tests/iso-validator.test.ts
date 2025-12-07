export { };

function isIsoValid(code: string): boolean {
  return /^[A-Za-z]{2,3}$/.test(code);
}

function expectIso(condition: boolean, message: string) {
  if (!condition) throw new Error(message);
}

expectIso(isIsoValid("BR") === true, "BR should be valid");
expectIso(isIsoValid("USA") === true, "USA should be valid");
expectIso(isIsoValid("bR") === true, "mixed case should be valid");
expectIso(isIsoValid("B") === false, "single letter is invalid");
expectIso(isIsoValid("123") === false, "numbers are invalid");
expectIso(isIsoValid("BRZL") === false, "more than 3 letters is invalid");

console.log("ISO validator tests --> PASS");
