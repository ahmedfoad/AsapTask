import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GoogleMapsService {

  private readonly endpoint = 'https://maps.googleapis.com/maps/api/geocode/json';

  constructor(private http: HttpClient) { }

  getCountries(): Observable<string[]> {
    const params = { address: 'country', key: 'AIzaSyBmU-WVlIptFbTRyvOoy1dc4UwwIo3NjD8' }; // Replace with your API key
    return this.http.get<any>(this.endpoint, { params }).pipe(
      map(response => response.results.map(result => result.formatted_address))
    );
  }
}
