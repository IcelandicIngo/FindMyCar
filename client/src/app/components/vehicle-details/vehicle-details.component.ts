import { Component, Input, Output, EventEmitter, OnInit } from "@angular/core";
import { CommonModule } from "@angular/common";
import { MatFormFieldModule } from "@angular/material/form-field";
import { MatInputModule } from "@angular/material/input";
import { MatSelectModule } from "@angular/material/select";
import { MatCardModule } from "@angular/material/card";
import { Brand } from "@interfaces/Brand";
import { VehicleEquipment } from "@interfaces/VehicleEquipment";
import { Vehicle } from "@interfaces/Vehicle";
import { FormsModule } from "@angular/forms";

import {ReactiveFormsModule, FormGroup, FormControl, Validators} from '@angular/forms';
import { BrandService } from "@services/brand-service.service";
import { VehicleEquipmentService } from "@services/vehicle-equipment-service.service";
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
    ReactiveFormsModule
  ],
  templateUrl: "./vehicle-details.component.html",
  styleUrl: "./vehicle-details.component.scss",
})
export class VehicleDetailsComponent implements OnInit {
  creating: boolean = false;
  vehicleDetails: Vehicle = <Vehicle>{};
  brands: Brand[] = [];
  vehicleEquiments: VehicleEquipment[] = [];
  detailsForm = new FormGroup({
    vin: new FormControl('', [Validators.required]),
    license: new FormControl('', [Validators.required]),
    name: new FormControl('', [Validators.required]),
    brand: new FormControl('', [Validators.required])
  });
  @Input()
  set vehicle(vehicle: Vehicle) {
    if (vehicle)
    {
      this.vehicleDetails = vehicle;
      this.creating = true;
    }
  }

  @Output() onSubmit = new EventEmitter<Vehicle>();
  @Output() onDelete = new EventEmitter<Vehicle>();
  constructor(private brandService: BrandService, private vehicleEquipmentService: VehicleEquipmentService)
  {

  }  
  ngOnInit(): void {
    this.brandService.get().subscribe(
      {
        next: this.getBrandsHandler.bind(this),
        error: console.error
      }
    );
    this.vehicleEquipmentService.get().subscribe(
      {
        next: this.getVehicleEquipmentHandler.bind(this),
        error: console.error
      }
    );    
  }

  delete(vehicle: Vehicle) {
    this.onDelete.emit(this.vehicleDetails);
  }

  getVehicleEquipmentHandler(equipments: VehicleEquipment[])
  {
    this.vehicleEquiments = equipments;
  }

  getBrandsHandler(brands: Brand[])
  {
    this.brands = brands;
  }
  submit(valid: boolean) {
    console.log(valid);
    this.onSubmit.emit(this.vehicleDetails);
    // TODO FIX FKN FORM
  }
}
