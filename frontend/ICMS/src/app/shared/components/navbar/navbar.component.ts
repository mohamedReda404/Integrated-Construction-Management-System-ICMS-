import { AuthService } from './../../../core/auth/services/auth.service';
import { CommonModule } from '@angular/common';
import { Component, inject, Input, OnInit } from '@angular/core';
import { RouterModule } from '@angular/router';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [RouterModule, CommonModule],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css',
})
export class NavbarComponent implements OnInit {

  private readonly authService = inject(AuthService);
  private readonly http = inject(HttpClient);
  private readonly cookie = inject(CookieService);

  @Input({ required: true }) isLogin!: boolean;
  @Input({ required: true }) isLand!: boolean;

  isMobileOpen = false;
  currentLang: 'en' | 'ar' = 'en';
  isProfileOpen = false;

  // ===== USER DATA =====
  userData: any = null;

  // ===== THEME =====
  isDarkMode = false;

  ngOnInit(): void {

    // Load Theme
    this.initTheme();

    // Load User Info
    if (this.isLogin) {
      this.loadUserInfo();
    }
  }

  // ================= USER INFO =================
  loadUserInfo(): void {

    const token = this.cookie.get('token');

    if (!token) return;

    const headers = new HttpHeaders({
      Authorization: `Bearer ${token}`
    });

    this.http.get<any>(
      `https://localhost:7139/me/Info`,
      { headers }
    ).subscribe({

      next: (res) => {
        this.userData = res;
console.log('User Info Full');
console.log(JSON.stringify(res, null, 2));      },

      error: (err) => {
        console.error('Failed to load user info', err);
      }

    });
  }

  // ================= THEME SYSTEM =================

  toggleTheme(): void {

    document.body.classList.toggle('dark-mode');

    const isDark = document.body.classList.contains('dark-mode');

    localStorage.setItem('theme', isDark ? 'dark' : 'light');

    this.isDarkMode = isDark;
  }

  initTheme(): void {

    if (typeof window === 'undefined') return;

    const savedTheme = localStorage.getItem('theme');

    if (savedTheme === 'dark') {
      document.body.classList.add('dark-mode');
      this.isDarkMode = true;
    } else {
      document.body.classList.remove('dark-mode');
      this.isDarkMode = false;
    }
  }

  // ================= AUTH =================
  signOut(): void {
    this.authService.logout();
  }
}