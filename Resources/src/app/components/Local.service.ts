import { Injectable } from '@angular/core';
import { AppComponent } from '../app.component';
import { HttpHeaders, HttpClient, HttpResponse } from '@angular/common/http'
import { Router } from '@angular/router';
import { NG_VALUE_ACCESSOR } from '@angular/forms';

@Injectable({
    providedIn: 'root'
  })

export class LocalService {

  constructor() { }

  public saveData(email: string, token: string) {
    localStorage.setItem('email',email);
    localStorage.setItem('token',token);
  }

  public getEmail() {
    return localStorage.getItem('email')

  }

  public getToken(){
    return localStorage.getItem('token')

  }

  public removeData(key: string) {
    localStorage.removeItem(key);
  }

  public clearData() {
    localStorage.clear();
  }
}


