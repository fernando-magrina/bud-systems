import { Component } from '@angular/core';
import { CountryService } from './services/country.service';
import { CountryResponse } from './models/country-response.model';

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

  constructor(private countryService: CountryService) { }

  search() {
    this.error = '';
    this.country = undefined;

    const trimmed = this.code.trim();

    if (!/^[A-Za-z]{2,3}$/.test(trimmed)) {
      this.error = 'ISO code must be 2 or 3 letters.';
      return;
    }

    this.loading = true;

    this.countryService.getCountry(trimmed).subscribe({
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
