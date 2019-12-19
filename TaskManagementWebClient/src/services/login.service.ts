import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { BaseService } from './base.service';
import { LoginModel } from 'src/models/login.model';

@Injectable()

export class AuthService extends BaseService {
    constructor(private http: HttpClient) {
        super(http, "");
    }

    authenticate(user: LoginModel) {
        var params = "username=" + user.username + "&password=" + user.password + "&grant_type=" + user.grant_type;
        return this.http.post(this.baseUrl + 'token', params);
    }
} 