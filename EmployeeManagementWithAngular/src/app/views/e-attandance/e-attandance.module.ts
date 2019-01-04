import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {HttpClientModule} from '@angular/common/http';

import { EAttandanceRoutingModule } from './e-attandance-routing.module';
import {OrganizationInformationComponent} from './organization/organization-information/organization-information.component';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import {OrganizationListComponent} from './organization/organization-list/organization-list.component';
import { AgGridModule } from 'ag-grid-angular';
import { OrgCustomCellEDDButtonsComponent } from './organization/org-custom-cell-eddbuttons/org-custom-cell-eddbuttons.component';
import { EditOrganizationComponent } from './organization/edit-organization/edit-organization.component';

@NgModule({
  declarations: [OrganizationInformationComponent, OrganizationListComponent, OrgCustomCellEDDButtonsComponent, EditOrganizationComponent],
  imports: [
    CommonModule,
    EAttandanceRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    FormsModule,
    AgGridModule.withComponents([OrganizationListComponent])
  ],
  entryComponents: [
    OrgCustomCellEDDButtonsComponent
  ]
})
export class EAttandanceModule {

  
 }
