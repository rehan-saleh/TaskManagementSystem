import { Component, OnInit } from '@angular/core';
import { CompanyViewModel, CompanyModel } from 'src/models/company.model';
import { CompaniesService } from './companies.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-companies',
  templateUrl: './companies.component.html',
  styleUrls: ['./companies.component.scss']
})
export class CompaniesComponent implements OnInit {
  companyForm: FormGroup;
  companies: CompanyViewModel[]; company = new CompanyModel();

  constructor(private service: CompaniesService, private fb: FormBuilder) {
    this.companyForm = this.fb.group({
      companyName: ['', Validators.required],
      companyAddress: ['', Validators.required],
      companyRegistrationNumber: [''],
      companyTaxNumber: [''],
    });
  }

  ngOnInit() {
    this.GetCompanies();
  }

  GetCompanies() {
    this.service.GetCompanies().subscribe((res: CompanyViewModel[]) => {
      this.companies = res
    },
      (error: any) => {
        console.log(error);
      });
  }

  AddUpdateCompany() {
    this.service.AddUpdateCompany(this.company).subscribe((res: any) => {
      this.GetCompanies();
    },
      (error: any) => {
        console.log(error);
      });
  }

  EditCompany(company: CompanyViewModel) {
    this.company.companyId = company.CompanyId;
    this.company.companyName = company.CompanyName;
    this.company.companyAddress = company.CompanyAddress;
    this.company.companyTaxNumber = company.CompanyTaxNumber;
    this.company.companyRegistrationNumber = company.CompanyRegistrationNumber;
  }

  DeleteCompany(companyId) {
    if (confirm('Are you sure?')) {
      this.service.DeleteCompany(companyId).subscribe((res: any) => {
        this.GetCompanies();
      },
        (error: any) => {
          console.log(error);
        });
    }
  }

  ClearForm() {
    this.companyForm.reset();
  }
}
