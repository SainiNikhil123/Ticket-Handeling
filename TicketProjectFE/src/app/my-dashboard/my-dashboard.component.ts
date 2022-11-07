import { Component, OnInit } from '@angular/core';
import { Comment } from '../Models/comment';
import { NewComment } from '../Models/new-comment';
import { Tickets } from '../Models/tickets';
import { CommentService } from '../Services/comment.service';
import { TicketService } from '../Services/ticket.service';

@Component({
  selector: 'app-my-dashboard',
  templateUrl: './my-dashboard.component.html',
  styleUrls: ['./my-dashboard.component.scss']
})
export class MyDashboardComponent implements OnInit {

  ticketList:Tickets[] = [];
  newComments:NewComment = new NewComment();
  comment:Comment[] = [];

  constructor(private ticketService: TicketService,private commentService:CommentService) { }

  ngOnInit(): void {
    this.getTicketsForUser()
  }

  getTicketsForUser(){
    let role = sessionStorage.getItem("role");
    if(role != "User"){
      return
    }
    let Id = sessionStorage.getItem("Id")
    if(Id){
      this.ticketService.ticketByUserId(Id).subscribe(
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
