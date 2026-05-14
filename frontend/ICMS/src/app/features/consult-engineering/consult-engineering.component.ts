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
  selector: 'app-consult-engineering',
  standalone: true,
  imports: [RouterLink, ReactiveFormsModule, CommonModule],
  templateUrl: './consult-engineering.component.html',
  styleUrl: './consult-engineering.component.css'
})
export class ConsultEngineeringComponent {

  private readonly fb = inject(FormBuilder);
  private readonly http = inject(HttpClient);
  private readonly cookie = inject(CookieService);

  // ================= STATES =================
  activeTab: 'boq' | 'drawing' = 'boq';

  showModal = false;
  showDrawingModal = false;

  isLoading = false;

  successMsg = '';
  errorMsg = '';

  boqList: any[] = [];
  drawingList: any[] = [];

  selectedFileName = '';
  selectedDrawingFile = '';

  // ================= BOQ FORM =================
  boqForm: FormGroup = this.fb.group({

    title: ['', Validators.required],
    description: ['', Validators.required],
    unit: ['', Validators.required],
    condition: ['', Validators.required],
    quantity: ['', Validators.required],
    section: ['', Validators.required],
    type: ['', Validators.required],
    date: ['', Validators.required],
    file: [''],
    projectId: [2],
    applicationUserId: ['63391bb4-3da3-4ad8-99b4-1d15e18ea73e']

  });

  // ================= DRAWING FORM =================
  drawingForm: FormGroup = this.fb.group({

    title: ['', Validators.required],
    description: ['', Validators.required],
    section: ['', Validators.required],
    status: ['', Validators.required],
    type: ['', Validators.required],
    date: ['', Validators.required],
    file: ['']

  });

  // ================= TABS =================
  setTab(tab: 'boq' | 'drawing'): void {
    this.activeTab = tab;
  }

  // ================= BOQ MODAL =================
  openModal(): void {
    this.showModal = true;
  }

  closeModal(): void {

    this.showModal = false;

    this.boqForm.reset({
      projectId: 2,
      applicationUserId: '63391bb4-3da3-4ad8-99b4-1d15e18ea73e'
    });

    this.selectedFileName = '';
  }

  // ================= DRAWING MODAL =================
  openDrawingModal(): void {
    this.showDrawingModal = true;
  }

  closeDrawingModal(): void {

    this.showDrawingModal = false;

    this.drawingForm.reset();

    this.selectedDrawingFile = '';

  }

  // ================= FILES =================
  onFileSelected(event: any): void {

    const file = event.target.files[0];

    if (file) {

      this.selectedFileName = file.name;

      this.boqForm.patchValue({
        file: file.name
      });

    }
  }

  onDrawingFileSelected(event: any): void {

    const file = event.target.files[0];

    if (file) {

      this.selectedDrawingFile = file.name;

      this.drawingForm.patchValue({
        file: file.name
      });

    }
  }

  // ================= SUBMIT BOQ =================
  submitBOQ(): void {

    if (this.boqForm.invalid) {
      this.boqForm.markAllAsTouched();
      return;
    }

    this.isLoading = true;

    const token = this.cookie.get('token');

    const headers = new HttpHeaders({
      Authorization: `Bearer ${token}`
    });

    const payload = {
      title: this.boqForm.value.title,
      description: this.boqForm.value.description,
      unit: this.boqForm.value.unit,
      condition: this.boqForm.value.condition,
      quantity: this.boqForm.value.quantity,
      section: this.boqForm.value.section,
      type: this.boqForm.value.type,
      date: this.boqForm.value.date,
      file: this.boqForm.value.file || '',
      projectId: Number(this.boqForm.value.projectId),
      applicationUserId: this.boqForm.value.applicationUserId
    };

    this.http.post(
      `${environment.baseUrl}/api/BOQs`,
      payload,
      { headers }
    ).subscribe({

      next: () => {

        this.boqList.push(payload);

        this.isLoading = false;

        this.closeModal();

      },

      error: (err) => {

        console.log(err);

        this.isLoading = false;

      }

    });
  }

  // ================= SUBMIT DRAWING =================
  submitDrawing(): void {

    if (this.drawingForm.invalid) {
      this.drawingForm.markAllAsTouched();
      return;
    }

    this.isLoading = true;

    const payload = {
      title: this.drawingForm.value.title,
      description: this.drawingForm.value.description,
      section: this.drawingForm.value.section,
      status: this.drawingForm.value.status,
      type: this.drawingForm.value.type,
      date: this.drawingForm.value.date,
      file: this.drawingForm.value.file
    };

    setTimeout(() => {

      this.drawingList.push(payload);

      this.isLoading = false;

      this.closeDrawingModal();

    }, 700);
  }

}