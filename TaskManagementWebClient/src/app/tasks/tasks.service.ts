import { Injectable } from '@angular/core';
import { BaseService } from 'src/services/base.service';
import { HttpClient } from '@angular/common/http';
import { AllTaskViewModel } from 'src/models/allTask.model';

@Injectable()

export class TasksService extends BaseService {

    constructor(private http: HttpClient) {
        super(http, 'alltasks')
    }

    getAllTasks() {
        return this.http.get(this.baseUrl, { headers: this.headers });
    }

    addUpdateTask(task: AllTaskViewModel) {
        if (task.AllTaskId) {
            return this.http.put(this.baseUrl + '/' + task.AllTaskId, task, { headers: this.headers });
        }
        return this.http.post(this.baseUrl, task, { headers: this.headers });
    }

    deleteTask(TaskId: Number) {
        return this.http.delete(this.baseUrl + '/' + TaskId, { headers: this.headers })
    }
}
