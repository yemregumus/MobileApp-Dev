import { ComponentFixture, TestBed } from '@angular/core/testing';
import { CountriesListPage } from './countries-list.page';

describe('CountriesListPage', () => {
  let component: CountriesListPage;
  let fixture: ComponentFixture<CountriesListPage>;

  beforeEach(() => {
    fixture = TestBed.createComponent(CountriesListPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
