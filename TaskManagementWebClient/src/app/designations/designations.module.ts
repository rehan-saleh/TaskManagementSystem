import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DesignationsComponent } from './designations.component';
import { SidebarModule } from '../shared/sidebar/sidebar.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DesignationsService } from './designations.service';
import { DesignationsRoutingModule } from './designations.routing';
import { CompaniesService } from '../companies/companies.service';

@NgModule({
  declarations: [DesignationsComponent],
  imports: [
    CommonModule,
    DesignationsRoutingModule,
    SidebarModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [DesignationsService, CompaniesService]
})
export class DesignationsModule { }
