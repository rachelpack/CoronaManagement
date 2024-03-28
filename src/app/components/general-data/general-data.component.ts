import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Result } from 'src/app/types/result';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-general-data',
  templateUrl: './general-data.component.html',
  styleUrls: ['./general-data.component.css']
})
export class GeneralDataComponent implements OnInit {

  root: string = environment.rootUrl + "/GeneralInfo";
  patientUnvacc?: number;
  constructor(private http: HttpClient, private router: Router) { }


  ngOnInit(): void {
    this.getNumberUnvcc();
  }

  getNumberUnvcc() {
    this.http.get<Result>(this.root + "/GetNumberUnvaccinatedPatients").subscribe((res: Result) => {
      if (res.saveStatus == 1) {
        this.patientUnvacc = res.data;
      }
    })
  }

  exit() {
    this.router.navigate(['users']);
  }
}
