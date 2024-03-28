import { CovidInfections } from "./covid-infections";


export class User {
    id!:string;
    firstName!: string;
    lastName!:string;
    addressCity!:string;
    addressStreet?:string;
    addressNumber?:number;
    dateOfBirth!:Date;
    phoneNumber?:number;
    mobilePhone!:number;
    inEdit:boolean=false;


}
