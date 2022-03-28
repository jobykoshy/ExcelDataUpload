import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-organisations.component.html'
})
export class FetchDataComponent {
  public organisations: Organisations[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Organisations[]>(baseUrl + 'GetOrganisations').subscribe(result => {
      this.organisations = result;
    }, error => console.error(error));
  }
}

interface Organisations {
  OrganisationName: string;
  OrganisationNumber: string;
  Address: Address;
  EmployeeCount: number;
}
interface Address {
  AddressLine1: string;
  AddressLine2: string;
  AddressLine3: string;
  AddressLine4: string;
  Town: string;
  PostCode: string;
 
}
