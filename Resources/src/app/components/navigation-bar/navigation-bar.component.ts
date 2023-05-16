import { NgModule, OnInit } from '@angular/core';
import { Component } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { map, shareReplay } from 'rxjs/operators';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { LocalService } from '../Local.service';
import { Token } from '@angular/compiler';
import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { AuthService } from '../authentication/auth.service';
import { Router } from '@angular/router';
import { AppPlanDto } from 'src/app/AppPlanDto';

const material = [
  MatFormFieldModule, 
  MatInputModule
]

@Injectable()

@Component({
  selector: 'app-navigation-bar',
  templateUrl: './navigation-bar.component.html',
  styleUrls: ['./navigation-bar.component.css']
})

export class NavigationBarComponent implements OnInit{

  isHandset$: Observable<boolean> = this.breakpointObserver.observe(Breakpoints.Handset)
    .pipe(
      map(result => result.matches),
      shareReplay()
    );

  constructor(
    private breakpointObserver: BreakpointObserver,
    private localStorage: LocalService,
    private http: HttpClient,
    private router: Router,) {}

  ngOnInit(): void {
    this.getPlanUser();
  }

  getPlanUser() {
    let token =this.localStorage.getToken;
    let headers = new HttpHeaders;
    headers.append('Content-Type', 'application/json');
    headers.append('accept', 'value')
    headers.append('Authorization', 'Bearer'+token)
    let email = this.localStorage.getEmail();
    return this.http.get<Array<AppPlanDto>>(
      'https://localhost:44393/Plan/GetPlansThisUser/'+email,
      {observe: 'response', headers:headers}).subscribe({
        next:()=>{        alert([AppPlanDto]);},
        error:()=>{        alert('Ошибка!')},
      });
  }
  
  
}
