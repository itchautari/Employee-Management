import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { OrganizationInformationComponent } from './organization-information/organization-information.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'organization'
  },
  {
    path: 'organization',
    component: OrganizationInformationComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class EAttandanceRoutingModule { }
