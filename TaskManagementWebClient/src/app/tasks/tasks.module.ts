import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TasksComponent } from './tasks.component';
import { TasksRoutingModule } from './tasks-routing.module';
import { SidebarModule } from '../shared/sidebar/sidebar.module';
import { TasksService } from './tasks.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ClickStopPropagation } from 'src/directives/stopEventPropagation.directive';
import { EmployeesService } from '../employees/employees.service';
import { DepartmentsService } from '../departments/departments.service';
import { PrioritiesService } from '../priorities/priorities.service';
import { TasktypesService } from '../tasktypes/tasktypes.service';
import { TaskDetailsService } from './task-details.service';

@NgModule({
  declarations: [TasksComponent, ClickStopPropagation],
  imports: [
    CommonModule,
    TasksRoutingModule,
    SidebarModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [TasksService, EmployeesService, DepartmentsService
    , PrioritiesService, TasktypesService, TaskDetailsService]
})
export class TasksModule { }
