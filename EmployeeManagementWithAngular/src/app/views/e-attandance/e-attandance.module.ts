import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { EAttandanceRoutingModule } from './e-attandance-routing.module';
import { OrganizationInformationComponent } from './organization-information/organization-information.component';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [OrganizationInformationComponent],
  imports: [
    CommonModule,
    EAttandanceRoutingModule,
    ReactiveFormsModule
  ]
})
export class EAttandanceModule {

  
 }
