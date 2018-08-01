/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { MowLawnComponent } from './mow-lawn.component';

describe('MowLawnComponent', () => {
  let component: MowLawnComponent;
  let fixture: ComponentFixture<MowLawnComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MowLawnComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MowLawnComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
