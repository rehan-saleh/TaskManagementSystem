import { Injectable } from '@angular/core';
import { BaseService } from 'src/services/base.service';
import { HttpClient } from '@angular/common/http';
import { DepartmentModel } from 'src/models/department.model';

@Injectable()

export class DepartmentsService extends BaseService {
  constructor(private http: HttpClient) {
    super(http, 'departments')
  }

  GetDepartments() {
    return this.http.get(this.baseUrl, { headers: this.headers });
  }

  AddUpdateDepartment(department: DepartmentModel) {
    if (department.departmentId) {
      return this.http.put(this.baseUrl + '/' + department.departmentId, department, { headers: this.headers });
    }
    return this.http.post(this.baseUrl, department, { headers: this.headers });
  }

  DeleteDepartment(departmentId: Number) {
    return this.http.delete(this.baseUrl + '/delete/' + departmentId, { headers: this.headers })
  }
}
