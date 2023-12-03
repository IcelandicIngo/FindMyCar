import { Injectable } from '@angular/core';
import { retry, catchError } from 'rxjs/operators';
import { Observable, throwError } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Vehicle } from '@interfaces/Vehicle'
import { BaseService } from './base-service.service';
import { PagedResult } from '@interfaces/PagedResult';
@Injectable({
  providedIn: 'root'
})
export class VehicleService extends BaseService {
  endpoint = 'http://localhost:5011/vehicle';
  constructor(private httpClient: HttpClient) {
    super();
  }
  httpHeader = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
    }),
  };

  create(vehicle: Vehicle): Observable<Vehicle>
  {
    console.log(vehicle);
    return this.httpClient
      .post<Vehicle>(
        this.endpoint,
        JSON.stringify(vehicle),
        this.httpHeader
      ).pipe(retry(1), catchError(this.processError));
  }

  get(id: number) : Observable<Vehicle>
  {
    return this.httpClient
      .get<Vehicle>(
        this.endpoint + '/' + id,
        this.httpHeader
      ).pipe(retry(1), catchError(this.processError));    
  }

  getPage(page: number = 1, pageSize:number = 100) : Observable<PagedResult>
  {
    return this.httpClient
      .get<PagedResult>(
        this.endpoint + "?page=" + page + '&pageSize=' + pageSize,
        this.httpHeader
      ).pipe(retry(1), catchError(this.processError));    
  }  

  update(id: number, vehicle: Vehicle) : Observable<Vehicle>
  {
    return this.httpClient
      .put<Vehicle>(
        this.endpoint + '/' + id,
        JSON.stringify(vehicle),
        this.httpHeader
      ).pipe(retry(1), catchError(this.processError));
  }

  delete(id: number)
  {
    return this.httpClient
      .delete<Vehicle>(this.endpoint + id, this.httpHeader)
      .pipe(retry(1), catchError(this.processError));    
  }
}
