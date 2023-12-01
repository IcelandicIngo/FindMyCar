import { Injectable } from "@angular/core";
import { retry, catchError } from "rxjs/operators";
import { Observable, throwError } from "rxjs";
import { BaseServiceService } from "./base-service";

@Injectable({
  providedIn: "root",
})
export class BaseServiceService {
  constructor() {}
  private processError(err: any) {
    let message = "";
    if (err.error instanceof ErrorEvent) {
      message = err.error.message;
    } else {
      message = `Error Code: ${err.status}\nMessage: ${err.message}`;
    }
    console.log(message);
    return throwError(() => {
      message;
    });
  }
}
