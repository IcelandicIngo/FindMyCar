import { Injectable } from "@angular/core";
import { retry, catchError } from "rxjs/operators";
import { Observable, throwError } from "rxjs";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Brand } from "@interfaces/Brand";
import { BaseService } from "./base-service.service";

@Injectable({
  providedIn: "root",
})
export class BrandService extends BaseService {
  endpoint = "http://localhost:5011/brand";
  constructor(private httpClient: HttpClient) {
    super();
  }
  httpHeader = {
    headers: new HttpHeaders({
      "Content-Type": "application/json",
    }),
  };
  get(): Observable<Brand[]> {
    return this.httpClient
      .get<Brand[]>(this.endpoint, this.httpHeader)
      .pipe(retry(1), catchError(this.processError));
  }
}
