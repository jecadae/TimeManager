import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient, HttpResponse } from '@angular/common/http'
import { map, observeOn } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';
import { LocalService } from '../Local.service';

@Injectable({
  providedIn: 'root'
})



export class AuthService {
  constructor(
    private http: HttpClient,
    private router: Router,
    private storage: LocalService
    ) {}

  token: any;
  user: any;

  regUser(user: any) {
    let headers = new HttpHeaders;
    headers.append('Content-Type', 'application/json');
    headers.append('accept', 'value')
    return this.http.post(
      'https://localhost:44393/Auth/register',
      user,
      {observe: 'response', headers: headers}).subscribe({
        next:()=>{        this.router.navigate(['/login']);},
        error:()=>{        alert('Ошибка!')},
      });
  }

  logUser(user: any) {
    //return new Observable<boolean>((observer)=>{
    //   this.http.post<any>(this.)
    // })

    let headers = new HttpHeaders;
    headers.append('Content-Type', 'application/json');
    headers.append('accept', 'text/plain')
    return this.http.post(
      'https://localhost:44393/Auth/login',
      user,
      {observe: 'response', headers: headers}).subscribe({
        next:(response: HttpResponse<any>)=>{        
          this.storage.saveData(response.body.email, response.body.token);
          this.router.navigate(['/home-page']);
          },
        error:(response: HttpResponse<any>)=>{alert(response.body)},
      
      });
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
