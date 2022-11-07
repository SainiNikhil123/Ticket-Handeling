import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { NewComment } from '../Models/new-comment';

@Injectable({
  providedIn: 'root'
})
export class CommentService {

  constructor(private http: HttpClient) { }

  BaseUrl = "https://localhost:44393/api/Comments";

  getComment(tickId:number):Observable<any>{
    return this.http.get<any>(this.BaseUrl + "?ticketId=" + tickId);
  }

  postComment(tickCom:NewComment):Observable<any>{
    return this.http.post<any>(this.BaseUrl,tickCom);
  }
}
