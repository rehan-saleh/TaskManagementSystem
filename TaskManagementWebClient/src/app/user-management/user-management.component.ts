import { EmployeeInRoleViewModel } from "./../../models/employee.model";
import { Component, OnInit } from "@angular/core";
import { EmployeesService } from "../employees/employees.service";
import { EmployeeViewModel } from "src/models/employee.model";
import { User, Users } from "src/models/user.model";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { RoleViewModel } from "src/models/role.model";
import { UserManagementService } from "./user-management.service";
import { RoleService } from "../../services/role.service";

@Component({
  selector: "app-user-management",
  templateUrl: "./user-management.component.html",
  styleUrls: ["./user-management.component.scss"]
})
export class UserManagementComponent implements OnInit {
  userForm: FormGroup;

  employeesInRoles: EmployeeInRoleViewModel[] = [];
  employees: EmployeeViewModel[] = [];

  user: User = new User();
  userInRole: Users = new Users();

  roles: RoleViewModel[] = [];
  selectedRoles: RoleViewModel[] = [];
  ngxMultiDropdownSettings = {};

  constructor(
    private fb: FormBuilder,
    private _employeeService: EmployeesService,
    private userManagementService: UserManagementService,
    private roleService: RoleService
  ) {
    this.userForm = this.fb.group({
      employeeId: ["", Validators.required],
      userName: ["", Validators.required],
      password: ["", Validators.required],
      confirmPassword: ["", Validators.required],
      userRoles: ["", Validators.required]
    });

    this.ngxMultiDropdownSettings = {
      singleSelection: false,
      idField: "Id",
      textField: "Name",
      selectAllText: "Select All",
      unSelectAllText: "UnSelect All",
      itemsShowLimit: 3,
      allowSearchFilter: true
    };
  }

  ngOnInit() {
    this.GetAllEmployees();
    this.GetAllRoles();
    this.GetAllEmployeesInRoles();
  }

  GetAllEmployeesInRoles() {
    this.userManagementService
      .GetEmployeesInRoles()
      .subscribe((res: EmployeeInRoleViewModel[]) => {
        this.employeesInRoles = res;
      });
  }

  GetAllEmployees() {
    this._employeeService
      .GetEmployees()
      .subscribe((res: EmployeeViewModel[]) => {
        this.employees = res;
      });
  }

  GetAllRoles() {
    this.roleService.GetAllRoles().subscribe((res: RoleViewModel[]) => {
      this.roles = res;
    });
  }

  AddUserInRole() {
    this.SetFormValues();
    this.roleService.AddUserToRole(this.userInRole).subscribe(res => {
      this.GetAllEmployeesInRoles();
      alert("Success");
    });
  }

  SetRolesForUser(isChecked, value) {
    if (isChecked) {
      this.user.roles.push(value);
    }
  }

  SelectEmployee(employee: EmployeeViewModel) {
    this.user.employeeId = employee.EmployeeId;
  }

  SetFormValues() {
    this.userInRole.Employee.EmployeeId = this.user.employeeId;
    this.userInRole.User.UserName = this.user.userName;
    this.userInRole.User.Password = this.user.password;
    this.userInRole.User.Email = "test@testcom";
    this.userInRole.Roles = this.selectedRoles;
  }

  ClearForm() {
    this.user = new User();
    this.userForm.reset();
  }
}
