import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AcumuladorComponent } from './acumulador.component';

describe('AcumuladorComponent', () => {
  let component: AcumuladorComponent;
  let fixture: ComponentFixture<AcumuladorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AcumuladorComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AcumuladorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
