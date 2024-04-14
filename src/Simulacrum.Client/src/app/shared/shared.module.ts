import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

/**
 * The shared module defines common components that can be re-used across any feature of the application.
 *
 * This module should be imported into each feature module in order to provide common functionality and components.
 */
@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    RouterModule
  ],
  exports: [
    ReactiveFormsModule,
    RouterModule
  ]
})
export class SharedModule {
  constructor() {}
}
