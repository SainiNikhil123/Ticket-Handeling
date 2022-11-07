import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LOginComponent } from './login/login.component';
import { FormsModule } from '@angular/forms';
import { RegisterComponent } from './register/register.component';
import { UserComponent } from './user/user.component';
import { AdminDashboardComponent } from './admin-dashboard/admin-dashboard.component';
import { DevDashboardComponent } from './dev-dashboard/dev-dashboard.component';
import { MyDashboardComponent } from './my-dashboard/my-dashboard.component';
import { SupportDashboardComponent } from './support-dashboard/support-dashboard.component';
import { JwtModule } from "@auth0/angular-jwt";
import { AuthIntercepterService } from './Auth/auth-intercepter.service';

export function tokenGetter() {
  return localStorage.getItem("jwt");
}

@NgModule({
  declarations: [
    AppComponent,
    LOginComponent,
    RegisterComponent,
    UserComponent,
    AdminDashboardComponent,
    DevDashboardComponent,
    MyDashboardComponent,
    SupportDashboardComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    JwtModule.forRoot({
      config:{
        tokenGetter: tokenGetter,
        allowedDomains: ["localhost:44393"]       
      }
    })
  ],
  providers: [
    {
      provide:HTTP_INTERCEPTORS,
      useClass:AuthIntercepterService,
      multi:true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
