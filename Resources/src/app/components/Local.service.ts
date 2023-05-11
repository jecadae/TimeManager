import { Injectable } from '@angular/core';
import { AppComponent } from '../app.component';
import { HttpHeaders, HttpClient, HttpResponse } from '@angular/common/http'
import { Router } from '@angular/router';

@Injectable({
    providedIn: 'root'
  })

export class LocalService {

  constructor() { }

  public saveData(key: string, value: string) {
    localStorage.setItem(key, value);
  }

  public getData(key: string) {
    return localStorage.getItem(key)
  }
  public removeData(key: string) {
    localStorage.removeItem(key);
  }

  public clearData() {
    localStorage.clear();
  }
}

