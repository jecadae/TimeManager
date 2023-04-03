import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../auth.service';
import { Router } from '@angular/router'
import {CheckDataService} from '../check-data.service';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm!: FormGroup

  constructor(
    private router: Router,
    private auth: AuthService,
    private checkLogin: CheckDataService,
    private http: HttpClient,
  ) { }

  
  email: string = '';
  password: string = '';

  errLabel: string = ''
  emailErrLabel: string = ''

  userLoginClick() {
    const user = {
      email: this.email,
      password: this.password
    }
    let errCount = 0;

    this.errLabel = '';
    this.emailErrLabel = '';

    if (!this.checkLogin.checkNullEmail(user.email)) {
      this.emailErrLabel = 'Email не введен'
      errCount++;
     } else if (!this.checkLogin.checkEmail(user.email)) {
      this.emailErrLabel = 'Некорректный email'
      errCount++;
     }
    if (!this.checkLogin.checkNullPassword(user.password)) {
      this.errLabel = 'Пароль не введен'
      errCount++; }

    if (errCount > 0) return false

    this.auth.logUser(user).subscribe(data => {
      if (!data.succes) {
        this.errLabel = 'Неверный email или пароль'
      }
      else 
      this.router.navigate(['/home-page']);
      this.auth.platformUser(data.token, data.user)
    })
    return
}


  ngOnInit(): void {

    this.http.post('http://localhost:5010/Auth/login', {headers: this.email}).pipe(map((response:any) => response.json()));
    //this.loginForm = new FormGroup(controls: {
    //    'email': new FormControl(formState: '', ValidatorOrOpts: [Validators.required, Validators.email]),
    //    'password': new FormControl(formState: '', ValidatorOrOpts: [Validators.required, Validators.pattern(pattern: )])
    //})
  }
}