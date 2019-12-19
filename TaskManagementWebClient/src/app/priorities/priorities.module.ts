import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PrioritiesComponent } from './priorities.component';
import { PrioritiesService } from './priorities.service';

@NgModule({
  declarations: [PrioritiesComponent],
  imports: [
    CommonModule
  ],
  providers: [PrioritiesService]
})
export class PrioritiesModule { }
