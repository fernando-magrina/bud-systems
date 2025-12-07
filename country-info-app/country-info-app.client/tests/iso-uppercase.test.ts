export { };

function toIsoUpper(value: string): string {
  return value.trim().toUpperCase();
}

function expectUpper(condition: boolean, message: string) {
  if (!condition) throw new Error(message);
}

expectUpper(toIsoUpper("br") === "BR", "lowercase should become uppercase");
expectUpper(toIsoUpper("Br") === "BR", "mixed case should become uppercase");
expectUpper(toIsoUpper(" us ") === "US", "spaces should be trimmed and uppercase");
expectUpper(toIsoUpper("123") === "123", "numbers should remain unchanged");
expectUpper(toIsoUpper("") === "", "empty string should return empty");

console.log("ISO uppercase tests --> PASS");
