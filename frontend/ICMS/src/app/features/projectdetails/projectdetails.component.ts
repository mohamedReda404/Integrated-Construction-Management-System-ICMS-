import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { HttpClient, HttpClientModule, HttpHeaders } from '@angular/common/http';

import { CookieService } from 'ngx-cookie-service';
import { Member } from '../../core/interfaces/member.interface';
import { Project } from '../../core/interfaces/project.interface';

@Component({
  selector: 'app-projectdetails',
  standalone: true,
  imports: [CommonModule, HttpClientModule, RouterModule],
  templateUrl: './projectdetails.component.html',
  styleUrl: './projectdetails.component.css',
})
export class ProjectdetailsComponent implements OnInit {
  private route = inject(ActivatedRoute);
  private http = inject(HttpClient);
  private cookie = inject(CookieService);

  projectId!: string;

  project: Project | null = null;

  isLoading = true;

  activeTab = 'consultants';

  consultants: Member[] = [];
  engineers: Member[] = [];
  subcontractors: Member[] = [];
  workers: Member[] = [];
  materialRequests: any[] = [];

  ngOnInit(): void {
    this.projectId = this.route.snapshot.paramMap.get('id')!;

    this.getProjectDetails();

    this.switchTab('consultants');
  }

  getHeaders(): HttpHeaders {
    const token = this.cookie.get('token');

    return new HttpHeaders({
      Authorization: `Bearer ${token}`,
    });
  }

  getProjectDetails(): void {
    this.isLoading = true;

    this.http
      .get<Project>(`https://localhost:7139/api/Projects/${this.projectId}`, {
        headers: this.getHeaders(),
      })
      .subscribe({
        next: (res) => {
          console.log(res);

          this.project = res;

          this.isLoading = false;
        },

        error: (err) => {
          console.log(err);

          this.isLoading = false;
        },
      });
  }

  switchTab(tab: string): void {
    this.activeTab = tab;

    // CONSULTANTS
    if (tab === 'consultants' && this.consultants.length === 0) {
      this.http
        .get<Member[]>(`https://localhost:7139/api/Memebers/ConsultantMembers`, {
          headers: this.getHeaders(),
        })
        .subscribe({
          next: (res) => {
            console.log('Consultants Response');
            console.log('First Consultant');
            console.log(res[0]);
            this.consultants = res || [];
          },

          error: (err) => {
            console.log(err);
          },
        });
    }

    // ENGINEERS
<<<<<<< HEAD
    if (tab === 'engineers' && this.engineers.length === 0) {
      this.http
        .get<Member[]>(`https://localhost:7139/api/Memebers/EngineerMembers`, {
          headers: this.getHeaders(),
        })
        .subscribe({
          next: (res) => {
            this.engineers = res || [];
          },
=======
    if (
      tab === 'engineers' &&
      this.engineers.length === 0                                                                                                                                                                                
    ) {
>>>>>>> 86f9c6aefee7aad2767fc27506dbad74de7c7ffa

          error: (err) => {
            console.log(err);
          },
        });
    }

    // SUBCONTRACTORS
    if (tab === 'subcontractors' && this.subcontractors.length === 0) {
      this.http
        .get<Member[]>(`https://localhost:7139/api/Projects/${this.projectId}/subcontractors`, {
          headers: this.getHeaders(),
        })
        .subscribe({
          next: (res) => {
            this.subcontractors = res || [];
          },

          error: (err) => {
            console.log(err);
          },
        });
    }

    // WORKERS
    if (tab === 'workers' && this.workers.length === 0) {
      this.http
        .get<Member[]>(`https://localhost:7139/api/Projects/${this.projectId}/workers`, {
          headers: this.getHeaders(),
        })
        .subscribe({
          next: (res) => {
            this.workers = res || [];
          },

          error: (err) => {
            console.log(err);
          },
        });
    }

    // MATERIAL REQUESTS
    if (tab === 'materials' && this.materialRequests.length === 0) {
      this.http
        .get<Member[]>(`https://localhost:7139/api/Projects/${this.projectId}/materialrequests`, {
          headers: this.getHeaders(),
        })
        .subscribe({
          next: (res) => {
            this.materialRequests = res || [];
          },

          error: (err) => {
            console.log(err);
          },
        });
    }
  }
}
