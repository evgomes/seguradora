import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SelectTiposSeguroComponent } from './select-tipos-seguro.component';

describe('SelectTiposSeguroComponent', () => {
  let component: SelectTiposSeguroComponent;
  let fixture: ComponentFixture<SelectTiposSeguroComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SelectTiposSeguroComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SelectTiposSeguroComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
