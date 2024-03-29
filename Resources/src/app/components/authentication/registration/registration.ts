import { Component, OnInit, NgModule } from '@angular/core';
import { CheckDataService } from '../check-data.service';
import { AuthService } from '../auth.service';
import { Router } from '@angular/router'
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.html',
  styleUrls: ['./registration.css']
})

export class RegistrationComponent implements OnInit {

  surname: string = '';
  name: string = '';
  patronymic: string = '';
  email: string = '';
  password: string = '';
  passwordRepead: string = '';

  surnameErrTitle: string = ''
  nameErrTitle: string = ''
  patronymicErrTitle: string = ''
  emailErrTitle: string = ''
  passwordErrTitle: string = ''
  passwordRepeadErrTitle: string = ''

  constructor(
    private checkRegistration: CheckDataService,
    private http: HttpClient,
    private router: Router,
    private auth: AuthService
  ) { }

  ngOnInit() {
  }

  chekPasswordLabel(event: any) {

  }

  userRegistrationClick() {
    const user = {
      LastName: this.surname,
      FirstName: this.name,
      Patronymic: this.patronymic,
      email: this.email,
      password: this.password,
      passwordRepead: this.passwordRepead

    }

    this.surnameErrTitle = ''
    this.nameErrTitle = ''
    this.patronymicErrTitle = ''
    this.emailErrTitle = ''
    this.passwordErrTitle = ''
    this.passwordRepeadErrTitle = ''

    let errCount = 0;

    if (!this.checkRegistration.checkNullSurname(user.LastName)) {
      this.surnameErrTitle = 'Фамилия не введена';
      errCount++;
    }
    if (!this.checkRegistration.checkNullName(user.FirstName)) {
      this.nameErrTitle = 'Имя не введено'
      errCount++;
    }
    if (!this.checkRegistration.checkNullPatronymic(user.Patronymic)) {
      this.patronymicErrTitle = 'Отчество не введено'
      errCount++;
    }

    if (!this.checkRegistration.checkNullEmail(user.email)) {
      this.emailErrTitle = 'Email не введен'
      errCount++;
    } else if (!this.checkRegistration.checkEmail(user.email)) {
      this.emailErrTitle = 'Некорректный email'
      errCount++;
    }

    if (!this.checkRegistration.checkNullPassword(user.password)) {
      this.passwordErrTitle = 'Пароль не введен'
      errCount++;
    } else if (!this.checkRegistration.checkPasswordStrength(user.password)) {
      this.passwordErrTitle = 'Необходимы строчные и заглавные латинские буквы, цифры. Длина 8 символов или более'
      errCount++;
    }

    if (!this.checkRegistration.checkPasswordRepead(user.password, user.passwordRepead)) {
      this.passwordRepeadErrTitle = 'Пароли не совпадают'
      errCount++
    }

    if (errCount > 0) return false;
    
  
    this.auth.regUser(user);
    return
  }
}


