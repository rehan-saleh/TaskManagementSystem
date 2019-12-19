import { Injectable } from '@angular/core';
import { BaseService } from 'src/services/base.service';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class PrioritiesService extends BaseService {

  constructor(private http: HttpClient) {
    super(http, 'priorities')
  }

  getPriorities() {
    return this.http.get(this.baseUrl, { headers: this.headers });
  }
}
