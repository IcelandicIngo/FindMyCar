import { Component } from "@angular/core";
import { CommonModule } from "@angular/common";
import { MatIconModule } from "@angular/material/icon";
import { MatFormFieldModule } from "@angular/material/form-field";
import { MatInputModule } from "@angular/material/input";

import { VehicleListComponent } from "./vehicle-list/vehicle-list.component";
@Component({
  selector: "app-vehicle-search",
  standalone: true,
  imports: [
    CommonModule,
    VehicleListComponent,
    MatIconModule,
    MatFormFieldModule,
    MatInputModule,
  ],
  templateUrl: "./vehicle-search.component.html",
  styleUrl: "./vehicle-search.component.scss",
})
export class VehicleSearchComponent {
}
