import { Component, OnInit } from '@angular/core';
import { OrganizationService } from '../../../../Services/organization.service';
import {Router} from '@angular/router';
import { OrgCustomCellEDDButtonsComponent } from '../org-custom-cell-eddbuttons/org-custom-cell-eddbuttons.component';

@Component({
  selector: 'app-organization-list',
  templateUrl: './organization-list.component.html',
  styleUrls: ['./organization-list.component.scss']
})
export class OrganizationListComponent implements OnInit {

  private language: string = 'en';
  private field: string = this.language == 'en' ? "organizationNameEn" : "organizationNameNp"
  private colDefsEn: Array<any> = [
    {
      headerName: "Organization Name",
      field: "organizationNameEn"
    },
    {
      headerName: "Pan No",
      field: "panNo",
    },
    {
      headerName: "Address",
      field: "addressEn"
    }, {
      headerName: "Email",
      field: "email"
    },
    {
      headerName: "Website",
      field: "website",
    },
    {
      headerName: "Logo",
      field: "logo",
    },
    {
      headerName: "Established Date",
      field: "establishedDateEn"
    }, {
      headerName: "Create Date",
      field: "createDateEn"
    },
    {
      headerName: "Modified Date",
      field: "modifiedDate",
    },
    {
      headerName: "Modified By",
      field: "modifiedBy",
    },
    {
      headerName: "Actions",
      cellRendererFramework: OrgCustomCellEDDButtonsComponent
    }
  ];
  private colDefsNp : Array <any> = [
    {
      headerName : "संस्थाको नाम",
      field: "organizationNameNp"
    }, {
      headerName: "प्यान नंबर",
      field: "panNo"
    }, {
      headerName: "यड्रेस",
      field: "addressNp"
    }, {
      headerName: "ईमेल",
      field: "email"
    }, {
      headerName: "वेबसाईट",
      field: "website"
    }, {
      headerName: "लोगो",
      field: "logo"
    }, {
      headerName: "समारोह(उध्घाटन्) भयको दिन",
      field: "establishedDateNp"
    }, {
      headerName: "इन्त्री गरको समय",
      field: "createDateNp"
    }, {
      headerName: "परिवर्तन गरको समय",
      field: "modifiedDate"
    }, {
      headerName: "परिवर्तन गर्ने वाला",
      field: "modifiedBy"
    }, {
      headerName: "यक्सन",
      cellRendererFramework: OrgCustomCellEDDButtonsComponent
    }
  ];
  private colDefs = this.colDefsData();
  private row;
  private gridApi: any;
  private columnApi: any;
  constructor(private orgService : OrganizationService, private router : Router) {}

  ngOnInit() {
    this.orgService.getOrganizations().subscribe(organizations => {
      console.log(organizations.body);
      this.row = organizations.body;
    });
  }

  onGridReady(params){
    this.gridApi = params.api;
    this.columnApi = params.columnApi;
    this.autoSizeAll();
  }

  rerenderColDefs(){
    this.colDefs = this.colDefsData();
  }

  colDefsData(){
    return this.language == 'en' ? this.colDefsEn : this.colDefsNp;
  }

  autoSizeAll() {
    var allColumnIds = [];
    this.columnApi.getAllColumns().forEach(function (column) {
      allColumnIds.push(column.colId);
    });
    this.columnApi.autoSizeColumns(allColumnIds);
    console.log(allColumnIds);
  }
}
