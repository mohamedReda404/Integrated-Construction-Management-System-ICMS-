import { CommonModule } from '@angular/common';
import { Component, inject, OnInit } from '@angular/core';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { CookieService } from 'ngx-cookie-service';
import { environment } from '../../../environments/environment.development';

@Component({
  selector: 'app-projectdetails',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './projectdetails.component.html',
  styleUrl: './projectdetails.component.css',
})
export class ProjectdetailsComponent implements OnInit {

  private readonly http = inject(HttpClient);
  private readonly route = inject(ActivatedRoute);
  private readonly cookie = inject(CookieService);

  isLoading = true;
  errorMsg = '';
  userRole = 'user';
  activeTab = 'consultants';
  project: any = null;

  consultants: any[] = [];
  engineers: any[] = [];
  subcontractors: any[] = [];
  workers: any[] = [];
  materialRequests: any[] = [];

  ngOnInit(): void {
    this.getUserRole();
    this.loadProject();
  }

  switchTab(tab: string): void {
    this.activeTab = tab;
  }

  private getUserRole(): void {
    this.userRole = localStorage.getItem('role') || 'user';
  }

  private loadProject(): void {
    const id = this.route.snapshot.paramMap.get('id');

    if (!id) {
      this.errorMsg = 'Invalid project ID';
      this.isLoading = false;
      return;
    }

    const token = this.cookie.get('token');
    const headers = new HttpHeaders({
      Authorization: `Bearer ${token}`
    });

    this.http.get<any>(
      `${environment.baseUrl}/api/Projects/${id}`,
      { headers }
    ).subscribe({
      next: (res: any) => {
        this.project = res;
        this.isLoading = false;
      },
      error: (err) => {
        console.error(err);
        this.errorMsg = 'Failed To Load Project';
        this.isLoading = false;
      }
    });
  }

}
