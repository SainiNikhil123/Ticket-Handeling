import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService implements CanActivate {

  constructor(private route:Router, private jwtHelper: JwtHelperService) { }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> {
    const token = sessionStorage.getItem("jwt");
    const role = sessionStorage.getItem("role");

    if(token && !this.jwtHelper.isTokenExpired(token) && role == "User")
    {
      return true;
    }    
    else
    {
      alert("Not Authorized")
      this.route.navigate(["login"]);
      return false;
    }
  }
  
}
