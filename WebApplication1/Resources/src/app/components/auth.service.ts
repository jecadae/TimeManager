import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http'
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient) {}

  regUser(user: any) {
    let headers = new HttpHeaders;
    headers.append('Content-Type', 'application/json');
    return this.http.post(
      'МИРОСЛАВ, ДАЙ ССЫЛКУ!',
      user,
      {headers: headers}).pipe(map((response:any) => response.json()));
  }

  logUser(user: any) {
    let headers = new HttpHeaders;
    headers.append('Content-Type', 'application/json');
    return this.http.post(
      'МИРОСЛАВ, ДАЙ ССЫЛКУ!',
      user,
      {headers: headers}).pipe(map((response:any) => response.json()));
  }
}
