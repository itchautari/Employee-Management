import { Component, OnInit } from '@angular/core';
import { Organization } from '../../../Models/organization';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { OrganizationService } from '../../../Services/organization.service';

@Component({
  selector: 'app-organization-information',
  templateUrl: './organization-information.component.html',
  styleUrls: ['./organization-information.component.scss']
})
export class OrganizationInformationComponent implements OnInit {

  public form: FormGroup
  private orgInfo: Organization = new Organization();

  constructor(private fb: FormBuilder, private orgService: OrganizationService) {
    this.form = this.createform(this.orgInfo);
  }

  ngOnInit() {}

  private createform(model:Organization):FormGroup{
    return this.fb.group({
      organizationNameEn : [model.organizationNameEn, Validators.required],
      organizationNameNp: [model.organizationNameNp, Validators.required],
      panNo: [model.panNo],
      addressEn: [model.addressEn, Validators.required],
      addressNp: [model.addressNp],
      email: [model.email, Validators.compose([Validators.required])],
      website: [model.website],
      logo: [model.logo],
      establishedDateEn: [model.establishedDateEn, Validators.required],
      establishedDateNp: [model.establishedDateNp],
      createDateEn: [model.createDateEn, Validators.required],
      createDateNp: [model.createDateNp, Validators.required],
      modifiedDate: [model.modifiedDate, Validators.required],
      modifiedBy: [model.modifiedBy, Validators.required]
    });
  }

  private submit(){
    debugger;
    this.orgService.insertOrganization(this.form.value).subscribe((org) => {
      console.log(org);
    });
  }


}
