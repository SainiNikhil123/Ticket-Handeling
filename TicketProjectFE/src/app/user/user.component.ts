import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';
import { Roles } from '../Models/roles';
import { User } from '../Models/user';
import { RoleService } from '../Services/role.service';
import { UserService } from '../Services/user.service';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.scss']
})
export class UserComponent implements OnInit {

  userList:User[] = [];
  newUser:User = new User();
  RoleList:Roles[] = [];
  constructor(private userService: UserService,private roleService:RoleService, private route:Router) { }

  ngOnInit(): void {
    this.get();
    this.roles();
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

  Register()
  {
    debugger;
    console.log(this.newUser);
    this.newUser.id = "0";
    this.userService.register(this.newUser).subscribe(
      (response)=>{
        console.log(response);
        Swal.fire({
          position: 'top-end',
          icon: 'success',
          title: 'You are Sucessfully Registered',
          showConfirmButton: false,
          timer: 1500
        })
        this.get();
      },
      (error)=>{
        console.log(error);
      }
    )

  }
  roles() {
    this.roleService.getRoles().subscribe(
      (response)=>{
        this.RoleList = response
        console.log(this.RoleList);
      },
      (error)=>{
        console.log(error);
      }
    )
  }

  selectedRole(e:any){
    this.newUser.role = e.target.value;
  }
}
