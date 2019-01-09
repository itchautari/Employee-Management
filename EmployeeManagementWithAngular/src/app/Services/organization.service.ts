import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Organization } from '../Models/organization';
import { Observable, BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class OrganizationService {

  private URL: string = 'http://localhost:65411/api/OrganizationInfoes';

  // public editOrgSubject = new BehaviorSubject(undefined);

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

  // setEditOrg(org: Organization){
  //   this.editOrgSubject.next(org);
  // }

  insertOrganization(logoImage: File, logoImg: ArrayBuffer | string, orgInfo: Organization): Observable<HttpResponse<Organization>> {
    let formData: FormData = this.generateFormData(orgInfo);
    formData.append("logoImg", logoImage, logoImage.name);
    // let orgWF = {
    //   fileName : logoImage.name,
    //   logoImg : logoImg,
    //   organizationInfo: orgInfo,
    // };

    return this.http.post<Organization>(this.URL,
      formData,
      {
        observe: 'response'
      });
  }

  getOrgToUpdate(orgId: number): Observable<HttpResponse<Organization>> {
    let httpHeaders = new HttpHeaders({ 'Content-Type': 'application/json', 'Cache-Control': 'no-cache' });
    return this.http.get<Organization>(this.URL + "/" + orgId, {
      headers: httpHeaders,
      observe: 'response'
    });
  }

  updateOrganization(logoImage: File, logoImg: ArrayBuffer | string, org: Organization): Observable<HttpResponse<Organization>> {

    let formData: FormData = this.generateFormData(org);
    formData.append("logoImg", logoImage, logoImage.name);

    // let orgWF = {
    //   fileName: logoImage.name,
    //   logoImg: logoImg,
    //   organizationInfo: org,
    // };

    return this.http.put<Organization>(this.URL + "/" + org.organizationId,
      formData,
      {
        observe: 'response'
      });
  }

  getOrganizations(): Observable<HttpResponse<string>> {
    let httpHeaders = new HttpHeaders({
      'Content-Type': 'application/json',
      'Cache-Control': 'no-cache'
    });
    return this.http.get<string>(this.URL,
      {
        headers: httpHeaders,
        observe: 'response'
      });
  }

  deleteOrganization(orgId: number): any {
    let httpHeaders = new HttpHeaders({ 'Content-Type': 'application/json', 'Cache-Control': 'no-cache' });
    return this.http.delete<any>(this.URL + "/" + orgId, { headers: httpHeaders });
  }

  public generateFormData(data: any): FormData {
    let formData = new FormData();
    Object.keys(data).forEach(key => formData.append(key, data[key] == "null" ? null : data[key]));
    return formData;
  }
}
