import { PriorityService } from './../Services/priority.service';
import { StatusService } from './../Services/status.service';
import { UserService } from './../Services/user.service';
import { TicketService } from './../Services/ticket.service';
import { Component, OnInit } from '@angular/core';
import { Tickets } from '../Models/tickets';
import { User } from '../Models/user';
import { ApprovedTickets } from '../Models/approved-tickets';
import { Status } from '../Models/status';
import { Priority } from '../Models/priority';
import { UpdateTicket } from '../Models/update-ticket';
import { UpperCasePipe } from '@angular/common';

@Component({
  selector: 'app-admin-dashboard',
  templateUrl: './admin-dashboard.component.html',
  styleUrls: ['./admin-dashboard.component.scss']
})
export class AdminDashboardComponent implements OnInit {

  ticketList:Tickets[] = [];
  userList:User[] = [];
  statusList:Status[] = [];
  priorityList:Priority[] = [];
  devList:User[] = [];
  ticket:UpdateTicket=new UpdateTicket();

  constructor(private ticketService:TicketService, private userService:UserService, private statusService:StatusService, private priorityService:PriorityService) { }

  ngOnInit(): void {
    this.getAllTickets();
    this.getDev();
    this.getStatuses();
    this.getpriority();
  }

  getAllTickets()
  {
    this.ticketService.get().subscribe(
    (response)=>{
      this.ticketList = response;
      this.ticketList = this.ticketList.filter(x=>x.statusId != 4);
      console.log(this.ticketList);
    },
    (error)=>{
      console.log(error);
    }
    )
  }

  getDev()
  {
    this.userService.getUser().subscribe(
      (response)=>{
        this.userList = response;
        this.devList = this.userList.filter(x=>x.role == "Dev");
        console.log(this.devList);
      },
      (error)=>{
        console.log(error);
      }
    )
  }

  getStatuses()
  {
    this.statusService.getstatus().subscribe(
      (response)=>{
        this.statusList = response
        this.statusList = this.statusList.filter(x=>x.id != 4);
        console.log(this.statusList);
      },
      (error)=>{
        console.log(error);
      }
    )
  }

  getpriority()
  {
    this.priorityService.getpriority().subscribe(
      (response)=>{
        this.priorityList = response
        console.log(this.priorityList);
      },
      (error)=>{
        console.log(error);
      }
    )
  }

  ApproveTicket(){
  }
}
