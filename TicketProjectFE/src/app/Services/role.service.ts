import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AsyncAction } from 'rxjs/internal/scheduler/AsyncAction';

@Injectable({
  providedIn: 'root'
})
export class RoleService {

  constructor(private http : HttpClient) { }

  BaseUrl = "https://localhost:44393/api/Roles";

  getRoles():Observable<any>{
    return this.http.get<any>(this.BaseUrl);
  }
}
