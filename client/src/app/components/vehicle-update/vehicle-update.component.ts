import { Component, OnInit } from "@angular/core";
import { CommonModule } from "@angular/common";
import { Brand } from "@interfaces/Brand";
import { VehicleEquipment } from "@interfaces/VehicleEquipment";
import { Vehicle } from "@interfaces/Vehicle";
import { VehicleDetailsComponent } from "@components/vehicle-details/vehicle-details.component";
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { VehicleService } from "@services/vehicle-service.service";

@Component({
  selector: "app-vehicle-update",
  standalone: true,
  imports: [CommonModule, VehicleDetailsComponent],
  templateUrl: "./vehicle-update.component.html",
  styleUrl: "./vehicle-update.component.scss",
})
export class VehicleUpdateComponent implements OnInit {
  vehicleDetails: Vehicle = <Vehicle>{};

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private service: VehicleService) {}  
    ngOnInit(): void {
      this.route.paramMap.subscribe((obs) => {
        this.service.get(Number(obs.get('id'))).subscribe(
          {
            next: this.getVehicleHandler.bind(this),
            error: console.error
          }        
        );
      });
    }

    onSubmit(vehicle: Vehicle) {
      console.log(vehicle);
      this.service.update(vehicle.id, vehicle).subscribe(
        {
          next: this.vehicleUpdatedHandler.bind(this),
          error: console.error
        }      
      )
    }
    vehicleUpdatedHandler(vehicle: Vehicle) {
      this.router.navigate(['/'])
    }

    getVehicleHandler(vehicle: Vehicle) {
      this.vehicleDetails = vehicle;
    }

}
