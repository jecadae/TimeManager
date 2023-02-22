import { Component, OnInit,  NgModule } from '@angular/core';
import {CheckRegistrationService} from './check-registration.service';
import {RegService} from './reg.service';
import { Router } from '@angular/router'


@Component({
  selector: 'app-registration',
  templateUrl: './registration.html',
  styleUrls: ['./registration.css']
})

export class Registration implements OnInit {

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
    private checkRegistration: CheckRegistrationService,
    private router: Router,
    private reg: RegService
    ) {}

  ngOnInit() {
  }
  
  chekPasswordLabel(event: any) {

  }


  userRegistrationClick() {
    const user = {
      surname: this.surname,
      name: this.name,
      patronymic: this.patronymic,
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

  if (!this.checkRegistration.checkNullSurname(user.surname)) {
    this.surnameErrTitle = 'Фамилия не введена';
    errCount++;
   }
   if (!this.checkRegistration.checkNullName(user.name)) {
    this.nameErrTitle = 'Имя не введено'
    errCount++;
   }
   if (!this.checkRegistration.checkNullPatronymic(user.patronymic)) {
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
    this.passwordErrTitle = 'Необходимы строчные и заглавные латинские буквы, цифры. Длина или более'
    errCount++;
   }

   if (!this.checkRegistration.checkPasswordRepead(user.password, user.passwordRepead)) {
    this.passwordRepeadErrTitle = 'Пароли не совпадают'
    errCount++
   }
   
   if (errCount > 0) return false
   
   this.reg.regUser(user)

   return

  }

  }

