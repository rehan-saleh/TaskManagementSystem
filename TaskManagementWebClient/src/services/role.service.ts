import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { BaseService } from "../services/base.service";
import { Users } from "../models/user.model";

@Injectable()
export class RoleService extends BaseService {
  constructor(private http: HttpClient) {
    super(http, "account");
  }

  GetAllRoles() {
    return this.http.get(this.baseUrl + "/roles", { headers: this.headers });
  }

  AddUserToRole(user: Users) {
    debugger;
    return this.http.post(this.baseUrl + "/role", user, {
      headers: this.headers
    });
  }
}
