import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators
} from '@angular/forms';
import { RouterLink } from '@angular/router';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { CookieService } from 'ngx-cookie-service';
import { environment } from '../../../environments/environment.development';

@Component({
  selector: 'app-newproject',
  standalone: true,
  imports: [RouterLink, ReactiveFormsModule, CommonModule],
  templateUrl: './newproject.component.html',
  styleUrl: './newproject.component.css',
})
export class NewprojectComponent {

  private readonly fb = inject(FormBuilder);
  private readonly http = inject(HttpClient);
  private readonly cookie = inject(CookieService);

  // ================= STATES =================
  isProjectCreated = false;
  isLoadingProject = false;
  isLoadingMember = false;

  successMsg = '';
  errorMsg = '';

  // ================= PROJECT FORM =================
  projectForm: FormGroup = this.fb.group({
    projectName: ['', Validators.required],
    description: [''],
    startDate: ['', Validators.required],
    endDate: ['', Validators.required],
    budget: [''],
    location: [''],
    category: [''],
    clientName: ['', Validators.required],
    photo: ['']
  });

  // ================= MEMBER FORM =================
  memberForm: FormGroup = this.fb.group({
    email: ['', [Validators.required, Validators.email]],
    permissionNumber: ['', Validators.required],
    firstName: ['', Validators.required],
    lastName: ['', Validators.required],
    section: ['', Validators.required],
    role: ['', Validators.required]
  });

  // ================= CREATE PROJECT =================
  onSubmit() {

    console.log('Clicked Submit');
    console.log('Form Value:', this.projectForm.value);
    console.log('Form Valid:', this.projectForm.valid);

    if (this.projectForm.invalid) {

      this.projectForm.markAllAsTouched();

      Object.keys(this.projectForm.controls).forEach(key => {
        const control = this.projectForm.get(key);

        if (control?.invalid) {
          console.log(`${key} is invalid`);
        }
      });

      return;
    }

    this.isLoadingProject = true;
    this.successMsg = '';
    this.errorMsg = '';

    const token = this.cookie.get('token');

    const headers = new HttpHeaders({
      Authorization: `Bearer ${token}`
    });

    const payload = {
      name: this.projectForm.value.projectName,
      location: this.projectForm.value.location,
      descritpion: this.projectForm.value.description,
      category: this.projectForm.value.category,
      clientName: this.projectForm.value.clientName,
      contractValue: this.projectForm.value.budget || 0,
      photo:
        this.projectForm.value.photo ||
        'https://example.com/project.jpg',
      startDate: this.projectForm.value.startDate,
      endDate: this.projectForm.value.endDate
    };

    console.log('Payload:', payload);

    this.http.post(
      `${environment.baseUrl}/api/Projects`,
      payload,
      { headers }
    ).subscribe({

      next: (res: any) => {

        console.log('SUCCESS:', res);

        this.isLoadingProject = false;
        this.isProjectCreated = true;
        this.successMsg = 'Project Created Successfully';
        this.projectForm.reset();

      },

      error: (err) => {

        console.log('ERROR:', err);

        this.isLoadingProject = false;
        this.errorMsg = 'Failed To Create Project';

      }

    });
  }

  // ================= ADD MEMBER =================
  addMember() {

    if (this.memberForm.invalid) {
      this.memberForm.markAllAsTouched();
      return;
    }

    this.isLoadingMember = true;
    this.successMsg = '';
    this.errorMsg = '';

    const token = this.cookie.get('token');

    const headers = new HttpHeaders({
      Authorization: `Bearer ${token}`
    });

    const payload = {
      email: this.memberForm.value.email,
      permissionNumber: this.memberForm.value.permissionNumber,
      firstName: this.memberForm.value.firstName,
      lastName: this.memberForm.value.lastName,
      section: this.memberForm.value.section,
      role: this.memberForm.value.role
    };

    this.http.post(
`${environment.baseUrl}/api/Memebers/AddMembers`,
payload,
{ headers }

    ).subscribe({

      next: (res: any) => {

        this.isLoadingMember = false;
        this.successMsg = 'Member Added Successfully';
        this.memberForm.reset();

      },

      error: (err) => {

        console.log(err);

        this.isLoadingMember = false;
        this.errorMsg = 'Failed To Add Member';

      }

    });
  }

  // ================= PROJECT DURATION =================
  get projectDuration() {

    const start = this.projectForm.value.startDate;
    const end = this.projectForm.value.endDate;

    if (!start || !end) return null;

    const diff =
      new Date(end).getTime() - new Date(start).getTime();

    return Math.ceil(diff / (1000 * 60 * 60 * 24));
  }

}