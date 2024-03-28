import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/types/user';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import {  Result } from 'src/app/types/result';
import { NavigationExtras, Router } from '@angular/router';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {

  constructor(private route: Router, private http: HttpClient) { }

  users: User[] =[];
   root: string = environment.rootUrl + "/Users";
 // root: string =  "https://localhost:7054/api/Users";
  addMode: boolean = false;
  newUser: User = new User();



  ngOnInit(): void {
    this.getUsers();
  }

  open(u: User) {
    this.route.navigate(['user', u.id], { state: { user: u } });

  }
  editUserA(user: User) {
    user.inEdit = true;
  }
  cancelAdd() {
    this.addMode = false;
    this.newUser = new User();
  }
  cancel(u: User) { 
    u.inEdit = false;
    this.getUsers();
  }
  getUsers() {
    this.http.get<Result>(this.root).subscribe((result: Result) => {
      if(result.saveStatus==1)
        this.users =result.data as User[];
        this.users = result.data.map((item: any) => {
          return {
            id: item.id,
            firstName: item.firstName,
            lastName: item.lastName,
            addressCity: item.addressCity,
            addressStreet: item.addressStreet,
            addressNumber:item.addressNumber,
            dateOfBirth: item.dateOfBirth,
            phoneNumber:item.phoneNumber,
            mobilePhone:item.mobilePhone
            
            // המרה והשמה של שאר השדות...
          };
        });
      
        console.log(this.users);
    })
  }

  addNewUser() {
    this.addMode = !this.addMode;
  }

  moreDetails(){
    this.route.navigate(['generalData']);
  }

  addUser() {
    this.addMode=false;
    this.http.post<Result>(this.root, this.newUser).subscribe((res: Result) => {
      if (res.saveStatus==1) {
        this.newUser=new User();
        this.getUsers();
      }
      else {
        alert("this user already exist.");
      }
    })
  }

  updateUser(user: User) {
    this.http.put<Result>(this.root + "/" + user.id, user).subscribe((res: Result) => {
      if (res.saveStatus==1) {
        this.getUsers();
      }
      else {
        alert("update failed...")
      }
    })
  }


  deleteUser(id: string) {
    this.http.delete<Result>(this.root+"/" + id).subscribe((res: Result) => {
      if (res.saveStatus==1) {
        this.getUsers();
      }
      else {
        alert("delete failed...")
      }
    })
  }

  isError(user: User) {
    if (user.id == null) {
      return true;
    }
    if (user.firstName == null || user.lastName == null) {
      return true;
    }
    if (user.dateOfBirth == null || user.addressCity == null) {
      return true;
    }
    if (user.mobilePhone == null) {
      return true;
    }
    return false;
  }

  formatDate(date: Date): string {
    const d = new Date(date);
    let month = '' + (d.getMonth() + 1);
    let day = '' + d.getDate();
    let year = d.getFullYear();
  
    if (month.length < 2) 
        month = '0' + month;
    if (day.length < 2) 
        day = '0' + day;
  
    return [year, month, day].join('-');
  }

  numberOnly(event: any): void {
    const pattern = /[0-9]/;
    let inputChar = String.fromCharCode(event.charCode);
  
    if (!pattern.test(inputChar)|| event.target.value.length>=9) {
      event.preventDefault();
    }
  }

  lettersOnly(event: any): void {
    const pattern = /^[A-Za-z\u0590-\u05FF\s]+$/;
    let inputChar = String.fromCharCode(event.charCode);
  
    if (!pattern.test(inputChar)) {
      event.preventDefault();
    }
  }
  
}

