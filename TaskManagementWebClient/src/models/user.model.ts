import { RoleViewModel } from './role.model';
import { EmployeeViewModel } from './employee.model';

export class UserViewModel {
    EmployeeId: number = 0;
    UserName: string = null;
    Password: Date = null;
    Email: string = null;
}

export class User {
    
    employeeId: number = 0;
    userName: string = null;
    email: string = null;
    password: Date = null;
    confirmPassword: boolean = false;
    roles: RoleViewModel[] = [];
}

export class Users {
    User: UserViewModel = new UserViewModel();
    Roles: RoleViewModel[] = [];
    Employee: EmployeeViewModel = new EmployeeViewModel();
}