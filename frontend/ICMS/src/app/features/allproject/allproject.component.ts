import { CommonModule } from '@angular/common';
import { Component, inject, OnInit } from '@angular/core';
import { RouterModule } from '@angular/router';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { CookieService } from 'ngx-cookie-service';
import { environment } from '../../../environments/environment.development';

@Component({
  selector: 'app-allproject',
  standalone: true,
  imports: [RouterModule, CommonModule],
  templateUrl: './allproject.component.html',
  styleUrl: './allproject.component.css',
})
export class AllprojectComponent implements OnInit {

  private readonly http = inject(HttpClient);
  private readonly cookie = inject(CookieService);

  // ================= STATES =================
  isLoading = true;
  errorMsg = '';

  projects: any[] = [];
  completedProjects: any[] = [];
  activeProjects: any[] = [];

  ngOnInit(): void {
    this.getProjects();
  }

  // ================= GET ALL PROJECTS =================
  getProjects(): void {

    const token = this.cookie.get('token');

    const headers = new HttpHeaders({
      Authorization: `Bearer ${token}`
    });

    this.http.get<any[]>(
      `${environment.baseUrl}/api/Projects`,
      { headers }
    ).subscribe({

      next: (res: any) => {

        this.projects = res || [];

        // تقسيم المشاريع
        const today = new Date();

        this.completedProjects = this.projects.filter(project =>
          new Date(project.endDate) < today
        );

        this.activeProjects = this.projects.filter(project =>
          new Date(project.endDate) >= today
        );

        this.isLoading = false;
      },

      error: (err) => {

        console.log(err);

        this.errorMsg = 'Failed To Load Projects';
        this.isLoading = false;
      }

    });
  }

  // ================= RANDOM PROGRESS =================
  getProgress(): number {
    return Math.floor(Math.random() * 70) + 20;
  }

}