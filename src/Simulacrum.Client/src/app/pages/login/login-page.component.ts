import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../core/identity/auth.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { LoginInfo } from '../../core/identity/login-info.model';
import { take } from 'rxjs';
import { Router } from '@angular/router';

@Component({
  templateUrl: './login-page.component.html',
  styleUrl: './login-page.component.scss'
})
export class LoginPageComponent implements OnInit {
  loginForm?: FormGroup;

  constructor(
    private authService: AuthService,
    private formBuilder: FormBuilder,
    private router: Router) {}

  ngOnInit() {
    this.loginForm = this.formBuilder.group({
      email: ['', [Validators.email, Validators.required]],
      password: ['', [Validators.required]]
    });
  }

  login(_: any) {
    if (!this.loginForm?.valid) {
      return;
    }

    let loginInfo: LoginInfo = {
      email: this.loginForm.get('email')?.value,
      password: this.loginForm.get('password')?.value
    };

    this.authService.signIn(loginInfo)
      .pipe(take(1))
      .subscribe({
        next: (loggedIn) => {
          if (loggedIn) {
            this.router.navigate(['home']);
          }
        }
      })
  }
}
