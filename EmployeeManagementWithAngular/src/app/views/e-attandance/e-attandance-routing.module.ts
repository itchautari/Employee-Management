import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {OrganizationInformationComponent} from './organization/organization-information/organization-information.component';
import {OrganizationListComponent} from './organization/organization-list/organization-list.component';
import { EditOrganizationComponent } from './organization/edit-organization/edit-organization.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'organization'
  },
  {
    path: 'addorganization',
    component: OrganizationInformationComponent
  },
  {
    path: 'editorganization/:id',
    component: EditOrganizationComponent
  },
  {
    path: 'organization',
    component : OrganizationListComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class EAttandanceRoutingModule { }
