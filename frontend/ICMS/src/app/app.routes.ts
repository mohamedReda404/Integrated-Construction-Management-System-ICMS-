import { Routes } from '@angular/router';

import { AuthLayoutComponent } from './core/layouts/auth-layout/auth-layout.component';
import { BlankLayoutComponent } from './core/layouts/blank-layout/blank-layout.component';
import { LandLayoutComponent } from './core/layouts/land-layout/land-layout.component';

import { LoginComponent } from './core/auth/login/login.component';
import { RegisterComponent } from './core/auth/register/register.component';

import { LandingComponent } from './features/landing/landing.component';
import { HomeComponent } from './features/home/home.component';
import { NotfoundComponent } from './features/notfound/notfound.component';
import { ProjectdetailsComponent } from './features/projectdetails/projectdetails.component';
import { SettingComponent } from './features/setting/setting.component';
import { DashboardComponent } from './features/dashboard/dashboard.component';
import { NewprojectComponent } from './features/newproject/newproject.component';
import { AllprojectComponent } from './features/allproject/allproject.component';
import { SubcontractorsComponent } from './features/subcontractors/subcontractors.component';
import { ConsultEngineeringComponent } from './features/consult-engineering/consult-engineering.component';
import { WorkersComponent } from './features/workers/workers.component';
import { UnauthorizedComponent } from './features/unauthorized/unauthorized.component';

import { authGuard } from './core/guards/auth-guard';
import { isLoggedGuard } from './core/guards/is-logged-guard';
import { roleGuard } from './core/guards/role-guard';

export const routes: Routes = [

  // ================= Redirect =================
  { path: '', redirectTo: 'landing', pathMatch: 'full' },

  // ================= Landing =================
  {
    path: '',
    component: LandLayoutComponent,
    children: [
      {
        path: 'landing',
        component: LandingComponent,
        title: 'Landing'
      }
    ]
  },

  // ================= Auth Pages =================
  {
    path: '',
    component: AuthLayoutComponent,
    canActivate: [isLoggedGuard],
    children: [
      {
        path: 'login',
        component: LoginComponent,
        title: 'Login'
      },
      {
        path: 'register',
        component: RegisterComponent,
        title: 'Register'
      }
    ]
  },

  // ================= Protected Pages =================
  {
    path: '',
    component: BlankLayoutComponent,
    canActivateChild: [authGuard],

    children: [

      {
        path: 'home',
        component: HomeComponent,
        title: 'Home'
      },

      {
        path: 'dashboard',
        component: DashboardComponent,
        title: 'Dashboard'
      },

      {
        path: 'projectdetails',
        component: ProjectdetailsComponent,
        title: 'Project Details'
      },

      {
        path: 'setting',
        component: SettingComponent,
        title: 'Settings'
      },

      {
        path: 'allprojects',
        component: AllprojectComponent,
        title: 'All Projects'
      },

      {
        path: 'newproject',
        component: NewprojectComponent,
        title: 'New Project',
        canActivate: [roleGuard],
        data: { roles: ['admin', 'engineer'] }
      },

      {
        path: 'workers',
        component: WorkersComponent,
        title: 'Workers',
        canActivate: [roleGuard],
        data: { roles: ['admin', 'hr'] }
      },

      {
        path: 'subcontractors',
        component: SubcontractorsComponent,
        title: 'Subcontractors',
        canActivate: [roleGuard],
        data: { roles: ['admin'] }
      },

      {
        path: 'consultengineering',
        component: ConsultEngineeringComponent,
        title: 'Consult Engineering',
        canActivate: [roleGuard],
        data: { roles: ['admin', 'engineer'] }
      }

    ]
  },

  // ================= Unauthorized =================
  {
    path: 'unauthorized',
    component: UnauthorizedComponent,
    title: 'Unauthorized'
  },

  // ================= 404 =================
  {
    path: '**',
    component: NotfoundComponent,
    title: 'Not Found'
  }

];