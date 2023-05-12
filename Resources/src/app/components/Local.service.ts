import { Injectable } from '@angular/core';
import { AppComponent } from '../app.component';
import { HttpHeaders, HttpClient, HttpResponse } from '@angular/common/http'
import { Router } from '@angular/router';

@Injectable({
    providedIn: 'root'
  })

export class LocalService {

  constructor() { }

  public saveData(email: string, token: string) {
    localStorage.setItem(email, token);
  }

  public getData(email: string) {
    return localStorage.getItem(email)

  }
  public removeData(key: string) {
    localStorage.removeItem(key);
  }

  public clearData() {
    localStorage.clear();
  }
}

