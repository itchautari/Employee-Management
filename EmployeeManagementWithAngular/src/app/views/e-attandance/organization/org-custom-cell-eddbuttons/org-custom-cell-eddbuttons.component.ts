import { Component, OnInit } from '@angular/core';
import { OrganizationService } from '../../../../Services/organization.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-org-custom-cell-eddbuttons',
  templateUrl: './org-custom-cell-eddbuttons.component.html',
  styleUrls: ['./org-custom-cell-eddbuttons.component.scss']
})
export class OrgCustomCellEDDButtonsComponent implements OnInit {

  private rowData: any;
  constructor(private orgService: OrganizationService, private router: Router) {}

  ngOnInit() {
  }

  agInit(params){
    this.rowData = params.data;
  }

  deleteData(){
    console.log(this.rowData);
    this.orgService.deleteOrganization(this.rowData.organizationId).subscribe(
      resp => {
        console.log("Data deleted successfully!!!");
      }, 
      error => {
        console.log("Error occurred while deleting data!!!");
      }
    );
  }

  editData(){
    this.router.navigate(['eattandance/organization/'+this.rowData.organizationId]);
  }
}
