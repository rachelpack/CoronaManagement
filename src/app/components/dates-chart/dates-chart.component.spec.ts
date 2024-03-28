import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DatesChartComponent } from './dates-chart.component';

describe('DatesChartComponent', () => {
  let component: DatesChartComponent;
  let fixture: ComponentFixture<DatesChartComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DatesChartComponent]
    });
    fixture = TestBed.createComponent(DatesChartComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
