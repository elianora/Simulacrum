import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../core/identity/auth.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { LoginInfo } from '../../core/identity/login-info.model';
import { take } from 'rxjs';
import { Router } from '@angular/router';

@Component({
  templateUrl: './register-page.component.html',
  styleUrl: './register-page.component.scss'
})
export class RegisterPageComponent implements OnInit {
  registerForm?: FormGroup;

  constructor(
    private authService: AuthService,
    private formBuilder: FormBuilder,
    private router: Router) {}

  ngOnInit() {
    this.registerForm = this.formBuilder.group({
      email: ['', [Validators.email, Validators.required]],
      password: ['', [Validators.required]],
      confirmPassword: ['', [Validators.required]]
    });
  }

  register(_: any) {
    if (!this.registerForm?.valid) {
      return;
    }

    const password = this.registerForm.get('password')?.value;
    const confirmPassword = this.registerForm.get('confirmPassword')?.value;
    if (password !== confirmPassword) {
      return;
    }

    let registrationInfo: LoginInfo = {
      email: this.registerForm.get('email')?.value,
      password: password
    };

    this.authService.register(registrationInfo)
      .pipe(take(1))
      .subscribe({
        next: (registered) => {
          if (registered) {
            this.router.navigate(['login'])
          }
        }
      });
  }
}
