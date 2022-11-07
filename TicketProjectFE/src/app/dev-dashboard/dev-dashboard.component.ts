import { Tickets } from './../Models/tickets';
import { TicketService } from './../Services/ticket.service';
import { Component, OnInit } from '@angular/core';
import { CommentService } from '../Services/comment.service';
import { Comment } from '../Models/comment';
import { NewComment } from '../Models/new-comment';

@Component({
  selector: 'app-dev-dashboard',
  templateUrl: './dev-dashboard.component.html',
  styleUrls: ['./dev-dashboard.component.scss']
})
export class DevDashboardComponent implements OnInit {

  ticketList:Tickets[] = [];
  newComments:NewComment = new NewComment();
  comment:Comment[] = [];

  constructor(private ticketService: TicketService,private commentService:CommentService) { }

  ngOnInit(): void {
    this.getTicketsForDev()
  }

  getTicketsForDev(){
    let role = sessionStorage.getItem("role");
    if(role != "Dev"){
      return
    }
    let Id = sessionStorage.getItem("Id")
    if(Id){
      this.ticketService.ticketByDevId(Id).subscribe(
        (response)=>{
          this.ticketList = response
        },
        (error)=>{
          console.log(error);
        }
      )
    }
  }

  createImagePath(serverPath:string){
    return `https://localhost:44393/${serverPath}`;
  }

  commentClick(e:number)
  {
    console.log(e);
    this.newComments.ticketId = e;
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
