import { NgModule } from '@angular/core';
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

export class NavigationBarComponent {

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



  getPlanUser() {
    let headers = new HttpHeaders;

    headers.append('Content-Type', 'application/json');
    headers.append('accept', 'value')
    headers.append('Authorization', 'Bearer'+this.localStorage.getToken)
    return this.http.get(
      'https://localhost:44393/Plan/GetPlanThisUser/'+this.localStorage.getEmail,
      {observe: 'response', headers:headers}).subscribe({
        next:()=>{        alert(['NICE']);},
        error:()=>{        alert('Ошибка!')},
      });
  }
  
  
}
