import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Login } from '../Models/login';
import { User } from '../Models/user';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http:HttpClient) { }

  BaseUrl = "https://localhost:44393/api/User/";

  authenticate(login:Login):Observable<any>{
    return this.http.post<any>(this.BaseUrl + "Authenticate",login);
  }

  register(reg:User):Observable<any>{
    return this.http.post<any>(this.BaseUrl+"Register",reg);
  }

  getUser():Observable<any>{
    return this.http.get<any>(this.BaseUrl);
  }
}
