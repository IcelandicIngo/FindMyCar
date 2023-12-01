import { Injectable } from "@angular/core";
import { retry, catchError } from "rxjs/operators";
import { Observable, throwError } from "rxjs";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { VehicleEquipment } from "./../interfaces/VehicleEquipment";
import { BaseServiceService } from "./base-service";

@Injectable({
  providedIn: "root",
})
export class VehicleEquipmentServiceService extends BaseServiceService {
  endpoint = "http://localhost:3000";
  constructor(private httpClient: HttpClient) {}
  httpHeader = {
    headers: new HttpHeaders({
      "Content-Type": "application/json",
    }),
  };

  get(): Observable<VehicleEquipment[]> {
    return this.httpClient
      .get<VehicleEquipment[]>(this.endpoint, this.httpHeader)
      .pipe(retry(1), catchError(this.processError));
  }
}
