import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs'; 
import { HomeService } from '../../services/home.service';
import { Organisations } from '../../models/organisations';


@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-organisations.component.html'
})
export class FetchDataComponent {
  public organisations: Observable<Organisations[]>;

  constructor(http: HttpClient, private service: HomeService) {
  
      this.organisations = this.service.getOrganisations();
  
  }
}




