import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { BranchViewModel, BranchModel } from 'src/models/branch.model';
import { CompanyViewModel } from 'src/models/company.model';
import { BranchesService } from './branches.service';
import { CompaniesService } from '../companies/companies.service';

@Component({
  selector: 'app-branches',
  templateUrl: './branches.component.html',
  styleUrls: ['./branches.component.scss']
})
export class BranchesComponent implements OnInit {

  branchesForm: FormGroup;
  branches: BranchViewModel[];
  branch = new BranchModel();
  companies: CompanyViewModel[];

  constructor(private service: BranchesService, private fb: FormBuilder,
    private companyService: CompaniesService) {
    this.branchesForm = this.fb.group({
      branchName: ['', Validators.required],
      branchAddress: ['', Validators.required],
      branchEmail: ['', Validators.required],
      companyId: ['', Validators.required]
    });
  }

  ngOnInit() {
    this.GetCompanies();
    this.GetBranches();
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
    this.service.GetBranches().subscribe((res: BranchViewModel[]) => {
      this.branches = res
    },
      (error: any) => {
        console.log(error);
      });
  }

  AddUpdateBranch() {
    this.service.AddUpdateBranch(this.branch).subscribe((res: any) => {
      this.GetBranches();
      this.ClearForm();
    },
      (error: any) => {
        console.log(error);
      });
  }

  EditBranch(branch: BranchViewModel) {
    this.branch.branchId = branch.BranchId;
    this.branch.branchName = branch.BranchName;
    this.branch.branchAddress = branch.BranchAddress;
    this.branch.branchEmail = branch.BranchEmail;
    this.branch.companyId = branch.CompanyId;
  }

  DeleteBranch(branchId) {
    if (confirm('Are you sure?')) {
      this.service.DeleteBranch(branchId).subscribe((res: any) => {
        this.GetBranches();
      },
        (error: any) => {
          console.log(error);
        });
    }
  }

  ClearForm() {
    this.branch = new BranchModel();
    this.branchesForm.reset();
  }
}
