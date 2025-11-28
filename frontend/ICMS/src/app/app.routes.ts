import { Routes } from '@angular/router';
import { AuthLayoutComponent } from './core/layouts/auth-layout/auth-layout.component';
import { BlankLayoutComponent } from './core/layouts/blank-layout/blank-layout.component';
import { LoginComponent } from './core/auth/login/login.component';
import { RegisterComponent } from './core/auth/register/register.component';
import { LandingComponent } from './features/landing/landing.component';
import { HomeComponent } from './features/home/home.component';
import { NotfoundComponent } from './features/notfound/notfound.component';

export const routes: Routes = [
    {path:'' , redirectTo:'landing' , pathMatch:'full'},
    {path:'' , component : AuthLayoutComponent , children:[
        {path:'login' , component : LoginComponent , title:"Login"},
        {path:'register' , component : RegisterComponent , title:"Register"},
        {path:'landing' , component : LandingComponent , title:"Landing"}
    ]},
    {path:'' , component : BlankLayoutComponent , children:[
        {path:'home' , component : HomeComponent , title:"Home"}
    ]},
    {path:'**' , component: NotfoundComponent , title:"Not Found Page"}
];
