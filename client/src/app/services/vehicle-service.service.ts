import { Injectable } from '@angular/core';
import { retry, catchError } from 'rxjs/operators';
import { Observable, throwError } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Vehicle } from '@interfaces/Vehicle'
import { BaseServiceService } from './base-service';
@Injectable({
  providedIn: 'root'
})
export class VehicleServiceService extends BaseServiceService {
  endpoint = 'http://localhost:3000';
  constructor(private httpClient: HttpClient) {}
  httpHeader = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
    }),
  };

  create(vehicle: Vehicle): Observable<Vehicle>
  {
    return this.httpClient
      .post<User>(
        this.endpoint,
        JSON.stringify(data),
        this.httpHeader
      ).pipe(retry(1), catchError(this.processError));
  }

  get(id: number) : Observable<Vehicle>
  {
    return this.httpClient
      .get<Vehicle>(
        this.endpoint + id,
        this.httpHeader
      ).pipe(retry(1), catchError(this.processError));    
  }

  get(page: number = 1, pageSize:number = 100) : Observable<PagedResult>
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
      .put<User>(
        this.endpoint,
        JSON.stringify(data),
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
