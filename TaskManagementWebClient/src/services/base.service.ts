import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { TokenModel } from "../models/token.model";

@Injectable()
export class BaseService {
  headers: HttpHeaders;
  baseUrl = "http://localhost:61640/api/";
  token = new TokenModel();

  constructor(http: HttpClient, entityName: string) {
    var token = localStorage.getItem("token");
    this.baseUrl = this.baseUrl + entityName;
    if (token) {
      this.token = JSON.parse(token);
      this.headers = new HttpHeaders({
        "Access-Control-Allow-Origin": "*",
        "Content-Type": "Application/Json",
        Authorization: "Bearer " + this.token.access_token
      });
    }
  }

  clearSession() {
    localStorage.clear();
    this.token = new TokenModel();
    this.headers = new HttpHeaders();
  }

  getFullDate() {
    var date = new Date().getDate();
    var month = new Date().getMonth();
    var year = new Date().getFullYear();
    var fullDate = year + "-" + month + "-" + date;
    return fullDate;
  }
}
