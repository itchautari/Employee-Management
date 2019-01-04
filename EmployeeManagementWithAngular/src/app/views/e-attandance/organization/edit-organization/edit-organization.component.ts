import { Component, OnInit } from '@angular/core';
import { SharedProps } from '../shared-props';
import { FormBuilder } from '@angular/forms';
import { OrganizationService } from '../../../../Services/organization.service';
import { Organization } from '../../../../Models/organization';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-edit-organization',
  templateUrl: '../organization-information/organization-information.component.html',
  styleUrls: ['../organization-information/organization-information.component.scss']
})
export class EditOrganizationComponent implements OnInit {

  private editOrgId: number;
  private editOrg: Organization;
  private sharedProps: SharedProps;

  constructor(private fb: FormBuilder, private orgService: OrganizationService, private activatedRoute: ActivatedRoute) {
    this.editOrgId = parseInt(this.activatedRoute.snapshot.paramMap.get('id'));
    this.orgService.getOrgToUpdate(this.editOrgId).subscribe(resp => {
      this.editOrg = resp.body;
      this.editOrg.organizationId = this.editOrgId;
      this.sharedProps = new SharedProps(this.fb);
      this.sharedProps.logoImg = "data:image/jpeg;base64," + this.editOrg.logo;
      this.sharedProps.form = this.sharedProps.createform(this.editOrg);
    });
  }

  ngOnInit() {}

  private submit() {
    debugger;
    this.orgService.updateOrganization(this.sharedProps.logoImage, this.sharedProps.logoImg, this.sharedProps.form.value)
      .subscribe((org) => {
        console.log(org)
      });
  }

}
