import { HttpClient, HttpErrorResponse, HttpEventType } from '@angular/common/http';
import { Component, EventEmitter, Output } from '@angular/core';
import { Roles } from './Models/roles';
import { Test } from './Models/test';
import { Ticket } from './Models/ticket';
import { Tickets } from './Models/tickets';
import { RoleService } from './Services/role.service';
import { TicketService } from './Services/ticket.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'TicketProjectFE';

  roleList:Roles[] = [];
  ticket:Ticket = new Ticket()
  selectedFile:any;
  path:Test=new Test();

  progress: number = 0;
  message: string = "";
  @Output() public onUploadFinished = new EventEmitter();

  constructor(private roleService: RoleService, private ticketService:TicketService, private http: HttpClient) {}

  Logout(){
  sessionStorage.removeItem("jwt");
  sessionStorage.removeItem("role");
  sessionStorage.removeItem("Id");
  }

  getRoles(){
    this.roleService.getRoles().subscribe(
      (response)=>{
        this.roleList = response;
        console.log(this.roleList);
      },
      (error)=>{
        console.log(error);
      }
    )
  }

  addTicket(){
    debugger;
    let userId = sessionStorage.getItem("Id");
    this.ticket.UserId = userId;
    console.log(this.ticket);
    this.ticketService.newTicket(this.ticket).subscribe(
      (response)=>{
        console.log(response);
      },
      (error)=>{
        console.log(error);
      }
    )
    console.log(this.ticket)
  }


  uploadFile = (files:any) => {
    if (files.length === 0) {
      return;
    }
    let fileToUpload = <File>files[0];
    const formData = new FormData();
    formData.append('file', fileToUpload, fileToUpload.name);

    this.http.post('https://localhost:44393/api/Ticket/Upload', formData, {reportProgress: true, observe: 'events'})
      .subscribe({
        next: (event) => {
        if (event.type === HttpEventType.Response) {
          this.message = 'Upload success.';
          this.onUploadFinished.emit(event.body);
          console.log(event);
          this.path = <any>event.body; 
          this.ticket.PicturePath = this.path.dbPath;
          console.log(this.ticket.PicturePath);        
        }
      },
      error: (err: HttpErrorResponse) => console.log(err)
    });
  }
}


