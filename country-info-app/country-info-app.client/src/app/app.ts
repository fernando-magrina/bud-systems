import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CountryResponse } from './models/country-response.model';
import { environment } from './environments/environment';

@Component({
  selector: 'app-root',
  templateUrl: './app.html',
  styleUrls: ['./app.css'],
  standalone: false
})

export class App {
  code = '';
  country?: CountryResponse;
  error = '';
  loading = false;

  constructor(private http: HttpClient) { }

  search() {
    this.error = '';
    this.country = undefined;

    const trimmed = this.code.trim();
    const api = environment.apiUrl;

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
