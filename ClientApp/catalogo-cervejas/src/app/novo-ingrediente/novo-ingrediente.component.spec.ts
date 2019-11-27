import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NovoIngredienteComponent } from './novo-ingrediente.component';

describe('NovoIngredienteComponent', () => {
  let component: NovoIngredienteComponent;
  let fixture: ComponentFixture<NovoIngredienteComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NovoIngredienteComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NovoIngredienteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
