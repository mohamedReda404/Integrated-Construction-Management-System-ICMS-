import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { ReactiveFormsModule, Validators, FormBuilder } from '@angular/forms';
import { Router, RouterModule } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { trigger, transition, style, animate } from '@angular/animations';
import { Subscription } from 'rxjs';
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-login',
  imports: [ReactiveFormsModule, RouterModule, CommonModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css',

  animations: [
    trigger('fadeSlide', [
      transition(':enter', [
        style({ opacity: 0, transform: 'translateY(15px)' }),
        animate(
          '300ms ease-out',
          style({ opacity: 1, transform: 'translateY(0)' })
        )
      ]),
      transition(':leave', [
        animate(
          '200ms ease-in',
          style({ opacity: 0, transform: 'translateY(10px)' })
        )
      ])
    ])
  ]
})
export class LoginComponent {

  showPassword = false;
  isLoading = false;
  msgError = '';
  subscription: Subscription = new Subscription();

  private readonly fb = inject(FormBuilder);
  private readonly router = inject(Router);
  private readonly authService = inject(AuthService);
  private readonly cookieService = inject(CookieService);

  userType: 'admin' | 'member' = 'admin';

  loginForm = this.fb.group({
    email: [
      null,
      [
        Validators.required,
        Validators.email
      ]
    ],

    password: [null],

    permissionNumber: [null],

    section: [null]
  });

  setUserType(type: 'admin' | 'member') {
    this.userType = type;

    const password = this.loginForm.get('password');
    const permissionNumber = this.loginForm.get('permissionNumber');
    const section = this.loginForm.get('section');

    if (type === 'admin') {

      password?.setValidators([
        Validators.required,
        Validators.pattern(
          /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&]).{8,}$/
        )
      ]);

      permissionNumber?.clearValidators();
      section?.clearValidators();

    } else {

      password?.clearValidators();

      permissionNumber?.setValidators([
        Validators.required
      ]);

      section?.setValidators([
        Validators.required
      ]);
    }

    password?.updateValueAndValidity();
    permissionNumber?.updateValueAndValidity();
    section?.updateValueAndValidity();
  }

  submitForm(): void {

    if (this.loginForm.invalid) {
      this.loginForm.markAllAsTouched();
      return;
    }

    this.subscription.unsubscribe();

    this.isLoading = true;
    this.msgError = '';

    // ================= ADMIN LOGIN =================
    if (this.userType === 'admin') {

      const payload = {
        email: this.loginForm.value.email,
        password: this.loginForm.value.password
      };

      this.subscription = this.authService.loginForm(payload).subscribe({

        next: (res: any) => {

          this.cookieService.set('token', res.token, 1);

          localStorage.setItem('role', 'admin');
          localStorage.setItem('name', res.firstName || '');
          localStorage.setItem('email', res.email || '');

          this.router.navigate(['/home']);

          this.loginForm.reset();
          this.isLoading = false;
        },

        error: (err) => {

          this.msgError =
            err.error?.description ||
            'Invalid admin credentials';

          this.isLoading = false;
        }

      });

    }

    // ================= MEMBER LOGIN =================
    else {

      const payload = {
        email: this.loginForm.value.email,
        permissionNumber: this.loginForm.value.permissionNumber,
        section: this.loginForm.value.section
      };

      this.subscription = this.authService.memberLogin(payload).subscribe({

        next: (res: any) => {

          this.cookieService.set('token', res.token, 1);

          localStorage.setItem('role', 'member');
          localStorage.setItem('name', res.firstName || '');
          localStorage.setItem('email', res.email || '');
          localStorage.setItem('section', this.loginForm.value.section || '');

          this.router.navigate(['/home']);

          this.loginForm.reset();
          this.isLoading = false;
        },

        error: (err) => {

          this.msgError =
            err.error?.description ||
            'Invalid member credentials';

          this.isLoading = false;
        }

      });

    }
  }
}