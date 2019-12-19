import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { CompanyViewModel } from 'src/models/company.model';
import { CompaniesService } from '../companies/companies.service';
import { DesignationsService } from './designations.service';
import { DesignationModel, DesignationViewModel } from 'src/models/designation.model';

@Component({
  selector: 'app-designations',
  templateUrl: './designations.component.html',
  styleUrls: ['./designations.component.scss']
})
export class DesignationsComponent implements OnInit {
  designationForm: FormGroup;
  designations: DesignationViewModel[];
  designation = new DesignationModel();
  companies: CompanyViewModel[];

  constructor(private service: DesignationsService, private fb: FormBuilder,
    private companyService: CompaniesService) {
    this.designationForm = this.fb.group({
      designationName: ['', Validators.required],
      companyId: ['', Validators.required]
    });
  }

  ngOnInit() {
    this.GetCompanies();
    this.GetDesignations();
  }

  GetCompanies() {
    this.companyService.GetCompanies().subscribe((res: CompanyViewModel[]) => {
      this.companies = res
    },
      (error: any) => {
        console.log(error);
      });
  }

  GetDesignations() {
    this.service.GetDesignations().subscribe((res: DesignationViewModel[]) => {
      this.designations = res
    },
      (error: any) => {
        console.log(error);
      });
  }

  AddUpdateDesignation() {
    this.service.AddUpdateDesignation(this.designation).subscribe((res: any) => {
      this.GetDesignations();
      this.ClearForm();
    },
      (error: any) => {
        console.log(error);
      });
  }

  EditDesignation(designation: DesignationViewModel) {
    this.designation.designationId = designation.DesignationId;
    this.designation.designationName = designation.DesignationName;
    this.designation.companyId = designation.CompanyId;
    this.designation.companyName = designation.CompanyName;
  }

  DeleteDesignation(designationId) {
    if (confirm('Are you sure?')) {
      this.service.DeleteDesignation(designationId).subscribe((res: any) => {
        this.GetDesignations();
      },
        (error: any) => {
          console.log(error);
        });
    }
  }

  ClearForm() {
    this.designation = new DesignationModel();
    this.designationForm.reset();
  }
}
