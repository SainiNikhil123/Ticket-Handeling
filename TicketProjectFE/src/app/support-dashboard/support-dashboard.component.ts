import { Comment } from './../Models/comment';
import { CommentService } from './../Services/comment.service';
import { Tickets } from './../Models/tickets';
import { TicketService } from './../Services/ticket.service';
import { Component, OnInit } from '@angular/core';
import { NewComment } from '../Models/new-comment';


@Component({
  selector: 'app-support-dashboard',
  templateUrl: './support-dashboard.component.html',
  styleUrls: ['./support-dashboard.component.scss']
})
export class SupportDashboardComponent implements OnInit {

  ticketList:Tickets[] = [];
  newComments:NewComment = new NewComment();
  comment:Comment[] = [];


  constructor(private ticketService:TicketService,private commentService:CommentService) { }

  ngOnInit(): void {
    this.getAllTickets();
  }

  getAllTickets()
  {
    let role = sessionStorage.getItem("role")
    if(role != "Support"){
      return;
    }
    this.ticketService.getApprovedTickets().subscribe(
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
  createImagePath(serverPath:string){
    return `https://localhost:44393/${serverPath}`;
  }

  commentClick(e:number)
  {
    console.log(e);
    this.newComments.ticketId = e
    this.commentService.getComment(e).subscribe(
      (response)=>{
        this.comment = response;
        console.log(this.comment);
      },
      (error)=>{
        console.log(error);
      }
    )
  }
  AddComment(){
    let Id = sessionStorage.getItem("Id");
    if(Id){
      this.newComments.userId = Id
      this.commentService.postComment(this.newComments).subscribe(
        (response)=>{
          console.log(response);
        },
        (error)=>{
          console.log(error);
        }
      )   
    } else{
      alert("Login First")
    }
  }
}
