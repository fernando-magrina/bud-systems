export { };

function expectUpper(cond: boolean, msg: string) {
  if (!cond) throw new Error(msg);
}

function toIsoUpper(code: string): string {
  return code.trim().toUpperCase();
}

expectUpper(toIsoUpper("br") === "BR", "Lowercase should uppercase");
expectUpper(toIsoUpper(" Us ") === "US", "String should trim and uppercase");
expectUpper(toIsoUpper("") === "", "Empty should stay empty");
expectUpper(toIsoUpper("abc") === "ABC", "3-letter lowercase should uppercase");

console.log("ISO uppercase tests --> PASS");
