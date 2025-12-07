import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CountryResponse } from '../models/country-response.model';
import { environment } from '../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CountryService {

  private apiUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getCountry(code: string): Observable<CountryResponse> {
    return this.http.get<CountryResponse>(`${this.apiUrl}/api/country/${code}`);
  }
}
