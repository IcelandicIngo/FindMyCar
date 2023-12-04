import { Vehicle } from "./Vehicle";
export interface PagedResult {
  page: number;
  pageSize: number;
  result: Vehicle[];
  total: number;
}
