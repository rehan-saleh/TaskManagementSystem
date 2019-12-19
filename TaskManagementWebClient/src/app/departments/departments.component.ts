import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { DepartmentModel, DepartmentViewModel } from 'src/models/department.model';
import { DepartmentsService } from './departments.service';
import { CompaniesService } from '../companies/companies.service';
import { CompanyViewModel } from 'src/models/company.model';

@Component({
  selector: 'app-departments',
  templateUrl: './departments.component.html',
  styleUrls: ['./departments.component.scss']
})
export class DepartmentsComponent implements OnInit {
  departmentForm: FormGroup;
  departments: DepartmentViewModel[]; 
  department = new DepartmentModel();
  companies: CompanyViewModel[];

  constructor(private service: DepartmentsService, private fb: FormBuilder,
    private companyService: CompaniesService) {
    this.departmentForm = this.fb.group({
      departmentName: ['', Validators.required],
      departmentCode: ['', Validators.required],
      companyId: ['', Validators.required]
    });
  }

  ngOnInit() {
    this.GetCompanies();
    this.GetDepartments();
  }

  GetCompanies() {
    this.companyService.GetCompanies().subscribe((res: CompanyViewModel[]) => {
      this.companies = res
    },
      (error: any) => {
        console.log(error);
      });
  }

  GetDepartments() {
    this.service.GetDepartments().subscribe((res: DepartmentViewModel[]) => {
      this.departments = res
      console.log(this.departments);
    },
      (error: any) => {
        console.log(error);
      });
  }

  AddUpdateDepartment() {
    this.service.AddUpdateDepartment(this.department).subscribe((res: any) => {
      this.GetDepartments();
      this.ClearForm();
    },
      (error: any) => {
        console.log(error);
      });
  }

  EditDepartment(department: DepartmentViewModel) {
    this.department.departmentId = department.DepartmentId;
    this.department.departmentName = department.DepartmentName;
    this.department.departmentCode = department.DepartmentCode;
    this.department.companyId = department.CompanyId;
    this.department.companyName = department.CompanyName;
  }

  DeleteDepartment(departmentId) {
    if (confirm('Are you sure?')) {
      this.service.DeleteDepartment(departmentId).subscribe((res: any) => {
        this.GetDepartments();
      },
        (error: any) => {
          console.log(error);
        });
    }
  }

  ClearForm() {
    this.department = new DepartmentModel();
    this.departmentForm.reset();
  }
}
