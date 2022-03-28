import { Component, ViewChild  } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { HomeService } from '../../services/home.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  @ViewChild('fileInput',{ static: false }) fileInput;
  message: string;
  constructor(private http: HttpClient, private service: HomeService) { }

  uploadFile() {
    let formData = new FormData();
    formData.append('upload', this.fileInput.nativeElement.files[0])

    this.service.UploadExcel(formData).subscribe(result => {
      this.message = result.toString();
    });

  }
}
