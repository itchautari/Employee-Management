import { Component, OnInit } from '@angular/core';
import { Organization } from '../../../../Models/organization';
import { FormGroup, FormBuilder, Validators, AbstractControl } from '@angular/forms';
import { OrganizationService } from '../../../../Services/organization.service';
import { Key } from 'protractor';
import { SharedProps } from '../shared-props';
import { ActivatedRoute } from '@angular/router';
import { formArrayNameProvider } from '@angular/forms/src/directives/reactive_directives/form_group_name';

@Component({
  selector: 'app-organization-information',
  templateUrl: './organization-information.component.html',
  styleUrls: ['./organization-information.component.scss'],
})
export class OrganizationInformationComponent implements OnInit {

  private isEdit: boolean = false;
  private editOrgId: number;
  
  public form: FormGroup;
  public orgInfo: Organization = new Organization();
  public language: string = 'en';
  public logoImg: string | ArrayBuffer = "";
  public logoImage: File;

  public dismissableErrors: any = [];

  public get frm() : {[Key: string]: AbstractControl} {
    return this.form.controls
  }
  

  public labelEn: object = {
    orgName: "Name",
    panNo: "PAN",
    address: "Address",
    email: "Email",
    website: "Website",
    logo: "Logo",
    estd: "ESTD"
  };

  public plcHldrEn: object = {
    orgName: "Organization Name",
    panNo: "PAN Number",
    address: "Address",
    email: "Organization Email eg:example.gmail.com",
    website: "Website eg:https://www.examplesite.com",
    logo: "Logo",
    estd: "Established Date"
  };

  public labelNp: object = {
    orgName: "नाम",
    panNo: "प्यान",
    address: "यड्रेस",
    email: "ईमेल",
    website: "वेबसाईट",
    logo: "लोगो",
    estd: "समारोहा"
  }

  public plcHldrNp: object = {
    orgName: "संस्थाको नाम",
    panNo: "प्यान नंबर",
    address: "यड्रेस",
    email: "ईमेल",
    website: "वेबसाईट",
    logo: "लोगो",
    estd: "समारोह(उध्घाटन्) भयको दिन"
  }

  public _labels: object;
  public get labels(): object {
    if (this.language == 'en') {
      this._labels = this.labelEn
    } else {
      this._labels = this.labelNp
    }
    return this._labels;
  }

  public _plcHldr: object;
  public get plcHldr(): object {
    if (this.language == 'en') {
      this._plcHldr = this.plcHldrEn;
    } else {
      this._plcHldr = this.plcHldrNp;
    }
    return this._plcHldr;
  }

  
  constructor(private fb: FormBuilder, private orgService: OrganizationService, private activatedRoute: ActivatedRoute) {

    this.editOrgId = parseInt(this.activatedRoute.snapshot.paramMap.get('id'));
    if (this.editOrgId > 0) {
      this.setEditOrg();
    }else{
      this.createform();
      this.isEdit = false;
    }
    

  }

  ngOnInit() { }

  private setEditOrg(){
    this
      .orgService
      .getOrgToUpdate(this.editOrgId)
      .subscribe(resp => {
        this.orgInfo = resp.body;
        this.logoImg = "data:image/jpeg;base64," + this.orgInfo.logo;
        this.isEdit = true;
        this.createform();
      });
  }

  public createform() {
    let model : Organization = this.orgInfo;
    this.form = this.fb.group({
      // organizationId: [model.organizationId],
      organizationNameEn: [model.organizationNameEn, Validators.required],
      organizationNameNp: [model.organizationNameNp],
      panNo: [model.panNo],
      addressEn: [model.addressEn, Validators.required],
      addressNp: [model.addressNp],
      email: [model.email, Validators.compose([Validators.required, Validators.email])],
      website: [model.website],
      logo: [model.logo],
      establishedDateEn: [model.establishedDateEn, Validators.compose([Validators.required])],
      establishedDateNp: [model.establishedDateNp],
      createDateEn: [model.createDateEn],
      createDateNp: [model.createDateNp],
      modifiedDate: [model.modifiedDate],
      modifiedBy: [model.modifiedBy]
    });
  }

  public findInvalidControls() {
    const invalid = [];
    const controls = this.frm;
    for (const name in controls) {
      if (controls[name].invalid) {
        invalid.push(name);
      }
    }
    console.log(invalid)
  }

  public randerClass(ctrl: AbstractControl): any{
    return { 
      'is-invalid': this.isConrolInvalid(ctrl),
      'is-valid' : this.isConrolInvalid(ctrl) && ctrl.value
    }
  }

  public isConrolInvalid(ctrl: AbstractControl){
    return ctrl.invalid && (ctrl.dirty || ctrl.touched);
  }


  public showErrorMessage(ctrl: AbstractControl){
    console.log(ctrl)
    if(ctrl.invalid){
      if(ctrl.errors.required){
        this.dismissableErrors.push({
          type: "danger",
          msg: "This field is required!!!. Please supply some value to this field.",
          timeOut: 5000
        });
      }
      else if(ctrl.errors.email){
        this.dismissableErrors.push({ 
          type: "danger",
          msg: "Email is not valid!!!.",
          timeOut: 5000
        });
      }
    }
    
  }

  public popupFileChooser() {
    document.getElementById("fiLogo").click();
  }

  public fileChanged(event) {
    if (event.target.files.length == 0) {
      this.logoImg = ""
      return;
    }

    this.logoImage = event.target.files[0];

    var reader = new FileReader();
    reader.readAsDataURL(this.logoImage);
    reader.onload = (_event) => {
      this.logoImg = reader.result;
    }

  }

  private submit() {
    debugger;
    if(this.isEdit){
      this.orgService.updateOrganization(this.logoImage, this.logoImg, this.form.value)
        .subscribe((org) => {
          console.log(org)
        });
    }else{
      this
        .orgService
        .insertOrganization(this.logoImage, this.logoImg, this.form.value)
        .subscribe((org) => {
          console.log(org);
        });
    }
  }
}
