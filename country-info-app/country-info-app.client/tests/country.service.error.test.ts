export { };

function expect(cond: boolean, msg: string) {
  if (!cond) throw new Error(msg);
}

class CountryService {
  private http: any;
  constructor(http: any) { this.http = http; }

  getCountry(code: string) {
    const url = `http://localhost:5066/api/country/${code}`;
    return this.http.get(url);
  }
}

class MockHttpError {
  get(url: string) {
    return {
      subscribe: (_: any, error: any) => error({ message: "API error", url })
    };
  }
}

const service = new CountryService(new MockHttpError() as any);

let errorResult: any = null;

service.getCountry("BR").subscribe(
  () => { },
  err => errorResult = err
);

expect(errorResult !== null, "Error should be captured");
expect(errorResult.message === "API error", "Error message must match");
expect(errorResult.url.endsWith("/api/country/BR"), "URL must match");

console.log("CountryService ERROR tests --> PASS");
