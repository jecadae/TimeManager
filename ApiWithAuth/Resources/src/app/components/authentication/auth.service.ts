import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http'
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})

export class AuthService {
  constructor(private http: HttpClient) {}

  token: any;
  user: any;

  regUser(user: any) {
    let headers = new HttpHeaders;
    headers.append('Content-Type', 'application/json');
    headers.append('accept', 'value')
    return this.http.post(
      'https://localhost:44393/Auth/register',
      user,
      {headers: headers}).pipe(map((response:any) => response.json()));
  }

  logUser(user: any) {
    let headers = new HttpHeaders;
    headers.append('Content-Type', 'application/json');
    return this.http.post(
      'https://localhost:44393/Auth/login',
      user,
      {headers: headers}).pipe(map((response:any) => response.json()));
  }
  
  passwordReset(user: any) {
    let headers = new HttpHeaders;
    headers.append('Content-Type', 'application/json');
    return this.http.post(
      '',
      user,
      {headers: headers}).pipe(map((response:any) => response.json()));
  }

  platformUser(token: any, user: any) {
    localStorage.setItem('token', token);
    localStorage.setItem('user', JSON.stringify(user));
    this.token = token;
    this.user = user;
  }
}
