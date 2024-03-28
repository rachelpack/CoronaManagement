import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

import { Chart, CategoryScale, LinearScale, BarElement, Title, Tooltip, Legend, BarController } from 'chart.js';
import { Result } from 'src/app/types/result';
import { environment } from 'src/environments/environment';

Chart.register(CategoryScale, LinearScale, BarElement, Title, Tooltip, Legend, BarController);



@Component({
  selector: 'app-dates-chart',
  templateUrl: './dates-chart.component.html',
  styleUrls: ['./dates-chart.component.css']
})
export class DatesChartComponent implements OnInit {

  root: string = environment.rootUrl + "/GeneralInfo";
  datesActivePatients: any;

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getActivePatients();
  }

  getActivePatients() {
    this.http.get<Result>(this.root + "/getActivePatients").subscribe((res: Result) => {
      if (res.saveStatus == 1) {
        this.datesActivePatients = res.data;
        const labels = Object.keys(this.datesActivePatients).map(dateStr => new Date(dateStr).toLocaleDateString());
        const data = Object.values(this.datesActivePatients);
        this.createChart(labels, data);
      }
    })
  }

  createChart(labels: string[], data: any[]): void {
    
    const myChart = new Chart("myChart", {
      type: 'bar',
      data: {
        labels: labels,
        datasets: [{
          label: '# of Patients',
          data: data,
          backgroundColor: 'rgba(54, 162, 235, 0.2)',
          borderColor: 'rgba(54, 162, 235, 1)',
          borderWidth: 1
        }]
      },
      options: {
        scales: {
          y: {
            beginAtZero: true,
            ticks: {
              stepSize: 1,
              precision: 0
            }
          }
        }
      }
    });
  }
}


