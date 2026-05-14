import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LandLayoutComponent } from './land-layout.component';

describe('LandLayoutComponent', () => {
  let component: LandLayoutComponent;
  let fixture: ComponentFixture<LandLayoutComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [LandLayoutComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LandLayoutComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
