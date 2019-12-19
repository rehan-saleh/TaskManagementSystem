import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from 'src/services/auth.guard';
import { LoginComponent } from './login/login.component';
import { HomeComponent } from './home/home.component';

const routes: Routes = [
  {
    path: 'login',
    component: LoginComponent,
  },
  {
    path: '',
    redirectTo: 'home',
    pathMatch: 'full'
  },
  {
    path: 'home',
    component: HomeComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'companies',
    loadChildren: './companies/companies.module#CompaniesModule',
    canActivate: [AuthGuard]
  },
  {
    path: 'departments',
    loadChildren: './departments/departments.module#DepartmentsModule',
    canActivate: [AuthGuard]
  },
  {
    path: 'branches',
    loadChildren: './branches/branches.module#BranchesModule',
    canActivate: [AuthGuard]
  },
  {
    path: 'employees',
    loadChildren: './employees/employees.module#EmployeesModule',
    canActivate: [AuthGuard]
  },
  {
    path: 'designations',
    loadChildren: './designations/designations.module#DesignationsModule',
    canActivate: [AuthGuard]
  },
  {
    path: 'levels',
    loadChildren: './levels/levels.module#LevelsModule',
    canActivate: [AuthGuard]
  },
  {
    path: 'tasks',
    loadChildren: './tasks/tasks.module#TasksModule',
    canActivate: [AuthGuard]
  },
  {
    path: 'user-management',
    loadChildren: './user-management/user-management.module#UserManagementModule',
    canActivate: [AuthGuard]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
