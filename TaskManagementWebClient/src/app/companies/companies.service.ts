import { Injectable } from '@angular/core';
import { BaseService } from 'src/services/base.service';
import { HttpClient } from '@angular/common/http';
import { CompanyModel } from 'src/models/company.model';

@Injectable()

export class CompaniesService extends BaseService {
  constructor(private http: HttpClient) {
    super(http, 'companies')
  }

  GetCompanies() {
    return this.http.get(this.baseUrl, { headers: this.headers });
  }

  AddUpdateCompany(company: CompanyModel) {
    if (company.companyId) {
      return this.http.put(this.baseUrl + '/' + company.companyId, company, { headers: this.headers });
    }
    return this.http.post(this.baseUrl, company, { headers: this.headers });
  }

  DeleteCompany(companyId: Number) {
    return this.http.delete(this.baseUrl + '/delete/' + companyId, { headers: this.headers })
  }
}
