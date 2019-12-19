import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EmployeesComponent } from './employees.component';
import { EmployeeRoutingModule } from './employees.routing';
import { SidebarModule } from '../shared/sidebar/sidebar.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { EmployeesService } from './employees.service';
import { CompaniesService } from '../companies/companies.service';
import { BranchesService } from '../branches/branches.service';
import { DepartmentsService } from '../departments/departments.service';
import { DesignationsService } from '../designations/designations.service';

@NgModule({
  declarations: [EmployeesComponent],
  imports: [
    CommonModule,
    EmployeeRoutingModule,
    SidebarModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [EmployeesService, CompaniesService, BranchesService, DepartmentsService, DesignationsService]
})
export class EmployeesModule { }
