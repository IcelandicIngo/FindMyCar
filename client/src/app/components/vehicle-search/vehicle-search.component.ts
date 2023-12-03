import { Component, OnInit } from "@angular/core";
import { CommonModule } from "@angular/common";
import { MatIconModule } from "@angular/material/icon";
import { MatFormFieldModule } from "@angular/material/form-field";
import { MatInputModule } from "@angular/material/input";

import { VehicleListComponent } from "./vehicle-list/vehicle-list.component";
import { VehicleService } from "@services/vehicle-service.service";
import { FormsModule } from "@angular/forms";
import { Vehicle } from "@interfaces/Vehicle";
import { PagedResult } from "@interfaces/PagedResult";
@Component({
  selector: "app-vehicle-search",
  standalone: true,
  imports: [
    CommonModule,
    VehicleListComponent,
    MatIconModule,
    MatFormFieldModule,
    MatInputModule,
    FormsModule
  ],
  templateUrl: "./vehicle-search.component.html",
  styleUrl: "./vehicle-search.component.scss",
})
export class VehicleSearchComponent implements OnInit {
  page: number = 1;
  pageSize: number = 100;
  licenseNumber: string = "";
  vehicles: Vehicle[] = []
  constructor(private service: VehicleService) {}
  ngOnInit(): void {
    this.onSearch();
  }

  onSearch() {
    this.service.getPage(this.page, this.pageSize, this.licenseNumber).subscribe(
      {
        next: this.getPageHandler.bind(this),
        error: console.error
      }      
    );
  }

  getPageHandler(page: PagedResult){
    this.vehicles = page.result;
    console.log(page);
  }
}
