import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { EAttandanceRoutingModule } from './e-attandance-routing.module';
import { OrganizationInformationComponent } from './organization-information/organization-information.component';

@NgModule({
  declarations: [OrganizationInformationComponent],
  imports: [
    CommonModule,
    EAttandanceRoutingModule
  ]
})
export class EAttandanceModule { }
