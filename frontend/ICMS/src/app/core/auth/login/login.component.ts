import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { FormControl, FormGroup, Validators, ɵInternalFormsSharedModule, ReactiveFormsModule, FormBuilder } from '@angular/forms';
import { Router, RouterModule } from '@angular/router';
import { trigger, transition, style, animate } from '@angular/animations';

@Component({
  selector: 'app-login',
  imports: [ɵInternalFormsSharedModule, ReactiveFormsModule, RouterModule, CommonModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css',

  animations: [
    trigger('fadeSlide', [
      transition(':enter', [
        style({ opacity: 0, transform: 'translateY(15px)' }),
        animate('300ms ease-out', style({ opacity: 1, transform: 'translateY(0)' }))
      ]),
      transition(':leave', [
        animate('200ms ease-in', style({ opacity: 0, transform: 'translateY(10px)' }))
      ])
    ])
  ]
})

export class LoginComponent {

  userType: 'admin' | 'member' = 'admin';
  showPassword = false;

  private readonly fb = inject(FormBuilder);
  private readonly router = inject(Router);



  loginForm = this.fb.group({

    email: [null, [Validators.required, Validators.email]],
    password: [null, [Validators.required, Validators.pattern(/^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$/)]],
    role: [null],
    permissionNumber: [null]


  });

  setUserType(type: 'admin' | 'member') {
    this.userType = type;

    const role = this.loginForm.get('role');
    const perm = this.loginForm.get('permissionNumber');

    if (type === 'admin') {
      role?.clearValidators();
      perm?.clearValidators();

      role?.setValue(null);
      perm?.setValue(null);
    } else {
      role?.setValidators([
        Validators.required,
        Validators.minLength(3),
        Validators.pattern(/^[a-zA-Z\s]+$/)
      ]);

      perm?.setValidators([
        Validators.required,
        Validators.pattern(/^\d{4}$/)
      ]);
    }

    role?.updateValueAndValidity();
    perm?.updateValueAndValidity();
  }

  submitForm(): void {
    if (this.loginForm.invalid) {
      this.loginForm.markAllAsTouched();
      return;
    }

    const formValue = this.loginForm.value;

    let payload: any;

    if (this.userType === 'admin') {
      payload = {
        email: formValue.email,
        password: formValue.password
      };
    } else {
      payload = {
        email: formValue.email,
        password: formValue.password,
        role: formValue.role,
        permissionNumber: formValue.permissionNumber
      };
    }

    console.log('Payload:', payload);

    this.router.navigate(['/home']);
    this.loginForm.reset();
  }

  // submitForm(): void {

  //   if (this.loginForm.invalid) {

  //     this.loginForm.markAllAsTouched();
  //     return;
  //   }

  //   console.log(this.loginForm);
  //   console.log(this.loginForm.value);


  //   this.router.navigate(['/home']);


  //   this.loginForm.reset();
  // }



}
