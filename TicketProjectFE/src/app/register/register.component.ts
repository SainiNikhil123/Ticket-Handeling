import { Component, OnInit } from '@angular/core';
import { User } from '../Models/user';
import { UserService } from '../Services/user.service';
import Swal from 'sweetalert2';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  newUser:User = new User();
  registerForm = new FormGroup({
    name: new FormControl( '',[ Validators.required]),
    email: new FormControl( '',[ Validators.required]),
    pNumber: new FormControl( '',[ Validators.required]),
    pWord: new FormControl( '',[ Validators.required]),
  })

  constructor(private fb:FormBuilder, private userService:UserService) { }

  ngOnInit(): void {
  }

  Register()
  {
    console.log(this.newUser);
    this.newUser.id = "0";
    this.newUser.role = "User";
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
      },
      (error)=>{
        console.log(error);
      }
    )

  }

}
