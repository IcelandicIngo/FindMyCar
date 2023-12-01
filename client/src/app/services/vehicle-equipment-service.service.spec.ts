import { TestBed } from '@angular/core/testing';

import { VehicleEquipmentServiceService } from './vehicle-equipment-service.service';

describe('VehicleEquipmentServiceService', () => {
  let service: VehicleEquipmentServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(VehicleEquipmentServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
