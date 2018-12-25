import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {HttpClientModule} from '@angular/common/http';

import { EAttandanceRoutingModule } from './e-attandance-routing.module';
import { OrganizationInformationComponent } from './organization-information/organization-information.component';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';

@NgModule({
  declarations: [OrganizationInformationComponent],
  imports: [
    CommonModule,
    EAttandanceRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    FormsModule
  ]
})
export class EAttandanceModule {

  
 }
