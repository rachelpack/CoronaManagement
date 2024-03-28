import { HttpClient } from '@angular/common/http';
import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, NavigationEnd, Router } from '@angular/router';
import { filter, takeUntil } from 'rxjs';
import { CovidInfections } from 'src/app/types/covid-infections';
import { Result } from 'src/app/types/result';
import { User } from 'src/app/types/user';
import { Vaccination } from 'src/app/types/vaccinations';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {
  root: string = environment.rootUrl + "/AdditionalUserInfo";
  user: User;
  addVaccMode: boolean = false;
  addNewVacc: Vaccination = new Vaccination();
  addCovidMode: boolean = false;
  addNewCovid: CovidInfections = new CovidInfections();
  vaccinations: Vaccination[] = [];
  covidInfection?: CovidInfections;

  constructor(private router: Router, private activeRoute: ActivatedRoute, private http: HttpClient) {
    const state = this.router.getCurrentNavigation()?.extras.state;
    this.user = state ? state['user'] : null;
  }

  ngOnInit(): void {
    this.getVaccinations();
    this.getCovidInfection();
    console.log(this.vaccinations.length)
  }

  getCovidInfection() {
    this.http.get(this.root + "/GetCovidInfection/" + this.user.id).subscribe((res: Result) => {
      if (res.saveStatus == 1) {
        this.covidInfection = res.data;
      }
    })
  }

  getVaccinations() {
    this.http.get<Result>(this.root + "/GetVaccinations/" + this.user.id).subscribe((res: Result) => {
      if (res.saveStatus == 1) {
        this.vaccinations = res.data;
        this.addNewVacc.doseNumber = this.vaccinations.length + 1;
      }
    })
  }

  addVaccination() {
    this.addNewVacc.userID = this.user.id;
    this.http.post<Result>(this.root + "/AddVaccination", this.addNewVacc).subscribe((res: Result) => {
      if (res.saveStatus == 1) {
        alert("success");
        this.getVaccinations();
        this.addNewVacc = new Vaccination();

      }
    })
  }

  addCovidInfection() {
    this.addNewCovid.userID = this.user.id;
    this.http.post<Result>(this.root + "/addCovidInfection", this.addNewCovid).subscribe((res: Result) => {
      if (res.saveStatus == 1) {
        alert("success");
        this.getCovidInfection();
      }
    })
  }


  isError1() {
    if (this.addNewVacc.vaccineDate == null || this.addNewVacc.vaccineManufacturer == null) {
      return true;
    }
    return false;
  }

  isError2() {
    if (this.addNewCovid.positiveTestDate == null || this.addNewCovid.recoveryDate == null) {
      return true;
    }
    return false;
  }

  exit() {
    this.router.navigate(['users']);
  }
}
