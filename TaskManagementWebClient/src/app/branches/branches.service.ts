import { Injectable } from '@angular/core';
import { BaseService } from 'src/services/base.service';
import { HttpClient } from '@angular/common/http';
import { BranchModel } from 'src/models/branch.model';

@Injectable()

export class BranchesService extends BaseService {
  constructor(private http: HttpClient) {
    super(http, 'branches')
  }

  GetBranches() {
    return this.http.get(this.baseUrl, { headers: this.headers });
  }

  AddUpdateBranch(branch: BranchModel) {
    if (branch.branchId) {
      return this.http.put(this.baseUrl + '/' + branch.branchId, branch, { headers: this.headers });
    }
    return this.http.post(this.baseUrl, branch, { headers: this.headers });
  }

  DeleteBranch(branchId: Number) {
    return this.http.delete(this.baseUrl + '/delete/' + branchId, { headers: this.headers })
  }
}
