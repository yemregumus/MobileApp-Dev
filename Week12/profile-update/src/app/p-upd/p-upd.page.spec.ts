import { ComponentFixture, TestBed } from '@angular/core/testing';
import { PUpdPage } from './p-upd.page';

describe('PUpdPage', () => {
  let component: PUpdPage;
  let fixture: ComponentFixture<PUpdPage>;

  beforeEach(() => {
    fixture = TestBed.createComponent(PUpdPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
