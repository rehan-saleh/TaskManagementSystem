import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from 'src/services/base.service';
import { DesignationModel } from 'src/models/designation.model';

@Injectable()
export class DesignationsService extends BaseService {
  constructor(private http: HttpClient) {
    super(http, 'designations')
  }

  GetDesignations() {
    return this.http.get(this.baseUrl, { headers: this.headers });
  }

  AddUpdateDesignation(designation: DesignationModel) {
    if (designation.designationId) {
      return this.http.put(this.baseUrl + '/' + designation.designationId, designation, { headers: this.headers });
    }
    return this.http.post(this.baseUrl, designation, { headers: this.headers });
  }

  DeleteDesignation(designationId: Number) {
    return this.http.delete(this.baseUrl + '/delete/' + designationId, { headers: this.headers })
  }
}
