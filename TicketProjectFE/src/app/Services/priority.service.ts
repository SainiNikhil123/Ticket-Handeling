import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';

@Injectable({
  providedIn: 'root'
})
export class PriorityService {

  constructor(private http:HttpClient) { }

  BaseUrl="https://localhost:44393/api/Priority/";

  getpriority():Observable<any>{
    return this.http.get<any>(this.BaseUrl);
  }
}
