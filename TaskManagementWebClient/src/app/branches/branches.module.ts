import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BranchesComponent } from './branches.component';
import { BranchesService } from './branches.service';
import { BranchesRoutingModule } from './branches.routing';
import { SidebarModule } from '../shared/sidebar/sidebar.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CompaniesService } from '../companies/companies.service';

@NgModule({
  declarations: [BranchesComponent],
  imports: [
    CommonModule,
    BranchesRoutingModule,
    SidebarModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [BranchesService, CompaniesService]
})
export class BranchesModule { }
