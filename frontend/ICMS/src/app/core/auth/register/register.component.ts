import { Component, inject } from '@angular/core';
import { ReactiveFormsModule, FormGroup ,FormControl , Validators, AbstractControl, FormBuilder } from '@angular/forms';
import { Router, RouterModule } from '@angular/router';

@Component({
  selector: 'app-register',
  imports:  [ReactiveFormsModule , RouterModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css',
})
export class RegisterComponent {

  private readonly fb = inject(FormBuilder);
  private readonly router = inject(Router);


//  حرف صغير واحد على الأقل

// حرف كبير واحد على الأقل

// رقم واحد على الأقل

// رمز واحد على الأقل

// طول 8 أحرف أو أكثر


registerForm = this.fb.group({

  name : [null, [Validators.required , Validators.minLength(3) , Validators.maxLength(50)]],
  email : [null, [Validators.required , Validators.email]],
  password : [null, [Validators.required , Validators.pattern(/^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$/)]],
  rePassword : [null, [Validators.required , Validators.pattern(/^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$/)]]

} , {validators : this.confirmPassword } );


// registerForm : FormGroup = new FormGroup({

//   name : new FormControl(null, [Validators.required , Validators.minLength(3) , Validators.maxLength(50)]),
//   email : new FormControl(null, [Validators.required , Validators.email]),
//   password : new FormControl(null, [Validators.required , Validators.pattern(/^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$/)]),
//   rePassword : new FormControl(null, [Validators.required , Validators.pattern(/^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$/)]),

// } , {validators : this.confirmPassword } );

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



// submitForm():void
// {
//   if(this.registerForm.valid)
//   {
//     console.log(this.registerForm);
//     console.log(this.registerForm.value);

//     this.registerForm.reset();
//   }
  


// }



// const menuIcon = document.getElementById('menu-btn');
//         const mobileMenu = document.getElementById('mobileMenu');
        
//         menuIcon.addEventListener('click', () => {
//             mobileMenu.classList.toggle('hidden');
//             // Toggle icon between bars and X
//             if (mobileMenu.classList.contains('hidden')) {
//                 menuIcon.classList.remove('fa-times');
//                 menuIcon.classList.add('fa-bars');
//             } else {
//                 menuIcon.classList.remove('fa-bars');
//                 menuIcon.classList.add('fa-times');
//             }
//         });
        
//         // Close mobile menu when clicking outside
//         document.addEventListener('click', (e) => {
//             if (!menuIcon.contains(e.target) && !mobileMenu.contains(e.target)) {
//                 mobileMenu.classList.add('hidden');
//                 menuIcon.classList.remove('fa-times');
//                 menuIcon.classList.add('fa-bars');
//             }
//         });



}
