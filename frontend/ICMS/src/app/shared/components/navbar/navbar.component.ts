import { AuthService } from './../../../core/auth/services/auth.service';
import { CommonModule } from '@angular/common';
import { Component, inject, Input } from '@angular/core';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-navbar',
  imports: [RouterModule, CommonModule],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css',
})
export class NavbarComponent {

  private readonly authService = inject(AuthService);

  @Input({ required: true }) isLogin!: boolean
  @Input({ required: true }) isLand!: boolean

  isMobileOpen = false;
  currentLang: 'en' | 'ar' = 'en';
  isProfileOpen = false;

signOut(): void {

    this.authService.logout();

}

}
