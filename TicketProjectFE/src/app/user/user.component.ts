import { Component, OnInit } from '@angular/core';
import { User } from '../Models/user';
import { UserService } from '../Services/user.service';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.scss']
})
export class UserComponent implements OnInit {

  userList:User[] = [];

  constructor(private userService: UserService) { }

  ngOnInit(): void {
    this.get();
  }

  get()
  {
    this.userService.getUser().subscribe(
      (response)=>{
        this.userList = response;
        console.log(this.userList);
      },
      (error)=>{
        console.log(error);
      }
    )
  }
}
