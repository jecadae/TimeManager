import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http'
import { map } from 'rxjs/operators';
import { User } from './user';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private url = "http://localhost:44393/Auth/login";
  constructor(private http: HttpClient) {}

  token: any;
  user: any;

  regUser(user: any) {
    let headers = new HttpHeaders;
    headers.append('Content-Type', 'application/json');
    return this.http.post(
      '',
      user,
      {headers: headers}).pipe(map((response:any) => response.json()));
  }

  logUser(user: any) {
    let headers = new HttpHeaders;
    headers.append('Content-Type', 'application/json');
    return this.http.post<User>(
      this.url, JSON.stringify(user));
  }
  
  passwordReset(user: any) {
    let headers = new HttpHeaders;
    headers.append('Content-Type', 'application/json');
    return this.http.post(
      'МИРОСЛАВ, ДАЙ ССЫЛКУ!',
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
