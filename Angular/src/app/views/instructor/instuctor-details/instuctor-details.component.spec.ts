import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InstuctorDetailsComponent } from './instuctor-details.component';

describe('InstuctorDetailsComponent', () => {
  let component: InstuctorDetailsComponent;
  let fixture: ComponentFixture<InstuctorDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ InstuctorDetailsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(InstuctorDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
