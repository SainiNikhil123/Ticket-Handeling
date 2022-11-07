import { SupportDashboardComponent } from './support-dashboard/support-dashboard.component';
import { UserComponent } from './user/user.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LOginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { AdminDashboardComponent } from './admin-dashboard/admin-dashboard.component';
import { DevDashboardComponent } from './dev-dashboard/dev-dashboard.component';
import { MyDashboardComponent } from './my-dashboard/my-dashboard.component';
import { AdminService } from './Auth/admin.service';
import { DevService } from './Auth/dev.service';
import { UserService } from './Auth/user.service';
import { SupportService } from './Auth/support.service';

const routes: Routes = [
  {path:"login", component:LOginComponent},
  {path:"register", component:RegisterComponent},
  {path:"user", component:UserComponent,canActivate:[AdminService]},
  {path:"admin",component:AdminDashboardComponent,canActivate:[AdminService]},
  {path:"dev",component:DevDashboardComponent,canActivate:[DevService]},
  {path:"use",component:MyDashboardComponent,canActivate:[UserService]},
  {path:"support",component:SupportDashboardComponent,canActivate:[SupportService]}
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
