import { Component } from '@angular/core';
import { AuthService } from '../auth.service';
import { Router } from '@angular/router'
import { CheckDataService } from '../check-data.service';

@Component({
  selector: 'app-password-reset',
  templateUrl: './password-reset.component.html',
  styleUrls: ['./password-reset.component.css']
})
export class PasswordResetComponent {
  constructor(
    private router: Router,
    private auth: AuthService,
    private checkRasswordReset: CheckDataService) { }

  email: string = '';
  emailErrLabel = ''

  passwordResetClick() {


    const user = {
      email: this.email
    }

    if (!this.checkRasswordReset.checkNullEmail(user.email)) {
      this.emailErrLabel = 'Email не введен'
      return false
    } else if (!this.checkRasswordReset.checkEmail(user.email)) {
      this.emailErrLabel = 'Некорректный email'
      return false
    }
    else {
      this.auth.passwordReset(user).subscribe(data => {
        if (!data.succes) {
          this.emailErrLabel = 'Email не найден'
        }
        else
          alert('На вашу почту отправлена ссылка для восстановления пароля')
        this.router.navigate(['/login']);
        this.auth.platformUser(data.token, data.user)
      })
    }
    return

  }
}


