import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { Preferences } from '@capacitor/preferences';
import { ToastController } from '@ionic/angular';
import { Country } from '../models/country';

@Component({
  selector: 'app-country-detail',
  templateUrl: './country-detail.page.html',
  styleUrls: ['./country-detail.page.scss'],
})
export class CountryDetailPage implements OnInit {
  country: Country | undefined;
  alpha3Code!: string | null;

  constructor(
    private route: ActivatedRoute,
    private http: HttpClient,
    private toastController: ToastController
  ) {}

  ngOnInit() {
    this.alpha3Code = this.route.snapshot.paramMap.get('alpha3Code');
    if (this.alpha3Code) {
      this.http
        .get<Country>(`https://restcountries.com/v2/alpha/${this.alpha3Code}`)
        .subscribe((data) => {
          this.country = data;
        });
    }
  }

  async addToFavorites() {
    const { value } = await Preferences.get({ key: 'favorites' });
    let favorites: Country[] = value ? JSON.parse(value) : [];
    if (!favorites.some((fav) => fav.alpha3Code === this.alpha3Code)) {
      favorites.push(this.country!);
      await Preferences.set({
        key: 'favorites',
        value: JSON.stringify(favorites),
      });
      this.showToast('Country added to favorites');
    } else {
      this.showToast('Country is already in favorites');
    }
  }

  async showToast(message: string) {
    const toast = await this.toastController.create({
      message,
      duration: 2000,
    });
    toast.present();
  }
}
