import { CommonModule } from '@angular/common';
import { Component, OnInit, inject } from '@angular/core';
import { RouterLink, ActivatedRoute } from '@angular/router';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { CookieService } from 'ngx-cookie-service';
import { environment } from '../../../environments/environment.development';
import { FormsModule } from '@angular/forms';
import { AlertService } from '../../core/services/alert.service';
@Component({
  selector: 'app-consult-engineering',
  standalone: true,
  imports: [RouterLink, CommonModule, FormsModule],
  templateUrl: './consult-engineering.component.html',
  styleUrl: './consult-engineering.component.css',
})
export class ConsultEngineeringComponent implements OnInit {
  private readonly http = inject(HttpClient);
  private readonly cookie = inject(CookieService);
  private readonly route = inject(ActivatedRoute);

  // ================= STATES =================

  activeTab: 'boq' | 'drawing' | 'worker' = 'boq';
  projectId!: number;
  project: any = null;
  consultants: any[] = [];
  consultant: any = null;
  boqList: any[] = [];
  drawingList: any[] = [];
  workerList: any[] = [];
  isLoading = false;
  errorMsg = '';
  userRole = '';
  canManage = false;
  showDeleteModal = false;
  selectedBoqId!: number;
  showAddBoqModal = false;
  isEditMode = false;
  showAddDrawingModal = false;
  isEditDrawingMode = false;
  selectedDrawingId!: number;
  showDeleteDrawingModal = false;
  newBoq = {
    title: '',
    description: '',
    condetion: '',
    unit: '',
    section: '',
    quantity: '',
    type: '',
    date: '',
    file: '',
    projectId: 0,
    applicationUserId: '046649f4-2bbd-4890-be7b-6343cbdf948c',
  };

  newDrawing = {
    title: '',
    description: '',
    section: '',
    status: '',
    type: '',
    date: '',
    photo: '',
    projectId: 0,
    applicationUserId: '046649f4-2bbd-4890-be7b-6343cbdf948c',
  };

  // ================= INIT =================

  ngOnInit(): void {
    this.projectId = Number(this.route.snapshot.paramMap.get('id'));

    this.getProject();
    this.getConsultants();
    this.loadUserInfo();
    // APIs هتتربط بعدين
    this.getBOQs();
    this.getDrawings();
    // this.getWorkerRequests();

    console.log('BOQ:', this.boqList);
    console.log('Drawing:', this.drawingList);
    console.log('Worker:', this.workerList);
  }

  // ================= HEADERS =================

  getHeaders(): HttpHeaders {
    const token = this.cookie.get('token');

    return new HttpHeaders({
      Authorization: `Bearer ${token}`,
    });
  }

  // ================= PROJECT =================

  getProject(): void {
    this.http
      .get(`${environment.baseUrl}/api/Projects/${this.projectId}`, {
        headers: this.getHeaders(),
      })
      .subscribe({
        next: (res) => {
          console.log('Project:', res);

          this.project = res;
        },

        error: (err) => {
          console.log(err);
        },
      });
  }

  // ================= CONSULTANTS =================

  getConsultants(): void {
    this.http
      .get<any[]>(`${environment.baseUrl}/api/Memebers/ConsultantMembers`, {
        headers: this.getHeaders(),
      })
      .subscribe({
        next: (res) => {
          console.log(JSON.stringify(res[0], null, 2));
          this.consultants = res || [];

          if (this.consultants.length > 0) {
            this.consultant = this.consultants[0];
          }
        },

        error: (err) => {
          console.log(err);
        },
      });
  }

  // ================= TABS =================

  setTab(tab: 'boq' | 'drawing' | 'worker'): void {
    this.activeTab = tab;
  }

  // ================= FORMAT DATE =================

  formatDate(date: string): string {
    if (!date) return '';

    return new Date(date).toLocaleDateString('en-GB');
  }

  loadUserInfo(): void {
    this.http
      .get<any>(`${environment.baseUrl}/me/Info`, {
        headers: this.getHeaders(),
      })
      .subscribe({
        next: (res) => {
          this.userRole = res.role;

          this.canManage = res.role?.toLowerCase() === 'consultant';

          console.log('Role:', this.userRole);
          console.log('Can Manage:', this.canManage);
        },

        error: (err) => {
          console.log(err);
        },
      });
  }

  getBOQs(): void {
    this.http
      .get<any[]>(`${environment.baseUrl}/api/BOQs`, {
        headers: this.getHeaders(),
      })
      .subscribe({
        next: (res) => {
          console.log('BOQ Response:', res);

          this.boqList = res || [];
        },

        error: (err) => {
          console.log(err);
        },
      });
  }

  getDrawings(): void {
    this.http
      .get<any[]>(`${environment.baseUrl}/api/Drawings`, {
        headers: this.getHeaders(),
      })
      .subscribe({
        next: (res) => {
          console.log('Drawing Response:', res);

          this.drawingList = res || [];
        },

        error: (err) => {
          console.log(err);
        },
      });
  }

  getWorkerRequests(): void {
    this.http
      .get<any[]>(`${environment.baseUrl}/api/WorkerTasks`, {
        headers: this.getHeaders(),
      })
      .subscribe({
        next: (res) => {
          console.log('Worker Response:', res);

          this.workerList = res || [];
        },

        error: (err) => {
          console.log(err);
        },
      });
  }

  openAddBoqModal(): void {
    this.isEditMode = false;
    this.resetBoqForm();
    this.showAddBoqModal = true;
  }

  closeAddBoqModal(): void {
    this.resetBoqForm();
    this.showAddBoqModal = false;
  }

  addBOQ(): void {
    const body = {
      title: this.newBoq.title,
      description: this.newBoq.description,
      condetion: this.newBoq.condetion,
      unit: this.newBoq.unit,
      section: this.newBoq.section,
      quantity: String(this.newBoq.quantity),
      type: this.newBoq.type,
      date: this.newBoq.date,
      file: this.newBoq.file,

      projectId: this.projectId,

      applicationUserId:
        this.consultant?.id ||
        this.consultant?.applicationUserId ||
        '046649f4-2bbd-4890-be7b-6343cbdf948c',
    };

    console.log(body);

    this.http
      .post(`${environment.baseUrl}/api/BOQs`, body, {
        headers: this.getHeaders(),
      })
      .subscribe({
        next: (res) => {
          AlertService.success('BOQ added successfully');
          console.log('BOQ Added', res);
          console.log(JSON.stringify(body, null, 2));

          this.resetBoqForm();

          this.closeAddBoqModal();

          this.getBOQs();
        },

        error: (err) => {
          AlertService.error(err?.error?.errors?.Title?.[0] || 'Something went wrong');
        },
      });
  }

  openDeleteModal(id: number): void {
    this.selectedBoqId = id;
    this.showDeleteModal = true;
  }

  closeDeleteModal(): void {
    this.showDeleteModal = false;
  }

  confirmDeleteBOQ(): void {
    this.http
      .delete(`${environment.baseUrl}/api/BOQs/${this.selectedBoqId}`, {
        headers: this.getHeaders(),
      })
      .subscribe({
        next: () => {
          AlertService.success('BOQ deleted successfully');

          this.closeDeleteModal();

          this.getBOQs();
        },

        error: (err) => {
          AlertService.error(err?.error?.errors?.Title?.[0] || 'Something went wrong');
        },
      });
  }

  resetBoqForm(): void {
    this.newBoq = {
      title: '',
      description: '',
      condetion: '',
      unit: '',
      section: '',
      quantity: '',
      type: '',
      date: '',
      file: '',
      projectId: 0,
      applicationUserId: '046649f4-2bbd-4890-be7b-6343cbdf948c',
    };
  }

  openEditBoqModal(boq: any): void {
    this.isEditMode = true;

    this.selectedBoqId = boq.id;

    this.newBoq = {
      title: boq.title,
      description: boq.description,
      condetion: boq.condetion,
      unit: boq.unit,
      section: boq.section,
      quantity: boq.quantity,
      type: boq.type,
      date: boq.date,
      file: boq.file,

      projectId: boq.projectId,
      applicationUserId: boq.applicationUserId,
    };

    this.showAddBoqModal = true;
  }

  updateBOQ(): void {
    const body = {
      title: this.newBoq.title,
      description: this.newBoq.description,
      condetion: this.newBoq.condetion,
      unit: this.newBoq.unit,
      section: this.newBoq.section,
      quantity: String(this.newBoq.quantity),
      type: this.newBoq.type,
      date: this.newBoq.date,
      file: this.newBoq.file,

      projectId: this.projectId,

      applicationUserId: this.newBoq.applicationUserId || '046649f4-2bbd-4890-be7b-6343cbdf948c',
    };

    this.http
      .put(`${environment.baseUrl}/api/BOQs/${this.selectedBoqId}`, body, {
        headers: this.getHeaders(),
      })
      .subscribe({
        next: () => {
          AlertService.success('BOQ updated successfully');

          this.isEditMode = false;

          this.resetBoqForm();

          this.closeAddBoqModal();

          this.getBOQs();
        },

        error: (err) => {
          AlertService.error(err?.error?.errors?.Title?.[0] || 'Something went wrong');
        },
      });
  }

  openAddModal(): void {
    if (this.activeTab === 'boq') {
      this.openAddBoqModal();
    } else if (this.activeTab === 'drawing') {
      this.openAddDrawingModal();
    } else {
      // Worker Modal later
    }
  }

  openAddDrawingModal(): void {
    this.isEditDrawingMode = false;

    this.newDrawing = {
      title: '',
      description: '',
      section: '',
      status: '',
      type: '',
      date: '',
      photo: '',
      projectId: 0,
      applicationUserId: '',
    };

    this.showAddDrawingModal = true;

    console.log('Drawing Modal Opened');

    this.showAddDrawingModal = true;
  }

  closeAddDrawingModal(): void {
    this.showAddDrawingModal = false;
  }

  addDrawing(): void {
    const body = {
      title: this.newDrawing.title,
      description: this.newDrawing.description,
      section: this.newDrawing.section,
      status: this.newDrawing.status,
      type: this.newDrawing.type,
      date: this.newDrawing.date,
      photo: this.newDrawing.photo,

      projectId: this.projectId,

      applicationUserId:
        this.consultant?.applicationUserId || '046649f4-2bbd-4890-be7b-6343cbdf948c',
    };

    console.log(body);

    this.http
      .post(`${environment.baseUrl}/api/Drawings`, body, {
        headers: this.getHeaders(),
      })
      .subscribe({
        next: () => {
          AlertService.success('Drawing Added Successfully');

          this.closeAddDrawingModal();

          this.getDrawings();
        },

        error: (err) => {
          console.log(err);

          AlertService.error(err.error?.errors?.Title?.[0] || 'Failed To Add Drawing');
        },
      });
  }

  openEditDrawingModal(drawing: any): void {
    this.isEditDrawingMode = true;

    this.selectedDrawingId = drawing.id;

    this.newDrawing = {
      title: drawing.title,
      description: drawing.description,
      section: drawing.section,
      status: drawing.status,
      type: drawing.type,
      date: drawing.date,
      photo: drawing.photo,

      projectId: drawing.projectId,
      applicationUserId: drawing.applicationUserId,
    };

    this.showAddDrawingModal = true;
  }

  updateDrawing(): void {
    const body = {
      title: this.newDrawing.title,
      description: this.newDrawing.description,
      section: this.newDrawing.section,
      status: this.newDrawing.status,
      type: this.newDrawing.type,
      date: this.newDrawing.date,
      photo: this.newDrawing.photo,

      projectId: this.projectId,

      applicationUserId:
        this.newDrawing.applicationUserId || '046649f4-2bbd-4890-be7b-6343cbdf948c',
    };

    this.http
      .put(`${environment.baseUrl}/api/Drawings/${this.selectedDrawingId}`, body, {
        headers: this.getHeaders(),
      })
      .subscribe({
        next: () => {
          AlertService.success('Drawing Updated Successfully');

          this.closeAddDrawingModal();

          this.getDrawings();
        },

        error: (err) => {
          console.log(err);

          AlertService.error('Failed To Update Drawing');
        },
      });
  }

  deleteDrawing(id: number): void {
    this.http
      .delete(`${environment.baseUrl}/api/Drawings/${id}`, {
        headers: this.getHeaders(),
      })
      .subscribe({
        next: () => {
          AlertService.success('Drawing Deleted Successfully');

          this.getDrawings();
        },

        error: () => {
          AlertService.error('Failed To Delete Drawing');
        },
      });
  }

  openDeleteDrawingModal(id: number): void {
    this.selectedDrawingId = id;

    this.showDeleteDrawingModal = true;
  }

  closeDeleteDrawingModal(): void {
    this.showDeleteDrawingModal = false;
  }

  confirmDeleteDrawing(): void {
    this.http
      .delete(`${environment.baseUrl}/api/Drawings/${this.selectedDrawingId}`, {
        headers: this.getHeaders(),
      })
      .subscribe({
        next: () => {
          AlertService.success('Drawing Deleted Successfully');

          this.closeDeleteDrawingModal();

          this.getDrawings();
        },

        error: () => {
          AlertService.error('Failed To Delete Drawing');
        },
      });
  }
}
