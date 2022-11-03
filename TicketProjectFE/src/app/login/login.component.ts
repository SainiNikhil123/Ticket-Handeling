import { Router } from '@angular/router';
import { Login } from './../Models/login';
import { UserService } from './../Services/user.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LOginComponent implements OnInit {

  Login:Login = new Login();
  token:string="";

  constructor(private userService : UserService, private route:Router) { }

  ngOnInit(): void {
  }

  Logins()
  {
    console.log(this.Login)
    this.userService.authenticate(this.Login).subscribe(
      (response)=>{
        console.log(response);
        this.token = (<any>response).token;
        sessionStorage.setItem("jwt",this.token);
        let tokenData = this.token.split('.')[1]
        let decodeJsonData = window.atob(tokenData)
        let decodeTokenData = JSON.parse(decodeJsonData)
        let Role = decodeTokenData.role;
        let Id = decodeTokenData.Id;
        sessionStorage.setItem("role",Role);
        sessionStorage.setItem("Id",Id);
        this.route.navigateByUrl("");
      },
      (error)=>{
        console.log(error);
        alert("wrong UserName / Password ")
      }
    )
  }
}
