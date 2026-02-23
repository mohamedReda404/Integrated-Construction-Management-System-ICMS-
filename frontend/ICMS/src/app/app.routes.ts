import { Routes } from '@angular/router';
import { AuthLayoutComponent } from './core/layouts/auth-layout/auth-layout.component';
import { BlankLayoutComponent } from './core/layouts/blank-layout/blank-layout.component';
import { LoginComponent } from './core/auth/login/login.component';
import { RegisterComponent } from './core/auth/register/register.component';
import { LandingComponent } from './features/landing/landing.component';
import { HomeComponent } from './features/home/home.component';
import { NotfoundComponent } from './features/notfound/notfound.component';
import { ProjectdetailsComponent } from './features/projectdetails/projectdetails.component';
import { SettingComponent } from './features/setting/setting.component';
import { DashboardComponent } from './features/dashboard/dashboard.component';
import { LandLayoutComponent } from './core/layouts/land-layout/land-layout.component';
import { NewprojectComponent } from './features/newproject/newproject.component';
import { AllprojectComponent } from './features/allproject/allproject.component';
import { SubcontractorsComponent } from './features/subcontractors/subcontractors.component';

export const routes: Routes = [





    { path: '', redirectTo: 'landing', pathMatch: 'full' },
    {
        path: '', component: LandLayoutComponent, children: [
            { path: 'landing', component: LandingComponent, title: "Landing" }
        ]
    },
    {
        path: '', component: AuthLayoutComponent, children: [
            { path: 'login', component: LoginComponent, title: "Login" },
            { path: 'register', component: RegisterComponent, title: "Register" }
        ]
    },
    {
        path: '', component: BlankLayoutComponent, children: [
            { path: 'home', component: HomeComponent, title: "Home" },
            { path: 'projectdetails', component: ProjectdetailsComponent, title: "Project Details" },
            { path: 'setting', component: SettingComponent, title: " Settings" },
            { path: 'dashboard', component: DashboardComponent, title: "Dashboard" },
            { path: 'newproject', component: NewprojectComponent, title: "New Project" },
            { path: 'allprojects', component: AllprojectComponent, title: "All Projects" },
            { path: 'subcontractors', component: SubcontractorsComponent, title: "Subcontractors" },



        ]
    },
    { path: '**', component: NotfoundComponent, title: "Not Found Page" }














    // {path:'' , redirectTo:'landing' , pathMatch:'full'},
    // {path:'' , component : AuthLayoutComponent , children:[
    //     {path:'login' , component : LoginComponent , title:"Login"},
    //     {path:'register' , component : RegisterComponent , title:"Register"},
    //     {path:'landing' , component : LandingComponent , title:"Landing"}
    // ]},
    // {path:'' , component : BlankLayoutComponent , children:[
    //     {path:'home' , component : HomeComponent , title:"Home"},
    //     {path:'projectdetails' , component : ProjectdetailsComponent , title:"Project Details"},
    //     {path:'setting' , component : SettingComponent , title:" Settings"},
    //     {path:'dashboard' , component : DashboardComponent , title:"Dashboard"},
    // ]},
    // {path:'**' , component: NotfoundComponent , title:"Not Found Page"}
];
