import { TestBed } from '@angular/core/testing';

import { ReservarCitaService } from './reservar-cita.service';

describe('ReservarCitaService', () => {
  let service: ReservarCitaService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ReservarCitaService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});