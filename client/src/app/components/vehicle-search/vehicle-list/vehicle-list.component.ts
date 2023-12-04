import { Component, Input, Output, EventEmitter } from "@angular/core";
import { CommonModule } from "@angular/common";
import { Vehicle } from "@interfaces/Vehicle";
import { MatIconModule } from "@angular/material/icon";
import { MatListModule } from "@angular/material/list";
import { MatExpansionModule } from '@angular/material/expansion';
import { MatFormFieldModule } from "@angular/material/form-field";
import { RouterModule } from "@angular/router";
import { VehicleService } from "@services/vehicle-service.service";

@Component({
  selector: "app-vehicle-list",
  standalone: true,
  imports: [CommonModule, MatIconModule, MatListModule, MatExpansionModule, MatFormFieldModule, RouterModule],
  templateUrl: "./vehicle-list.component.html",
  styleUrl: "./vehicle-list.component.scss",
})
export class VehicleListComponent {
  @Input()
  vehicles: Vehicle[] = [];
}
