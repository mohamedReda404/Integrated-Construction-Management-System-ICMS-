import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ConsultEngineeringComponent } from './consult-engineering.component';

describe('ConsultEngineeringComponent', () => {
  let component: ConsultEngineeringComponent;
  let fixture: ComponentFixture<ConsultEngineeringComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ConsultEngineeringComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ConsultEngineeringComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
