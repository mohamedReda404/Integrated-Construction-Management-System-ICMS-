import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-setting',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './setting.component.html',
  styleUrl: './setting.component.css',
})
export class SettingComponent implements OnInit {

  private readonly http = inject(HttpClient);
  private readonly cookie = inject(CookieService);

  userData: any = null;

  ngOnInit(): void {
    this.loadUserInfo();
  }

  loadUserInfo(): void {

    const token = this.cookie.get('token');

    if (!token) return;

    const headers = new HttpHeaders({
      Authorization: `Bearer ${token}`
    });

    this.http.get<any>(
      'https://localhost:7139/me/Info',
      { headers }
    ).subscribe({

      next: (res) => {
        this.userData = res;
      },

      error: (err) => {
        console.error(err);
      }

    });
  }
  
}