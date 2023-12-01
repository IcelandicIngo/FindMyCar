import { Component, Input, Output, EventEmitter } from "@angular/core";
import { CommonModule } from "@angular/common";
import { MatFormFieldModule } from "@angular/material/form-field";
import { MatInputModule } from "@angular/material/input";
import { MatSelectModule } from "@angular/material/select";
import { MatCardModule } from "@angular/material/card";
import { Brand } from "@interfaces/Brand";
import { VehicleEquipment } from "@interfaces/VehicleEquipment";
import { Vehicle } from "@interfaces/Vehicle";
import { FormsModule } from "@angular/forms";

import { FormControl } from "@angular/forms";
@Component({
  selector: "app-vehicle-details",
  standalone: true,
  imports: [
    CommonModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatCardModule,
    FormsModule,
  ],
  templateUrl: "./vehicle-details.component.html",
  styleUrl: "./vehicle-details.component.scss",
})
export class VehicleDetailsComponent {
  vehicleDetails: Vehicle = <Vehicle>{};
  @Input()
  set vehicle(vehicle: Vehicle) {
    if (vehicle) this.vehicleDetails = vehicle;
  }
  @Input() brands: Brand[] = [];
  @Input() vehicleEquiments: VehicleEquipment[] = [];
  @Output() onSubmit = new EventEmitter<Vehicle>();
}
