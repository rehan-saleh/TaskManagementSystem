import { Component, OnInit } from '@angular/core';
import { EmployeeModel, EmployeeViewModel } from 'src/models/employee.model';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { CompanyViewModel } from 'src/models/company.model';
import { EmployeesService } from './employees.service';
import { CompaniesService } from '../companies/companies.service';
import { DepartmentViewModel } from 'src/models/department.model';
import { BranchViewModel } from 'src/models/branch.model';
import { DepartmentsService } from '../departments/departments.service';
import { BranchesService } from '../branches/branches.service';
import { DesignationViewModel } from 'src/models/designation.model';
import { DesignationsService } from '../designations/designations.service';

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.scss']
})
export class EmployeesComponent implements OnInit {
  employeeForm: FormGroup;
  employees: EmployeeViewModel[];
  employee = new EmployeeModel();
  companies: CompanyViewModel[];
  branches: BranchViewModel[];
  departments: DepartmentViewModel[];
  designations: DesignationViewModel[];

  constructor(private service: EmployeesService, private fb: FormBuilder,
    private companyService: CompaniesService, private branchService: BranchesService,
    private departmentService: DepartmentsService, private designationService: DesignationsService, ) {
    this.employeeForm = this.fb.group({
      employeeName: ['', Validators.required],
      employeeCode: ['', Validators.required],
      employeeCnic: [''],
      employeeMobile1: [''],
      employeeMobile2: [''],
      employeeEmail1: [''],
      employeeEmail2: [''],
      employeeAddress1: [''],
      employeeAddress2: [''],
      companyId: ['', Validators.required],
      branchId: ['', Validators.required],
      departmentId: ['', Validators.required],
      designationId: ['', Validators.required],
    });
  }

  ngOnInit() {
    this.GetCompanies();
    this.GetBranches();
    this.GetDepartments();
    this.GetDesignations();
    this.GetEmployees();
  }

  GetCompanies() {
    this.companyService.GetCompanies().subscribe((res: CompanyViewModel[]) => {
      this.companies = res
    },
      (error: any) => {
        console.log(error);
      });
  }

  GetBranches() {
    this.branchService.GetBranches().subscribe((res: BranchViewModel[]) => {
      this.branches = res
    },
      (error: any) => {
        console.log(error);
      });
  }

  GetDepartments() {
    this.departmentService.GetDepartments().subscribe((res: DepartmentViewModel[]) => {
      this.departments = res
    },
      (error: any) => {
        console.log(error);
      });
  }

  GetDesignations() {
    this.designationService.GetDesignations().subscribe((res: DesignationViewModel[]) => {
      this.designations = res
    },
      (error: any) => {
        console.log(error);
      });
  }

  GetEmployees() {
    this.service.GetEmployees().subscribe((res: EmployeeViewModel[]) => {
      this.employees = res
    },
      (error: any) => {
        console.log(error);
      });
  }

  AddUpdateEmployee() {
    this.service.AddUpdateEmployee(this.employee).subscribe((res: any) => {
      this.GetEmployees();
      this.ClearForm();
    },
      (error: any) => {
        console.log(error);
      });
  }

  EditEmployee(employee: EmployeeViewModel) {
    this.employee.employeeId = employee.EmployeeId;
    this.employee.employeeName = employee.EmployeeName;
    this.employee.employeeCode = employee.EmployeeCode;
    this.employee.employeeCnic = employee.EmployeeCnic;
    this.employee.employeeEmail1 = employee.EmployeeEmail1;
    this.employee.employeeEmail2 = employee.EmployeeEmail2;
    this.employee.employeeMobile1 = employee.EmployeeMobile1;
    this.employee.employeeMobile2 = employee.EmployeeMobile2;
    this.employee.employeeAddress1 = employee.EmployeeAddress1;
    this.employee.employeeAddress2 = employee.EmployeeAddress2;
    this.employee.branchId = employee.BranchId;
    this.employee.companyId = employee.CompanyId;
    this.employee.departmentId = employee.DepartmentId;
    this.employee.designationId = employee.DesignationId;
  }

  DeleteEmployee(employeeId) {
    if (confirm('Are you sure?')) {
      this.service.DeleteEmployee(employeeId).subscribe((res: any) => {
        this.GetEmployees();
      },
        (error: any) => {
          console.log(error);
        });
    }
  }

  ClearForm() {
    this.employee = new EmployeeModel();
    this.employeeForm.reset();
  }
}
