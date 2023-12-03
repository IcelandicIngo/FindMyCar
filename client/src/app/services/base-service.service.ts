import { Injectable } from "@angular/core";
import { retry, catchError } from "rxjs/operators";
import { Observable, throwError } from "rxjs";

@Injectable({
  providedIn: "root",
})
export class BaseService {
  constructor() {}
  public processError(err: any) {
    let message = `Error Code: ${err.status}\nMessage: ${err.message}`;
    console.log(message);
    return throwError(() => {
      message;
    });
  }
}
