import { HttpClient, HttpHeaders } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CookieService } from 'ngx-cookie-service';
import { environment } from '../../../../environments/environment.development';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root',
})
export class AuthService {

  private readonly httpClient = inject(HttpClient);
  private readonly cookieService = inject(CookieService);
  private readonly router = inject(Router);


  // ================= REGISTER =================
  registerForm(data: object): Observable<any> {
    return this.httpClient.post(
      `${environment.baseUrl}/Auth/register`,
      data
    );
  }

  // ================= ADMIN LOGIN =================
  loginForm(data: object): Observable<any> {
    return this.httpClient.post(
      `${environment.baseUrl}/Auth/Login`,
      data
    );
  }

  // ================= MEMBER LOGIN =================
  memberLogin(data: object): Observable<any> {

    const token = this.getToken();

    const headers = new HttpHeaders({
      Authorization: `Bearer ${token}`
    });

    return this.httpClient.post(
      `${environment.baseUrl}/Auth/MemberLogin`,
      data,
      { headers }
    );
  }

  // ================= SAVE USER =================
  saveUser(res: any, role: string): void {

    // token in cookie
    this.cookieService.set('token', res.token, 1);

    // localStorage data
    localStorage.setItem('role', role);
    localStorage.setItem('name', res.firstName || '');
    localStorage.setItem('email', res.email || '');
    localStorage.setItem('section', res.section || '');

    // refresh token optional
    if (res.refreshToken) {
      localStorage.setItem('refreshToken', res.refreshToken);
    }
  }

  // ================= GET TOKEN =================
  getToken(): string {
    return this.cookieService.get('token');
  }

  // ================= GET DATA =================
  getRole(): string | null {
    return localStorage.getItem('role');
  }

  getName(): string | null {
    return localStorage.getItem('name');
  }

  getEmail(): string | null {
    return localStorage.getItem('email');
  }

  getSection(): string | null {
    return localStorage.getItem('section');
  }

  // ================= CHECK LOGIN =================
  isLoggedIn(): boolean {
    return !!this.getToken();
  }

  isAdmin(): boolean {
    return this.getRole() === 'admin';
  }

  isEngineer(): boolean {
    return this.getRole() === 'engineer';
  }

  isHR(): boolean {
    return this.getRole() === 'hr';
  }

  // ================= LOGOUT =================
  logout(): void {

    this.cookieService.delete('token');

    localStorage.removeItem('role');
    localStorage.removeItem('name');
    localStorage.removeItem('email');
    localStorage.removeItem('section');
    localStorage.removeItem('refreshToken');

    this.router.navigate(['/login']);

  }
}