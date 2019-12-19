import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from 'src/services/base.service';
import { EmployeeModel } from 'src/models/employee.model';

@Injectable()

export class EmployeesService extends BaseService {
  constructor(private http: HttpClient) {
    super(http, 'employees')
  }

  GetEmployees() {
    return this.http.get(this.baseUrl, { headers: this.headers });
  }

  AddUpdateEmployee(employee: EmployeeModel) {
    if (employee.employeeId) {
      return this.http.put(this.baseUrl + '/' + employee.employeeId, employee, { headers: this.headers });
    }
    return this.http.post(this.baseUrl, employee, { headers: this.headers });
  }

  DeleteEmployee(employeeId: Number) {
    return this.http.delete(this.baseUrl + '/delete/' + employeeId, { headers: this.headers })
  }
}
