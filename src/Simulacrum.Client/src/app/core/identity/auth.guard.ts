import { Injectable } from '@angular/core';
import { AuthService } from './auth.service';
import { tap } from 'rxjs';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard {
  constructor(
    private authService: AuthService,
    private router: Router) {}

  public canActivate() {
    return this.isSignedIn();
  }

  private isSignedIn() {
    return this.authService.checkSignedIn()
                          .pipe(
                            tap(isSignedIn => {
                              if (!isSignedIn) {
                                this.router.navigate(['login']);
                              }
                            })
                          );
  }
}
