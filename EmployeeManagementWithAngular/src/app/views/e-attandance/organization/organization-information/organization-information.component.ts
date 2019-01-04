import { Component, OnInit } from '@angular/core';
import { Organization } from '../../../../Models/organization';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { OrganizationService } from '../../../../Services/organization.service';
import { Key } from 'protractor';
import { SharedProps } from '../shared-props';

@Component({
  selector: 'app-organization-information',
  templateUrl: './organization-information.component.html',
  styleUrls: ['./organization-information.component.scss']
})
export class OrganizationInformationComponent implements OnInit {

  private sharedProps: SharedProps;
  constructor(private fb: FormBuilder, private orgService: OrganizationService) {
    this.sharedProps = new SharedProps(fb);
    this.sharedProps.form = this.sharedProps.createform(this.sharedProps.orgInfo);
  }

  ngOnInit() { }

  private submit() {
    debugger;
    this
      .orgService
      .insertOrganization(this.sharedProps.logoImage, this.sharedProps.logoImg, this.sharedProps.form.value)
      .subscribe((org) => {
        console.log(org);
      });
  }
}
