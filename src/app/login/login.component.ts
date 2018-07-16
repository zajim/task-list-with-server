import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { AuthService } from '../core/auth.service';
import { Login } from '../login/login.model';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  username: string;
  password: string;

  constructor(private _authService: AuthService, private _router: Router) { }

  ngOnInit() {
  }

  login(): void {
    let loginData = new Login();
    loginData.clientId = "1234567890";
    loginData.username = this.username;
    loginData.password = this.password;
    this._authService.login(loginData).subscribe((result) => {
      if (result) {
        this._router.navigate(['/']);
        location.reload();
      }
    });
  }

}
