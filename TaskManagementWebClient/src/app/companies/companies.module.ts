import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CompaniesComponent } from './companies.component';
import { CompaniesRoutingModule } from './companies.routing';
import { SidebarModule } from '../shared/sidebar/sidebar.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CompaniesService } from './companies.service';

@NgModule({
  declarations: [CompaniesComponent],
  imports: [
    CommonModule,
    CompaniesRoutingModule,
    SidebarModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [CompaniesService]
})
export class CompaniesModule { }
