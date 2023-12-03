import { Component} from "@angular/core";
import { CommonModule } from "@angular/common";
import { Vehicle } from "@interfaces/Vehicle";
import { VehicleDetailsComponent } from "@components/vehicle-details/vehicle-details.component";
import { VehicleService } from "@services/vehicle-service.service";

@Component({
  selector: "app-vehicle-create",
  standalone: true,
  imports: [CommonModule, VehicleDetailsComponent],
  templateUrl: "./vehicle-create.component.html",
  styleUrl: "./vehicle-create.component.scss",
})
export class VehicleCreateComponent  {
  constructor(private vehicleService: VehicleService){}
  onSubmit(vehicle: Vehicle) {
    this.vehicleService.create(vehicle).subscribe(
      {
        next: this.vehicleCreatedHandler.bind(this),
        error: console.error
      }      
    )
  }

  vehicleCreatedHandler(vehicle: Vehicle) {
    console.log(vehicle);
  }
}
