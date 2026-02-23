import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewprojectComponent } from './newproject.component';

describe('NewprojectComponent', () => {
  let component: NewprojectComponent;
  let fixture: ComponentFixture<NewprojectComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [NewprojectComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(NewprojectComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
