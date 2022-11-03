import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class StatusService {

  constructor(private http:HttpClient) { }

  BaseUrl = "https://localhost:44393/api/Status/";

  getstatus():Observable<any>{
    return this.http.get<any>(this.BaseUrl);
  }
}
