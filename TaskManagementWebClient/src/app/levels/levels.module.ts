import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LevelsComponent } from './levels.component';
import { LevelsRoutingModule } from './levels.routing';
import { SidebarModule } from '../shared/sidebar/sidebar.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { LevelsService } from './levels.service';

@NgModule({
  declarations: [LevelsComponent],
  imports: [
    CommonModule,
    LevelsRoutingModule,
    SidebarModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [LevelsService]
})
export class LevelsModule { }
