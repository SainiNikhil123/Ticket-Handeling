import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'TicketProjectFE';

  Logout(){
  sessionStorage.removeItem("jwt");
  sessionStorage.removeItem("role");
  sessionStorage.removeItem("Id");
  }
}


