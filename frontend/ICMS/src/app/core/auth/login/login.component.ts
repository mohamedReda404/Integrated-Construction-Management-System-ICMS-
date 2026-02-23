import { Component, inject } from '@angular/core';
import { FormControl, FormGroup, Validators, ɵInternalFormsSharedModule, ReactiveFormsModule, FormBuilder } from '@angular/forms';
import { Router, RouterModule } from '@angular/router';

@Component({
  selector: 'app-login',
  imports: [ɵInternalFormsSharedModule, ReactiveFormsModule ,RouterModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css',
})
export class LoginComponent {

  private readonly fb = inject(FormBuilder);
  private readonly router = inject(Router);



  loginForm = this.fb.group({

  email : [null, [Validators.required , Validators.email]],
  password : [null, [Validators.required , Validators.pattern(/^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$/)]],

});



submitForm(): void {

  if (this.loginForm.invalid) {

    this.loginForm.markAllAsTouched();
    return;
  }

  console.log(this.loginForm);
  console.log(this.loginForm.value);


  this.router.navigate(['/home']);


  this.loginForm.reset();
}



}
