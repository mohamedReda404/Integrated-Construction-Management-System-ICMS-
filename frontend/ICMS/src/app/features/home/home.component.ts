import { Component, OnInit, inject } from '@angular/core';
import { RouterLink, RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [RouterLink, RouterModule, CommonModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css',
})
export class HomeComponent implements OnInit {

  private readonly http = inject(HttpClient);
  private readonly cookie = inject(CookieService);

  // ===== USER =====
  userName: string = 'User';
userRole: string = '';
  // ===== COUNTS =====
  projectsCount: number = 0;
  
  membersCount: number = 0;
  completedProjectsCount: number = 0;

  // ===== PROJECTS =====
  latestProjects: any[] = [];

  ngOnInit(): void {
    this.loadUserInfo();
    this.loadMembersCount();
    this.loadCompletedProjects();
    this.loadLatestProjects();
    this.loadActiveProjects();
  }

  // ================= HELPER (ADDED ONLY) =================
  private getHeaders(): HttpHeaders {
    const token = this.cookie.get('token');

    return new HttpHeaders({
      Authorization: `Bearer ${token}`
    });
  }

  // ================= USER INFO =================
  loadUserInfo(): void {

    const token = this.cookie.get('token');
    if (!token) return;

    const headers = new HttpHeaders({
      Authorization: `Bearer ${token}`
    });

    this.http.get<any>('https://localhost:7139/me/Info', { headers })
      .subscribe({
        next: (res) => {
          this.userName = `${res.firstName} ${res.lastName}`;
          this.userRole = res.role;
        },
        error: () => {
          this.userName = 'User';
          this.userRole = '';
        }
      });
  }

  // ================= PROJECTS COUNT =================
activeProjectsCount = 0;

loadActiveProjects(): void {

  const headers = this.getHeaders();

  this.http.get<any[]>(
    'https://localhost:7139/api/Projects/Active',
    { headers }
  ).subscribe({

    next: (res) => {

      this.activeProjectsCount = res.length;

    },

    error: () => {

      this.activeProjectsCount = 0;

    }

  });

}

  // ================= MEMBERS COUNT =================
  loadMembersCount(): void {

    const token = this.cookie.get('token');
    if (!token) return;

    const headers = new HttpHeaders({
      Authorization: `Bearer ${token}`
    });

    this.http.get<any>('https://localhost:7139/api/Memebers/Count', { headers })
      .subscribe({
        next: (res) => {
          this.membersCount =
            typeof res === 'number' ? res : res?.count ?? 0;
        },
        error: () => {
          this.membersCount = 0;
        }
      });
  }




  // ================= COMPLETED PROJECTS =================
loadCompletedProjects(): void {

  const headers = this.getHeaders();

  this.http.get<number>(
    'https://localhost:7139/api/Projects/Completed',
    { headers }
  ).subscribe({

    next: (res) => {

      this.completedProjectsCount = res;

    },

    error: () => {

      this.completedProjectsCount = 0;

    }

  });

}
  // ================= LATEST 5 PROJECTS =================
  loadLatestProjects(): void {

    const token = this.cookie.get('token');
    if (!token) return;

    const headers = new HttpHeaders({
      Authorization: `Bearer ${token}`
    });

    this.http.get<any[]>('https://localhost:7139/api/Projects', { headers })
      .subscribe({
        next: (res) => {
          this.latestProjects = (res || []).slice(0, 3);
        },
        error: () => {
          this.latestProjects = [];
        }
      });
  }
}