import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {OrganizationInformationComponent} from './organization/organization-information/organization-information.component';
import {OrganizationListComponent} from './organization/organization-list/organization-list.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'organizationlist'
  },
  {
    path: 'organization',
    component: OrganizationInformationComponent
  },
  {
    path: 'organization/:id',
    component : OrganizationInformationComponent
  },
  {
    path: 'organizationlist',
    component : OrganizationListComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class EAttandanceRoutingModule { }
