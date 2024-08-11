import { Component, OnInit } from '@angular/core';
import { FavoritesService } from './favorites.service';
import { Country } from '../models/country';

@Component({
  selector: 'app-favorites',
  templateUrl: './favorites.page.html',
  styleUrls: ['./favorites.page.scss'],
})
export class FavoritesPage implements OnInit {
  favorites: Country[] = [];

  constructor(private favoritesService: FavoritesService) {}

  async ngOnInit() {
    this.favorites = await this.favoritesService.getFavorites();
  }

  async addFavorite(country: Country) {
    await this.favoritesService.addFavorite(country);
    this.favorites = await this.favoritesService.getFavorites(); // Update local state
  }

  async removeFavorite(country: Country) {
    await this.favoritesService.removeFavorite(country.alpha3Code);
    this.favorites = await this.favoritesService.getFavorites(); // Update local state
  }

  async deleteAll() {
    await this.favoritesService.clearFavorites();
    this.favorites = []; // Clear local state
  }
}
