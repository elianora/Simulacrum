import { NgModule, Optional, SkipSelf } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { Router } from '@angular/router';
import { AuthInterceptor } from './identity/auth.interceptor';

/**
 * The core module configures parts of the application that are globally provided and configured at app startup.
 *
 * It does not provide any services of its own, and should only be imported in the AppModule.
 */
@NgModule({
  declarations: [],
  imports: [CommonModule, HttpClientModule],
  providers: [{
    provide: HTTP_INTERCEPTORS,
    useFactory: (router: Router) => new AuthInterceptor(router),
    multi: true,
    deps: [Router]
  }]
})
export class CoreModule {
  constructor(@Optional() @SkipSelf() parentModule: CoreModule) {
      if (parentModule) {
          throw new Error('An instance of CoreModule was already initialized!');
      }
  }
}
