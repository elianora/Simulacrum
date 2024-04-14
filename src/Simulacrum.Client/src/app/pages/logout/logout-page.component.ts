import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../core/identity/auth.service';
import { take } from 'rxjs';
import { Router } from '@angular/router';

@Component({
  templateUrl: './logout-page.component.html',
  styleUrl: './logout-page.component.scss'
})
export class LogoutPageComponent implements OnInit {
  constructor(
    private authService: AuthService,
    private router: Router) {}

  ngOnInit() {
    this.authService.signOut()
      .pipe(take(1))
      .subscribe({
        next: (signedOut) => {
          if (signedOut) {
            this.router.navigate(['login']);
          }
        }
      });
  }
}
