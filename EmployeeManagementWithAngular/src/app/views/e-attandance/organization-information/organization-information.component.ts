import { Component, OnInit } from '@angular/core';
import { Organization } from '../../../Models/organization';
import { FormGroup, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-organization-information',
  templateUrl: './organization-information.component.html',
  styleUrls: ['./organization-information.component.scss']
})
export class OrganizationInformationComponent implements OnInit {

  public form: FormGroup
  constructor(private fb: FormBuilder) {
    this.form = this.createform({
      organizationId: '',
      organizationName_En: '',
      organizationName_Np: '',
      panNo: '',
      address_En: '',
      address_Np: '',
      contactNo: '',
      email: '',
      website: '',
      logo: '',
      establishedDate_AD: '',
      establishedDate_BS: '',
      createDate_AD: '',
      createDate_BS: ''
    });
  }
  ngOnInit() {
   
  }
  private createform(model:Organization):FormGroup{
    return this.fb.group(model);
  }


}
