import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root'
})
export class DevService implements CanActivate{

  constructor(private route:Router, private jwtHelper: JwtHelperService) { }
  
  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> {
    const token = sessionStorage.getItem("jwt");
    const role = sessionStorage.getItem("role");

    if(token && !this.jwtHelper.isTokenExpired(token) && role == "Dev")
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
