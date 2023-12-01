import { Brand } from "./Brand";
import { VehicleEquipment } from "./VehicleEquipment";

export interface Vehicle {
  id: number;
  vehicleIdentificationNumber: string;
  modelName: string;
  licenseNumber: string;
  brandId: number;
  vehicleEquipmentIds: number[];
}
