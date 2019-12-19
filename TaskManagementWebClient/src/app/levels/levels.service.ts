import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from 'src/services/base.service';
import { LevelModel } from 'src/models/level.model';

@Injectable()
export class LevelsService extends BaseService {
  constructor(private http: HttpClient) {
    super(http, 'levels')
  }

  GetLevels() {
    return this.http.get(this.baseUrl, { headers: this.headers });
  }

  AddUpdateLevel(level: LevelModel) {
    if (level.levelId) {
      return this.http.put(this.baseUrl + '/' + level.levelId, level, { headers: this.headers });
    }
    return this.http.post(this.baseUrl, level, { headers: this.headers });
  }

  DeleteLevel(levelId: Number) {
    return this.http.delete(this.baseUrl + '/delete/' + levelId, { headers: this.headers })
  }
}
