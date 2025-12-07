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

class MockHttp {
  get(url: string) {
    return {
      subscribe: (next: any) => next({ test: true, url })
    };
  }
}

const service = new CountryService(new MockHttp() as any);

let result: any = null;

service.getCountry("BR").subscribe(res => result = res);

expect(result !== null, "Result should not be null");
expect(result.test === true, "Result should include { test: true }");
expect(result.url.endsWith("/api/country/BR"), "URL must be correct");

console.log("CountryService tests --> PASS");
