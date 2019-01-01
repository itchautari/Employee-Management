import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Organization } from '../Models/organization';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class OrganizationService {

  private insertOrgURL: string = 'http://localhost:65411/api/OrganizationInfoes';
  constructor(private http: HttpClient) { 

  }
  
  // insertOrganization(orgInfo: Organization):Observable<HttpResponse<Organization>>{
  //   debugger;
  //   let httpHeaders = new HttpHeaders({
  //     'Content-Type': 'application/json',
  //     'Cache-Control': 'no-cache'
  //   });
  //   return this.http.post<Organization>(this.insertOrgURL, orgInfo, 
  //     {
  //     headers: httpHeaders,
  //     observe: 'response'
  //   });
  // }

  insertOrganization(logoImage: File, logoImg: ArrayBuffer| string, orgInfo: Organization): Observable<HttpResponse<Organization>> {
    let formData: FormData = new FormData()
    formData.append('image', logoImage, logoImage.name);
    let orgWF = {
      fileName : logoImage.name,
      // logoImg : formData,
      organizationInfo: orgInfo,
    };
    
    return this.http.post<Organization>(this.insertOrgURL, 
      orgWF,
      {
        observe: 'response'
      });
  }

//   insertOrg(orgInfo: Organization): Observable<HttpResponse<string>> {
//     debugger;
//     let httpHeaders = new HttpHeaders({
//       'Content-Type': 'application/json',
//       'Cache-Control': 'no-cache'
//     });
// let org: string = 'Test Test';
// return this.http.post < string > (this.insertOrgURL, {id: 1, name: org},
//       {
//         headers: httpHeaders,
//         observe: 'response'
//       });
//   }
}
