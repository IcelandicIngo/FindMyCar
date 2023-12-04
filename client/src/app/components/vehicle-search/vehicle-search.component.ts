import { Component, OnInit } from "@angular/core";
import { CommonModule } from "@angular/common";
import { MatIconModule } from "@angular/material/icon";
import { MatFormFieldModule } from "@angular/material/form-field";
import { MatInputModule } from "@angular/material/input";
import { MatPaginatorModule, PageEvent } from '@angular/material/paginator';

import { VehicleListComponent } from "./vehicle-list/vehicle-list.component";
import { VehicleService } from "@services/vehicle-service.service";
import { FormsModule } from "@angular/forms";
import { Vehicle } from "@interfaces/Vehicle";
import { PagedResult } from "@interfaces/PagedResult";
import { MatCardModule } from "@angular/material/card";
@Component({
  selector: "app-vehicle-search",
  standalone: true,
  imports: [
    CommonModule,
    VehicleListComponent,
    MatIconModule,
    MatFormFieldModule,
    MatInputModule,
    FormsModule,
    MatCardModule,
    MatPaginatorModule
  ],
  templateUrl: "./vehicle-search.component.html",
  styleUrl: "./vehicle-search.component.scss",
})
export class VehicleSearchComponent implements OnInit {
  page: number = 1;
  pageSize: number = 100;
  pageSizeOptions = [5, 10, 25, 100];
  totalVehicles: number = 100;
  licenseNumber: string = "";
  vehicles: Vehicle[] = []
  constructor(private service: VehicleService) {}
  ngOnInit(): void {
    this.onSearch();
  }

  onSearch() {
    this.service.getPage(this.page, this.pageSize, this.licenseNumber).subscribe(
      {
        next: this.getSearchResultHandler.bind(this),
        error: console.error
      }      
    );
  }

  onPage(pageEvent: PageEvent) {
    this.service.getPage(pageEvent.pageIndex + 1, pageEvent.pageSize, this.licenseNumber).subscribe(
      {
        next: this.getSearchResultHandler.bind(this),
        error: console.error
      }      
    );
  }

  getSearchResultHandler(page: PagedResult){
    this.vehicles = page.result;
    this.page = page.page;
    this.totalVehicles = page.total;
    this.pageSize = page.pageSize;
  }
}
