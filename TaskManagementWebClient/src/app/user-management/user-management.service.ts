import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { BaseService } from "src/services/base.service";

@Injectable()
export class UserManagementService extends BaseService {
  constructor(private http: HttpClient) {
    super(http, "employeesinroles");
  }

  GetEmployeesInRoles() {
    return this.http.get(this.baseUrl, {
      headers: this.headers
    });
  }
}
