import { Component } from "@angular/core";
import { CommonModule } from "@angular/common";
import { Brand } from "@interfaces/Brand";
import { VehicleEquipment } from "@interfaces/VehicleEquipment";
import { Vehicle } from "@interfaces/Vehicle";
import { VehicleDetailsComponent } from "@components/vehicle-details/vehicle-details.component";

@Component({
  selector: "app-vehicle-update",
  standalone: true,
  imports: [CommonModule, VehicleDetailsComponent],
  templateUrl: "./vehicle-update.component.html",
  styleUrl: "./vehicle-update.component.scss",
})
export class VehicleUpdateComponent {
  vehicle: Vehicle = {
    id: 1,
    licenseNumber: "123",
    vehicleIdentificationNumber: "123",
    modelName: "ingo",
    vehicleEquipmentIds: [1],
    brandId: 1,
  };
  brandsList: Brand[] = [
    {
      id: 1,
      name: "rutjker",
    },
    {
      id: 2,
      name: "bjarni",
    },
  ];

  vehicleEquipmentList: VehicleEquipment[] = [
    {
      id: 1,
      description: "camera",
    },
    {
      id: 2,
      description: "camera2",
    },
  ];
}
