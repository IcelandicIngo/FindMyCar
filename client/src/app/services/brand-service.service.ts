import { Injectable } from "@angular/core";
import { retry, catchError } from "rxjs/operators";
import { Observable, throwError } from "rxjs";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Brand } from "@interfaces/Brand";
import { BaseServiceService } from "./base-service";

@Injectable({
  providedIn: "root",
})
export class BrandServiceService extends BaseServiceService {
  endpoint = "http://localhost:3000";
  constructor(private httpClient: HttpClient) {}
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
