import { Injectable } from '@angular/core';
import { BaseService } from 'src/services/base.service';
import { HttpClient } from '@angular/common/http';

@Injectable()

export class TasktypesService extends BaseService {

  constructor(private http: HttpClient) {
    super(http, 'tasktypes')
  }

  getTaskTypes() {
    return this.http.get(this.baseUrl, { headers: this.headers });
  }
}
