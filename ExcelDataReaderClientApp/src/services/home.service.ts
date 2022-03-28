import { Injectable } from '@angular/core';
import { HttpHeaders } from '@angular/common/http';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Organisations } from '../models/organisations';

@Injectable({
  providedIn: 'root'
})
export class HomeService {

  constructor(private http: HttpClient) { }

  url = 'http://localhost:44396/Api/ExcelData';

  UploadExcel(formData: FormData) {
    let headers = new HttpHeaders();

    headers.append('Content-Type', 'multipart/form-data');
    headers.append('Accept', 'application/json');

    const httpOptions = { headers: headers };

    return this.http.post(this.url + '/UploadExcel', formData, httpOptions)
  }
  getOrganisations():Observable<Organisations[]> {
    return  this.http.get<Organisations[]>(this.url + '/GetOrganisations');
    }

}


