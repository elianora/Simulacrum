import { HttpClient, HttpErrorResponse, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, Subject, catchError, map, of, tap } from 'rxjs';
import { LoginInfo } from './login-info.model';
import { UserInfo } from './user-info.model';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private _authStateChanged: Subject<boolean> = new BehaviorSubject(false);

  constructor(private http: HttpClient) {}

  public checkSignedIn() {
    return this.getCurrentUser()
              .pipe(
                map(userInfo => !!(userInfo && userInfo.email.length > 0)),
                catchError((_) => of(false))
              );
  }

  public getCurrentUser() {
    return this.http.get<UserInfo>('/manage/info', { withCredentials: true })
                    .pipe(catchError((_: HttpErrorResponse, __: Observable<UserInfo>) => of({} as UserInfo)));
  }

  public onStateChanged() {
    return this._authStateChanged.asObservable();
  }

  public register(loginInfo: LoginInfo) {
    return this.http.post<HttpResponse<string>>('/register', loginInfo)
                    .pipe(map(res => res.ok));
  }

  public signIn(loginInfo: LoginInfo) {
    return this.http.post<HttpResponse<string>>('/login?useCookies=true', loginInfo)
                    .pipe(
                      tap(res => this._authStateChanged.next(res.ok)),
                      map(res => res.ok)
                    );
  }

  public signOut() {
    return this.http.post<HttpResponse<string>>('/logout', {}, { withCredentials: true })
                    .pipe(
                      tap(res => {
                        if (res.ok) {
                          this._authStateChanged.next(false);
                        }
                      }),
                      map(res => res.ok)
                    );
  }
}
