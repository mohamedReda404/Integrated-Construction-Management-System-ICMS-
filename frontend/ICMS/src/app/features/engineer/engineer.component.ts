import { CommonModule } from '@angular/common';
import { Component, OnInit, inject } from '@angular/core';
import { RouterLink, ActivatedRoute } from '@angular/router';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { CookieService } from 'ngx-cookie-service';
import { environment } from '../../../environments/environment.development';
import { FormsModule } from '@angular/forms';
import { AlertService } from '../../core/services/alert.service';

@Component({
  selector: 'app-engineer',
  imports: [CommonModule, RouterLink, FormsModule],
  templateUrl: './engineer.component.html',
  styleUrl: './engineer.component.css',
})
export class EngineerComponent {
  private readonly http = inject(HttpClient);
  private readonly cookie = inject(CookieService);
  private readonly route = inject(ActivatedRoute);

  // ================= STATES =================

  activeTab: 'boq' | 'boqPrice' | 'invoice' | 'drawing' | 'material' = 'boq';
  projectId!: number;
  project: any = null;
  engineers: any[] = [];
  engineer: any = null;
  boqList: any[] = [];
  boqPriceList: any[] = [];
  invoiceList: any[] = [];
  materialList: any[] = [];
  drawingList: any[] = [];
  materialRequestList: any[] = [];
  isLoading = false;
  errorMsg = '';
  userRole = '';
  canManage = false;
  showDeleteModal = false;
  selectedBoqId!: number;
  showAddBoqModal = false;
  isEditMode = false;
  showAddDrawingModal = false;
  showAddBoqPriceModal = false;
  showAddInvoiceModal = false;
  isEditBoqPriceMode = false;
  selectedBoqPriceId!: number;
  isEditDrawingMode = false;
  selectedDrawingId!: number;
  showDeleteDrawingModal = false;
isEditInvoiceMode = false;
selectedInvoiceId!: number;
showDeleteInvoiceModal = false;
showAddMaterialRequestModal = false;
showDeleteMaterialRequestModal = false;
isEditMaterialRequestMode = false;
selectedMaterialRequestId!: number;


  
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

  newBoqPrice = {
  boqId: '',
  title: '',
  description: '',
  status: '',
  unitRate: '',
  totalPrice: '',
  date: '',
};

  newInvoice = {
    projectId: this.projectId,
    applicationUserId: '046649f4-2bbd-4890-be7b-6343cbdf948c',
    title: '',
    type: '',
    status: '',
    periodFrom: '',
    periodTo: '',
    invoiceDate: '',
    totalAmount: 0,
    file: ''
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

  newMaterialRequest = {
  projectId: this.projectId,
  applicationUserId: '046649f4-2bbd-4890-be7b-6343cbdf948c',
  title: '',
  description: '',
  status: '',
  notes: '',
  requestDate: '',
  requiredDate: '',
};


  // ================= INIT =================

  ngOnInit(): void {
    this.projectId = Number(this.route.snapshot.paramMap.get('id'));

    this.getProject();
    this.getEngineers();
    this.loadUserInfo();
    this.getBOQs();
    this.getBOQPrices();
    this.getDrawings();
    this.getInvoices();
    console.log('BOQ:', this.boqList);
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

  // ================= ENGINEERS =================

  getEngineers(): void {
    this.http
      .get<any[]>(`${environment.baseUrl}/api/Memebers/EngineerMembers`, {
        headers: this.getHeaders(),
      })
      .subscribe({
        next: (res) => {
          this.engineers = res || [];

          if (this.engineers.length > 0) {
            this.engineer = this.engineers[0];
          }
        },

        error: (err) => {
          console.log(err);
        },
      });
  }

  // ================= TABS =================

  setTab(tab: 'boq' | 'boqPrice' | 'invoice' | 'drawing' | 'material'): void {
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

          this.engineer = res;

          this.canManage = res.role?.toLowerCase() === 'engineer';

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

  getBOQPrices(): void {
  console.log('BASE URL =', environment.baseUrl);

  this.http
    .get<any[]>(`${environment.baseUrl}/api/BOQsPricing`, {
      headers: this.getHeaders(),
    })
    .subscribe({
      next: (res) => {
        console.log('BOQ Price Response:', res);
        this.boqPriceList = res || [];
      },
      error: (err) => {
        console.log(err);
      },
    });
}
  // getBOQPrices(): void {
  //   this.http
  //     .get<any[]>(`${environment.baseUrl}/api/BOQsPricing`, {
  //       headers: this.getHeaders(),
  //     })
  //     .subscribe({
  //       next: (res) => {
  //         console.log('BOQ Price Response:', res);
  //         this.boqPriceList = res || [];
  //       },

  //       error: (err) => {
  //         console.log(err);
  //       },
  //     });
  // }

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

  openAddBoqModal(): void {
    this.isEditMode = false;
    this.resetBoqForm();
    this.showAddBoqModal = true;
  }

  closeAddBoqModal(): void {
    this.resetBoqForm();
    this.showAddBoqModal = false;
  }

 openAddBoqPriceModal(): void {
  // this.newBoqPrice.boqId = boqId;
  console.log('BOQ PRICE MODAL OPEN');
  this.showAddBoqPriceModal = true;
}

  closeAddBoqPriceModal(): void {
    this.showAddBoqPriceModal = false;
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
        this.engineer?.id ||
        this.engineer?.applicationUserId ||
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

  addBOQPrice(): void {
  const body = {
    boqId: this.newBoqPrice.boqId,
    title: this.newBoqPrice.title,
    description: this.newBoqPrice.description,
    status: this.newBoqPrice.status,
    unitRate: this.newBoqPrice.unitRate,
    totalPrice: this.newBoqPrice.totalPrice,
    date: this.newBoqPrice.date,
  };

  console.log('BOQ ID =>', this.newBoqPrice.boqId);

    this.http
      .post(`${environment.baseUrl}/api/BOQsPricing`, body, {
        headers: this.getHeaders(),
      })
      .subscribe({
        next: () => {
          this.getBOQPrices();

          this.closeAddBoqPriceModal();

          this.newBoqPrice = {
            boqId: '',
            // applicationUserId: '046649f4-2bbd-4890-be7b-6343cbdf948c',
            title: '',
            description: '',
            status: '',
            unitRate: '',
            totalPrice: '',
            date: '',
          };

          AlertService.success('BOQ Price added successfully');
        },

        error: (err) => {
          console.log(err);
          AlertService.error('Failed to add BOQ Price');
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
  }

  else if (this.activeTab === 'boqPrice') {
    this.openAddBoqPriceModal();
  }

  else if (this.activeTab === 'invoice') {
    this.openAddInvoiceModal();
  }

  else if (this.activeTab === 'drawing') {
    this.openAddDrawingModal();
  }

  else if (this.activeTab === 'material') {
  this.openAddMaterialRequestModal();
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

      applicationUserId: this.engineer?.applicationUserId || '046649f4-2bbd-4890-be7b-6343cbdf948c',
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

  getInvoices(): void {
  this.http
    .get<any[]>(`${environment.baseUrl}/api/Invoices`, {
      headers: this.getHeaders(),
    })
    .subscribe({
      next: (res) => {
        console.log('Invoice Response:', res);

        this.invoiceList = res || [];
      },

      error: (err) => {
        console.log(err);
      },
    });
}
openAddInvoiceModal(): void {

    console.log('Invoice Modal Open');

  this.showAddInvoiceModal = true;

  this.newInvoice.projectId = this.projectId;
}

closeAddInvoiceModal(): void {
  this.showAddInvoiceModal = false;
}

addInvoice(): void {
  
  const body = {
    projectId: this.projectId,
    applicationUserId: '046649f4-2bbd-4890-be7b-6343cbdf948c',
    title: this.newInvoice.title,
    type: this.newInvoice.type,
    status: this.newInvoice.status,
    periodFrom: this.newInvoice.periodFrom,
    periodTo: this.newInvoice.periodTo,
    invoiceDate: this.newInvoice.invoiceDate,
    totalAmount: this.newInvoice.totalAmount,
    file: this.newInvoice.file
  };

  this.http.post(
    `${environment.baseUrl}/api/Invoices`,
    body,
    { headers: this.getHeaders() }
  ).subscribe({

    next: () => {

      AlertService.success(        'Invoice added successfully'      );

      this.closeAddInvoiceModal();

      this.getInvoices();
    },

    error: (err) => {

      console.log(err);

      AlertService.error(
        'Failed to add Invoice'
      );
    }
  });
}

openEditInvoiceModal(invoice: any): void {

  this.isEditInvoiceMode = true;

  this.selectedInvoiceId = invoice.id;

  this.newInvoice = {
    projectId: invoice.projectId,
    applicationUserId: invoice.applicationUserId,
    title: invoice.title,
    type: invoice.type,
    status: invoice.status,
    periodFrom: invoice.periodFrom,
    periodTo: invoice.periodTo,
    invoiceDate: invoice.invoiceDate,
    totalAmount: invoice.totalAmount,
    file: invoice.file
  };

  this.showAddInvoiceModal = true;
}

openDeleteInvoiceModal(id: number): void {
  this.selectedInvoiceId = id;

  this.showDeleteInvoiceModal = true;
}

closeDeleteInvoiceModal(): void {
  this.showDeleteInvoiceModal = false;
}

confirmDeleteInvoice(): void {
  this.http
    .delete(`${environment.baseUrl}/api/Invoices/${this.selectedInvoiceId}`, {
      headers: this.getHeaders(),
    })
    .subscribe({
      next: () => {
        AlertService.success('Invoice Deleted Successfully');

        this.closeDeleteInvoiceModal();

        this.getInvoices();
      },

      error: () => {
        AlertService.error('Failed To Delete Invoice');
      },
    });
}

getMaterialRequests(): void {
  this.http
    .get<any[]>(`${environment.baseUrl}/api/MaterialRequest`, {
      headers: this.getHeaders(),
    })
    .subscribe({
      next: (res) => {
        console.log('Material Request Response:', res);

        this.materialRequestList = res || [];
      },

      error: (err) => {
        console.log(err);
      },
    });
}

openAddMaterialRequestModal(): void {

  this.isEditMaterialRequestMode = false;

  this.newMaterialRequest = {
    projectId: this.projectId,
    applicationUserId: '',
    title: '',
    description: '',
    status: '',
    notes: '',
    requestDate: '',
    requiredDate: '',
  };

  this.showAddMaterialRequestModal = true;
}

closeAddMaterialRequestModal(): void {
  this.showAddMaterialRequestModal = false;
}

addMaterialRequest(): void {

    console.log('ADD MATERIAL CLICKED');

  const body = {
    projectId: this.projectId,
    applicationUserId:
      this.engineer?.applicationUserId ||
      '046649f4-2bbd-4890-be7b-6343cbdf948c',

    title: this.newMaterialRequest.title,
    description: this.newMaterialRequest.description,
    status: this.newMaterialRequest.status,
    notes: this.newMaterialRequest.notes,
    requestDate: this.newMaterialRequest.requestDate,
    requiredDate: this.newMaterialRequest.requiredDate,
  };

  this.http
    .post(`${environment.baseUrl}/api/MaterialRequest`, body, {
      headers: this.getHeaders(),
    })
    .subscribe({
      next: () => {

        AlertService.success(
          'Material Request Added Successfully'
        );

        this.closeAddMaterialRequestModal();

        this.getMaterialRequests();
      },

      error: (err) => {

        console.log(err);

        AlertService.error(
          'Failed To Add Material Request'
        );
      },
    });
}

openDeleteMaterialRequestModal(id: number): void {

  this.selectedMaterialRequestId = id;

  this.showDeleteMaterialRequestModal = true;
}

closeDeleteMaterialRequestModal(): void {
  this.showDeleteMaterialRequestModal = false;
}

confirmDeleteMaterialRequest(): void {

  this.http
    .delete(
      `${environment.baseUrl}/api/MaterialRequest/${this.selectedMaterialRequestId}`,
      {
        headers: this.getHeaders(),
      }
    )
    .subscribe({
      next: () => {

        AlertService.success(
          'Material Request Deleted Successfully'
        );

        this.closeDeleteMaterialRequestModal();

        this.getMaterialRequests();
      },

      error: () => {

        AlertService.error(
          'Failed To Delete Material Request'
        );
      },
    });
}

updateMaterialRequest(): void {

  const body = {
    projectId: this.projectId,

    applicationUserId:
      this.newMaterialRequest.applicationUserId ||
      this.engineer?.applicationUserId ||
      '046649f4-2bbd-4890-be7b-6343cbdf948c',

    title: this.newMaterialRequest.title,
    description: this.newMaterialRequest.description,
    status: this.newMaterialRequest.status,
    notes: this.newMaterialRequest.notes,
    requestDate: this.newMaterialRequest.requestDate,
    requiredDate: this.newMaterialRequest.requiredDate,
  };

  this.http
    .put(
      `${environment.baseUrl}/api/MaterialRequests/${this.selectedMaterialRequestId}`,
      body,
      {
        headers: this.getHeaders(),
      }
    )
    .subscribe({
      next: () => {

        AlertService.success(
          'Material Request Updated Successfully'
        );

        this.closeAddMaterialRequestModal();

        this.getMaterialRequests();
      },

      error: (err) => {

        console.log(err);

        AlertService.error(
          'Failed To Update Material Request'
        );
      },
    });
}

openEditMaterialRequestModal(material: any): void {

  this.isEditMaterialRequestMode = true;

  this.selectedMaterialRequestId = material.id;

  this.newMaterialRequest = {
    projectId: material.projectId,
    applicationUserId: material.applicationUserId,
    title: material.title,
    description: material.description,
    status: material.status,
    notes: material.notes,
    requestDate: material.requestDate,
    requiredDate: material.requiredDate,
  };

  this.showAddMaterialRequestModal = true;
}












}
