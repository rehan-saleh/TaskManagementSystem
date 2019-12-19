import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { LevelViewModel, LevelModel } from 'src/models/level.model';
import { LevelsService } from './levels.service';

@Component({
  selector: 'app-levels',
  templateUrl: './levels.component.html',
  styleUrls: ['./levels.component.scss']
})
export class LevelsComponent implements OnInit {
  levelForm: FormGroup;
  levels: LevelViewModel[];
  level = new LevelModel();

  constructor(private service: LevelsService, private fb: FormBuilder) {
    this.levelForm = this.fb.group({
      levelName: ['', Validators.required],
    });
  }

  ngOnInit() {
    this.GetLevels();
  }

  GetLevels() {
    this.service.GetLevels().subscribe((res: LevelViewModel[]) => {
      this.levels = res
    },
      (error: any) => {
        console.log(error);
      });
  }

  AddUpdateLevel() {
    this.service.AddUpdateLevel(this.level).subscribe((res: any) => {
      this.GetLevels();
      this.ClearForm();
    },
      (error: any) => {
        console.log(error);
      });
  }

  EditLevel(level: LevelViewModel) {
    this.level.levelId = level.LevelId;
    this.level.levelName = level.LevelName;
  }

  DeleteLevel(levelId) {
    if (confirm('Are you sure?')) {
      this.service.DeleteLevel(levelId).subscribe((res: any) => {
        this.GetLevels();
      },
        (error: any) => {
          console.log(error);
        });
    }
  }

  ClearForm() {
    this.level = new LevelModel();
    this.levelForm.reset();
  }
}
