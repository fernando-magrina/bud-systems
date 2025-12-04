import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';

//TODO - move to models
export interface Region {
  id: string;
  iso2code: string;
  value: string;
}

export interface CountryResponse {
  id: string;
  iso2Code: string;
  name: string;
  region: Region;
  capitalCity: string;
  longitude: string;
  latitude: string;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.html',
  styleUrls: ['./app.css'],
  standalone: false
})

export class App {
  ngOnInit() {
      throw new Error('Method not implemented.');
  }
  code = '';
  country?: CountryResponse;
  error = '';
  loading = false;

  constructor(private http: HttpClient) { }

  search() {
    this.error = '';
    this.country = undefined;

    const trimmed = this.code.trim();
    const api = 'http://localhost:5066';

    if (!/^[A-Za-z]{2,3}$/.test(trimmed)) {
      this.error = 'ISO code must be 2 or 3 letters.';
      return;
    }

    this.loading = true;

    this.http.get<CountryResponse>(`${api}/api/country/${trimmed}`).subscribe({
      next: result => {
        this.country = result;
        this.loading = false;
      },
      error: err => {
        this.loading = false;
        this.error = err.error?.error ?? 'Something went wrong';
      }
    });
  }
}
