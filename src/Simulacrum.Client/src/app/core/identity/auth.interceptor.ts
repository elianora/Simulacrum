import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, tap } from 'rxjs';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
  constructor(private router: Router) {}

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
      return next.handle(req)
                .pipe(
                  tap({
                    next: (evt: HttpEvent<any>) => {
                      if (evt instanceof HttpErrorResponse) {
                        if (evt.status !== 401 || (evt.url && evt.url.indexOf("manage/info") >= 0)) {
                          return;
                        }
                        this.router.navigate(['login']);
                      }
                    }
                  })
                );
  }
}
