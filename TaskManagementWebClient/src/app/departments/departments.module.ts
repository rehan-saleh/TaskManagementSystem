import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DepartmentsComponent } from './departments.component';
import { DepartmentsService } from './departments.service';
import { DepartmentRoutingModule } from './departments.routing';
import { SidebarModule } from '../shared/sidebar/sidebar.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CompaniesService } from '../companies/companies.service';

@NgModule({
  declarations: [DepartmentsComponent],
  imports: [
    CommonModule, 
    DepartmentRoutingModule,
    SidebarModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [DepartmentsService, CompaniesService]
})
export class DepartmentsModule { }
