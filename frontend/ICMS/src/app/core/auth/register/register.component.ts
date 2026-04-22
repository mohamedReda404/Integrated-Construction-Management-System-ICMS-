import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { ReactiveFormsModule, FormGroup ,FormControl , Validators, AbstractControl, FormBuilder } from '@angular/forms';
import { Router, RouterModule } from '@angular/router';

@Component({
  selector: 'app-register',
  imports:  [ReactiveFormsModule , RouterModule , CommonModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css',
})
export class RegisterComponent {


  showPassword = false;
  showConfirmPassword = false;


  private readonly fb = inject(FormBuilder);
  private readonly router = inject(Router);




registerForm = this.fb.group({

  name : [null, [Validators.required , Validators.minLength(3) , Validators.maxLength(50)]],
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
  console.log(this.registerForm);
  console.log(this.registerForm.value);

  this.router.navigate(['/login']);

  this.registerForm.reset();
}


}
