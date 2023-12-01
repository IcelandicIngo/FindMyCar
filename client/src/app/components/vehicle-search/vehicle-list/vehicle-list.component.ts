import { Component } from "@angular/core";
import { CommonModule } from "@angular/common";
import { Vehicle } from "@interfaces/Vehicle";
import { MatIconModule } from "@angular/material/icon";
import { MatListModule } from "@angular/material/list";

@Component({
  selector: "app-vehicle-list",
  standalone: true,
  imports: [CommonModule, MatIconModule, MatListModule],
  templateUrl: "./vehicle-list.component.html",
  styleUrl: "./vehicle-list.component.scss",
})
export class VehicleListComponent {
  vehicles: Vehicle[] = [
    {
      id: 1,
      licenseNumber: "123",
      vehicleIdentificationNumber: "123",
      modelName: "ingo",
      vehicleEquipmentIds: [1],
      brandId: 1,
    },
    {
      id: 1,
      licenseNumber: "123",
      vehicleIdentificationNumber: "123",
      modelName: "ingo",
      vehicleEquipmentIds: [1],
      brandId: 1,
    },
  ];
}
