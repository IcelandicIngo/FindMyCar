import { Component } from "@angular/core";
import { CommonModule } from "@angular/common";
import { Brand } from "@interfaces/Brand";
import { VehicleEquipment } from "@interfaces/VehicleEquipment";
import { Vehicle } from "@interfaces/Vehicle";
import { VehicleDetailsComponent } from "@components/vehicle-details/vehicle-details.component";

@Component({
  selector: "app-vehicle-create",
  standalone: true,
  imports: [CommonModule, VehicleDetailsComponent],
  templateUrl: "./vehicle-create.component.html",
  styleUrl: "./vehicle-create.component.scss",
})
export class VehicleCreateComponent {
  vehicle: Vehicle = <Vehicle>{};
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
