import { TestBed } from '@angular/core/testing';

import { DadosLoginService } from './dados-login.service';

describe('DadosLoginService', () => {
  let service: DadosLoginService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DadosLoginService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
