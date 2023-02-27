import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CheckDataService {

  constructor() { }

  checkNullSurname(surname: string) {

    if (surname == '') {
      return false
    }
    else return true;

  }

  checkNullName(name: string) {

    if (name == '') {
      return false
    }
    else return true;

  }

  checkNullPatronymic(patronymic: string) {

    if (patronymic == '') {
      return false
    }
    else return true;

  }

  checkNullEmail(email: string) {

    if (email == '') {
      return false
    }
    else return true;

  }

  checkEmail(email: string) {
    var lowerRussianLetters = /[а-я]/g
    var upperRussianLetters = /[А-Я]/g

    if (email.indexOf('@') != -1 
    && (email.indexOf('.com') != -1 || email.indexOf('.ru') != -1)
    && email.match(lowerRussianLetters) == null
    && email.match(upperRussianLetters) == null
    ) return true
    else return false
  }

  checkNullPassword(password: string) {

    if (password == '') {
      return false
    }
    else return true;

  }

  checkPasswordStrength(password: string) {
    var lowerCaseLetters = /[a-z]/g
    var upperCaseLetters = /[A-Z]/g
    var numbers = /[0-9]/g
    var lowerRussianLetters = /[а-я]/g
    var upperRussianLetters = /[А-Я]/g

    if(password.match(lowerCaseLetters) != null 
    && password.match(upperCaseLetters) != null 
    && password.match(numbers) != null
    && password.match(lowerRussianLetters) == null
    && password.match(upperRussianLetters) == null
    && password.length >= 8) return true
    else return false
    
  }

  checkPasswordRepead(password:string, passwordRepead: string) {
    if (password == passwordRepead) {
      return true
    }
    else return false
  }

}
