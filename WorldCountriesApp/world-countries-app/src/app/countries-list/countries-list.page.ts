import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { Country } from '../models/country';

@Component({
  selector: 'app-countries-list',
  templateUrl: './countries-list.page.html',
  styleUrls: ['./countries-list.page.scss'],
})
export class CountriesListPage implements OnInit {
  countries: Country[] = [];

  constructor(private http: HttpClient, private router: Router) {}

  ngOnInit() {
    this.http
      .get<Country[]>('https://restcountries.com/v2/all')
      .subscribe((data) => {
        this.countries = data;
      });
  }

  goToDetail(alpha3Code: string) {
    this.router.navigate(['/tabs/country-detail', alpha3Code]);
  }
}
