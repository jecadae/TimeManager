import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient, HttpResponse } from '@angular/common/http'
import { Router } from '@angular/router';



@Injectable({
  providedIn: 'root'
})

export class MyPlanService {
  constructor(
    private http: HttpClient,
    private router: Router,
    ) {}

  token: any;
  user: any;

  getPlansThisUsers(token: string, email: string) {
    let headers = new HttpHeaders;
    headers.append('Content-Type', 'application/json');
    headers.append('accept', '*/*');
    headers.append('Authorization:','Bearer'+token);
    return this.http.post<any>(
      'https://localhost:44393/Plan/GetPlansThisUser',
      {observe: 'response'}).subscribe({
        next:(response: HttpResponse<any>)=>{
            return response.body;
        },
        error:()=>{ },
      });
  }
}