import { Component, OnInit } from '@angular/core';
import { Organization } from '../../../Models/organization';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { OrganizationService } from '../../../Services/organization.service';
import { Key } from 'protractor';

@Component({
  selector: 'app-organization-information',
  templateUrl: './organization-information.component.html',
  styleUrls: ['./organization-information.component.scss']
})
export class OrganizationInformationComponent implements OnInit {

  private form: FormGroup
  private orgInfo: Organization = new Organization();
  private language: string = 'en';

  private labelEn: object = {
    orgName: "Name",
    panNo: "PAN",
    address: "Address",
    email: "Email",
    website: "Website",
    logo: "Logo",
    estd: "ESTD"
  };

private plcHldrEn : object = {
  orgName: "Organization Name",
  panNo: "PAN Number",
  address: "Address",
  email: "Organization Email eg:example.gmail.com",
  website: "Website eg:https://www.examplesite.com",
  logo: "Logo",
  estd: "Established Date"
};

  private labelNp: object = {
    orgName: "नाम",
    panNo: "प्यान",
    address: "यड्रेस",
    email: "ईमेल",
    website: "वेबसाईट",
    logo: "लोगो",
    estd: "समारोहा"
  }

  private plcHldrNp: object = {
    orgName: "संस्थाको नाम",
    panNo: "प्यान नंबर",
    address: "यड्रेस",
    email: "ईमेल",
    website: "वेबसाईट",
    logo: "लोगो",
    estd: "समारोह(उध्घाटन्) भयको दिन"
  }
  
  private _labels : object;
  public get labels() : object {
    if(this.language == 'en'){
      this._labels = this.labelEn
    }else{
      this._labels = this.labelNp
    }
    return this._labels;
  }
  
  private _plcHldr : object;
  public get plcHldr() : object {
    if (this.language == 'en') {
      this._plcHldr = this.plcHldrEn;
    } else {
      this._plcHldr = this.plcHldrNp;
    }
    return this._plcHldr;
  } 
  

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
