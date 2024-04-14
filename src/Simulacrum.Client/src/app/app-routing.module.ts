import { NgModule } from '@angular/core';
import { RouterModule, Routes, mapToCanActivate } from '@angular/router';
import { LoginPageComponent } from './pages/login/login-page.component';
import { HomePageComponent } from './pages/home/home-page.component';
import { AuthGuard } from './core/identity/auth.guard';
import { RegisterPageComponent } from './pages/register/register-page.component';
import { LogoutPageComponent } from './pages/logout/logout-page.component';

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    redirectTo: 'home'
  },
  {
    path: 'home',
    canActivate: mapToCanActivate([AuthGuard]),
    component: HomePageComponent
  },
  {
    path: 'logout',
    canActivate: mapToCanActivate([AuthGuard]),
    component: LogoutPageComponent
  },
  {
    path: 'login',
    component: LoginPageComponent
  },
  {
    path: 'register',
    component: RegisterPageComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
