import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UploudImageComponent } from './uploud-image.component';

describe('UploudImageComponent', () => {
  let component: UploudImageComponent;
  let fixture: ComponentFixture<UploudImageComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [UploudImageComponent]
    });
    fixture = TestBed.createComponent(UploudImageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
