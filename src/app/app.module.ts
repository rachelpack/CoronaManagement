import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UsersComponent } from './components/users/users.component';
import { RouterModule } from '@angular/router';
import { UserComponent } from './components/user/user.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { UploudImageComponent } from './components/uploud-image/uploud-image.component';
import { DatesChartComponent } from './components/dates-chart/dates-chart.component';
import { GeneralDataComponent } from './components/general-data/general-data.component';


@NgModule({
  declarations: [
    AppComponent,
    UsersComponent,
    UserComponent,
    UploudImageComponent,
    DatesChartComponent,
    GeneralDataComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    RouterModule.forChild([
      {path:'users', component: UsersComponent},
      {path:'user/:id', component: UserComponent},
      { path: '', pathMatch: 'full', redirectTo: 'users' },
     {path:'generalData', component: GeneralDataComponent}

      

    ]),
    NgbModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
