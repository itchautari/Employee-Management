import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { OrgCustomCellEDDButtonsComponent } from './org-custom-cell-eddbuttons.component';

describe('OrgCustomCellEDDButtonsComponent', () => {
  let component: OrgCustomCellEDDButtonsComponent;
  let fixture: ComponentFixture<OrgCustomCellEDDButtonsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ OrgCustomCellEDDButtonsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(OrgCustomCellEDDButtonsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
