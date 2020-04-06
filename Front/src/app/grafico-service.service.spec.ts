import { TestBed } from '@angular/core/testing';

import { GraficoServiceService } from './grafico-service.service';

describe('GraficoServiceService', () => {
  let service: GraficoServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(GraficoServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
