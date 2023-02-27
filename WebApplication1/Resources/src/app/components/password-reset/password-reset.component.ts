import { Component } from '@angular/core';

@Component({
  selector: 'app-password-reset',
  templateUrl: './password-reset.component.html',
  styleUrls: ['./password-reset.component.css']
})
export class PasswordResetComponent {
  constructor() { }

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

}


