import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SeguroFormComponent } from './seguro-form.component';

describe('SeguroFormComponent', () => {
  let component: SeguroFormComponent;
  let fixture: ComponentFixture<SeguroFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SeguroFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SeguroFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
