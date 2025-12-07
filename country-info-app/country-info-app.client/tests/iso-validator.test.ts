export { };

function expectIso(cond: boolean, msg: string) {
  if (!cond) throw new Error(msg);
}

function isIsoValid(code: string): boolean {
  return /^[A-Za-z]{2,3}$/.test(code);
}

expectIso(isIsoValid("BR"), "BR should be valid");
expectIso(isIsoValid("USA"), "USA should be valid");
expectIso(!isIsoValid("1R"), "Numbers must be invalid");
expectIso(!isIsoValid("B"), "One-letter codes should be invalid");
expectIso(!isIsoValid("BRZL"), "4-letter codes should be invalid");

console.log("ISO validator tests --> PASS");
