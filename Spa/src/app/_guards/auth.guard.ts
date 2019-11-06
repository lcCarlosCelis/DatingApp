import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { JwtHelperService } from "@auth0/angular-jwt";

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private myRouter: Router) {}
  helper = new JwtHelperService();
  canActivate(): boolean {
    if(!this.helper.isTokenExpired(localStorage.getItem('Token')))
    {
      return true;
    }else {
      this.myRouter.navigate(['/home']);
    }
    
  }
  
}
