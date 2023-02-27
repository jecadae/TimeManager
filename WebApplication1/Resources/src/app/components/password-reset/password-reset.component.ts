import { Component } from '@angular/core';
import { AuthService } from '../auth.service';
import { Router } from '@angular/router'
import {CheckRegistrationService} from '../registration/check-registration.service';

@Component({
  selector: 'app-password-reset',
  templateUrl: './password-reset.component.html',
  styleUrls: ['./password-reset.component.css']
})
export class PasswordResetComponent {
  constructor(    
    private router: Router,
    private auth: AuthService,
    private checkRegistration: CheckRegistrationService) { }

    email: string = '';
    emailErrLabel = ''

  checkNullEmail() {
    let errCount = 0;


    const user = {
      email: this.email
    }

    if (!this.checkRegistration.checkNullEmail(user.email)) {
      this.emailErrLabel = 'Email не введен'
      errCount++;
     } else if (!this.checkRegistration.checkEmail(user.email)) {
      this.emailErrLabel = 'Некорректный email'
      errCount++;
     }
}
}


