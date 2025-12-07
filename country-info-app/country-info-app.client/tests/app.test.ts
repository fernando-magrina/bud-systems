export { };

function expect(cond: boolean, msg: string) {
  if (!cond) throw new Error(msg);
}

function toUpperIso(v: string) { return v.trim().toUpperCase(); }
function isValidIso(v: string) { return /^[A-Za-z]{2,3}$/.test(v); }
function buildUrl(code: string) { return `http://localhost:5066/api/country/${code}`; }

console.log("Running App tests...");

// integration-style checks
const cleaned = toUpperIso(" br ");
expect(cleaned === "BR", "Uppercase trim flow");

expect(isValidIso(cleaned), "Integrated ISO validator workflow");

expect(
  buildUrl("BR") === "http://localhost:5066/api/country/BR",
  "URL builder integration"
);

console.log("App tests --> PASS");
