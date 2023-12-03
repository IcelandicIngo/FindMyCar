import { Injectable } from "@angular/core";
import { retry, catchError } from "rxjs/operators";
import { Observable, throwError } from "rxjs";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { VehicleEquipment } from "@interfaces/VehicleEquipment";
import { BaseService } from "./base-service.service";

@Injectable({
  providedIn: "root",
})
export class VehicleEquipmentService extends BaseService {
  endpoint = "http://localhost:5011/vehicleequipment";
  constructor(private httpClient: HttpClient) {
    super();
  }
  ingo = "";
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
