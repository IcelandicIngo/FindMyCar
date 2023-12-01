import { VehicleEquipment } from "./Vehicle";
export interface PagedResult {
  page: number;
  pageSize: number;
  result: Vehicle[];
}
