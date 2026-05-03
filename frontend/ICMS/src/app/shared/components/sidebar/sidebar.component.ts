import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink, RouterLinkActive } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-sidebar',
  standalone: true,
  imports: [CommonModule, RouterLink, RouterLinkActive],
  templateUrl: './sidebar.component.html'
})
export class SidebarComponent implements OnInit {

  role = '';
  menuItems: any[] = [];

  constructor(private cookie: CookieService) {}

  ngOnInit(): void {
    this.role = this.cookie.get('role');
    this.loadMenu();
  }

  loadMenu() {

    const common = [
      { label: 'Dashboard', link: '/dashboard', icon: 'fa-chart-line' },
      { label: 'Home', link: '/home', icon: 'fa-house' }
    ];

    const admin = [
      { label: 'New Project', link: '/newproject', icon: 'fa-folder-plus' },
      { label: 'All Projects', link: '/allprojects', icon: 'fa-folder-open' },
      { label: 'Workers', link: '/workers', icon: 'fa-users' },
      { label: 'Subcontractors', link: '/subcontractors', icon: 'fa-building' },
      { label: 'Settings', link: '/setting', icon: 'fa-gear' }
    ];

    const engineer = [
      { label: 'New Project', link: '/newproject', icon: 'fa-folder-plus' },
      { label: 'All Projects', link: '/allprojects', icon: 'fa-folder-open' },
      { label: 'Consult', link: '/consultengineering', icon: 'fa-helmet-safety' }
    ];

    const hr = [
      { label: 'Workers', link: '/workers', icon: 'fa-users' }
    ];

    if (this.role === 'admin') {
      this.menuItems = [...common, ...admin];
    }

    else if (this.role === 'engineer') {
      this.menuItems = [...common, ...engineer];
    }

    else if (this.role === 'hr') {
      this.menuItems = [...common, ...hr];
    }

    else {
      this.menuItems = common;
    }
  }
}