import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserManagementComponent } from './user-management.component';
import { UserManagementRoutingModule } from './user-management.routing';
import { SidebarModule } from '../shared/sidebar/sidebar.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { UserManagementService } from './user-management.service';
import { EmployeesService } from '../employees/employees.service';
import { NgMultiSelectDropDownModule } from 'ng-multiselect-dropdown';

@NgModule({
  declarations: [UserManagementComponent],
  imports: [
    CommonModule,
    UserManagementRoutingModule,
    SidebarModule,
    FormsModule,
    ReactiveFormsModule,

    NgMultiSelectDropDownModule.forRoot()
  ],
  providers: [UserManagementService, EmployeesService]
})
export class UserManagementModule { }
