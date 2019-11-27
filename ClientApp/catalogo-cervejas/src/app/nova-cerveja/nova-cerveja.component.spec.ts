import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NovaCervejaComponent } from './nova-cerveja.component';

describe('NovaCervejaComponent', () => {
  let component: NovaCervejaComponent;
  let fixture: ComponentFixture<NovaCervejaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NovaCervejaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NovaCervejaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
