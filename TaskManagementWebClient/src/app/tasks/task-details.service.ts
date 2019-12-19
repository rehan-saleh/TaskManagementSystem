import { Injectable } from '@angular/core';
import { BaseService } from 'src/services/base.service';
import { HttpClient } from '@angular/common/http';
import { TaskDetailViewModel } from 'src/models/task-detail.model';

@Injectable()

export class TaskDetailsService extends BaseService {

  constructor(private http: HttpClient) {
    super(http, 'taskdetails')
  }

  getTaskDetails() {
    return this.http.get(this.baseUrl, { headers: this.headers });
  }

  getTaskDetailById(allTaskId: number) {
    return this.http.get(this.baseUrl + '/details/' + allTaskId, { headers: this.headers });
  }

  addUpdateComment(taskDetail: TaskDetailViewModel) {
    if (taskDetail.AllTaskId > 0) {
      return this.http.post(this.baseUrl, taskDetail, { headers: this.headers });
    }
  }

  deleteComment(TaskDetailId: Number) {
    return this.http.delete(this.baseUrl + '/' + TaskDetailId, { headers: this.headers })
  }
}
