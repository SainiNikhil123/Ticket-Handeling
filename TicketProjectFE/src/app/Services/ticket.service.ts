import { UpdateTicket } from './../Models/update-ticket';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Ticket } from '../Models/ticket';

@Injectable({
  providedIn: 'root'
})
export class TicketService {

  constructor(private http:HttpClient) { }

  BaseUrl = "https://localhost:44393/api/Ticket/";

  get():Observable<any>{
    return this.http.get<any>(this.BaseUrl);
  }

  getApprovedTickets():Observable<any>{
    return this.http.get<any>(this.BaseUrl+"Approved");
  }

  approveTicket(tic:UpdateTicket):Observable<any>{
    return this.http.post<any>(this.BaseUrl+"Approve",tic);
  }

  newTicket(tic:Ticket):Observable<any>{
    return this.http.post<any>(this.BaseUrl,tic);
  }
  ticketByDevId(DevId:string):Observable<any>{
    return this.http.get<any>(this.BaseUrl+"DevTickets?DevId="+DevId);
  }

  ticketByUserId(UserId:string):Observable<any>{
    return this.http.get<any>(this.BaseUrl+"UserTickets?UserId="+UserId);
  }

}
