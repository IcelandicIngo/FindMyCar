import { Routes } from "@angular/router";

export const routes: Routes = [
  {
    path: "",
    loadComponent: () =>
      import("./components/vehicle-search/vehicle-search.component").then(
        (m) => m.VehicleSearchComponent
      ),
  },
  {
    path: "reg",
    loadComponent: () =>
      import("./components/vehicle-create/vehicle-create.component").then(
        (m) => m.VehicleCreateComponent
      ),
  },
  {
    path: "update/:id",
    loadComponent: () =>
      import("./components/vehicle-update/vehicle-update.component").then(
        (m) => m.VehicleUpdateComponent
      ),
  },
];
