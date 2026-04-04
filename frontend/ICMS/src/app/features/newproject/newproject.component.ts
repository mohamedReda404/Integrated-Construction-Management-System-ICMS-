import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { RouterLink, RouterModule } from "@angular/router";

@Component({
  selector: 'app-newproject',
  imports: [RouterLink, ReactiveFormsModule , CommonModule],
  templateUrl: './newproject.component.html',
  styleUrl: './newproject.component.css',
})
export class NewprojectComponent {

projectForm: FormGroup;

  constructor(private fb: FormBuilder) {

    this.projectForm = this.fb.group({
      projectName: ['', Validators.required],
      description: [''],
      startDate: ['', Validators.required],
      endDate: ['', Validators.required],
      budget: [''],
      location: [''],
      category: [''],

      teamMember: this.fb.group({
        fullName: ['', Validators.required],
        role: ['', Validators.required],
        email: ['', [Validators.required, Validators.email]],
        phone: ['', Validators.required]
      })
    });

  }

  onSubmit() {
    if (this.projectForm.valid) {
      console.log(this.projectForm.value);
    } else {
      this.projectForm.markAllAsTouched();
    }
  }


  get projectDuration() {
  const start = this.projectForm.value.startDate;
  const end = this.projectForm.value.endDate;

  if (!start || !end) return null;

  const diff = new Date(end).getTime() - new Date(start).getTime();
  return Math.ceil(diff / (1000 * 60 * 60 * 24));
}


}
