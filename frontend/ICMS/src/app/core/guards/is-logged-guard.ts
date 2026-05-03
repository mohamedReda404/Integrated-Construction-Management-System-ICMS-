import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';

export const isLoggedGuard: CanActivateFn = (route, state) => {

   const cookieService = inject(CookieService);
  const router = inject(Router);

  if (cookieService.get('token')) {
    return router.parseUrl('/home');
  }
  else {
    return true;
  }



};
