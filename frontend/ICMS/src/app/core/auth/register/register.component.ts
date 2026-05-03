import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { ReactiveFormsModule, FormGroup ,FormControl , Validators, AbstractControl, FormBuilder } from '@angular/forms';
import { Router, RouterModule } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-register',
  imports:  [ReactiveFormsModule , RouterModule , CommonModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css',
})
export class RegisterComponent {


  private readonly authService = inject(AuthService);
  msgError:string = "";
  isLoading:boolean = false;
  showPassword = false;
  showConfirmPassword = false;
  subscription:Subscription = new Subscription() ;

  private readonly fb = inject(FormBuilder);
  private readonly router = inject(Router);


registerForm = this.fb.group({

  name : ['', [Validators.required , Validators.minLength(3) , Validators.maxLength(50)]],
  email : [null, [Validators.required , Validators.email]],
  password : [null, [Validators.required , Validators.pattern(/^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$/)]],
  rePassword : [null, [Validators.required , Validators.pattern(/^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$/)]]

} , {validators : this.confirmPassword } );


confirmPassword(group : AbstractControl)
{
 return group.get('password')?.value  === group.get('rePassword')?.value ? null : {mismatch : true} ;
}


submitForm(): void {

  if (this.registerForm.invalid) {
    this.registerForm.markAllAsTouched();
    return;
  }
  this.subscription.unsubscribe();
  this.isLoading = true;

  const fullName = this.registerForm.get('name')?.value?.trim() || '';
  const parts = fullName.split(' ');
  const firstName = parts[0];
  const lastName = parts.slice(1).join(' ');
  const data = {
    email: this.registerForm.value.email,
    password: this.registerForm.value.password,
    firstName: firstName,
    lastName: lastName
  };

  console.log(data);

  this.subscription= this.authService.registerForm(data).subscribe({
    next: (res: any) => {
    if (res?.token) {
          console.log(res);
          this.router.navigate(['/login']);
          // localStorage.setItem('token', res.token);
          // this.router.navigate(['/home']);
          this.registerForm.reset();
  }
  this.isLoading = false;
},

    error: (err) => {
      console.log(err);
      this.msgError = err.error.descriptoin || 'An error occurred during registration.';
      this.isLoading = false;
    }
  });
}

}
