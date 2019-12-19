import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/services/login.service';
import { LoginModel } from 'src/models/login.model';
import { Router } from '@angular/router';
import { TokenModel } from 'src/models/token.model';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  user: LoginModel;
  loading: boolean;
  message: string;

  constructor(private authService: AuthService, private router: Router) {
    this.user = new LoginModel();
    if (authService.token.access_token) {
      this.router.navigate(['/home']);
    }
  }

  login() {
    this.loading = true;
    this.authService.authenticate(this.user).subscribe((res: TokenModel) => {
      if (res.access_token) {
        localStorage.setItem("token", JSON.stringify(res));
        this.refreshTokenAfterTimeout(res.expires_in);
        this.router.navigate(['/home']);
      }
      else {
        this.setSuccessOrErrorMessage("A problem has occured");
      }
    },
      (error) => {
        if (error.error.error) {
          this.setSuccessOrErrorMessage(error.error.error_description)
        }
        else {
          this.setSuccessOrErrorMessage("Server error!")
        }
      });
  }

  setSuccessOrErrorMessage(message) {
    this.loading = false;
    this.message = message;
  }

  refreshTokenAfterTimeout(tokenTimeOut) {
    setTimeout(() => {
      this.authService.clearSession();
      this.router.navigate(['/login']);
    }, tokenTimeOut);
  }

  ngOnInit() { }
}
