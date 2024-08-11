import { Injectable } from '@angular/core';
import { Preferences } from '@capacitor/preferences';
import { Country } from '../models/country';

@Injectable({
  providedIn: 'root',
})
export class FavoritesService {
  private readonly FAVORITES_KEY = 'favorites';

  async getFavorites(): Promise<Country[]> {
    const { value } = await Preferences.get({ key: this.FAVORITES_KEY });
    return value ? JSON.parse(value) : [];
  }

  async addFavorite(country: Country): Promise<void> {
    const favorites = await this.getFavorites();
    favorites.push(country);
    await Preferences.set({
      key: this.FAVORITES_KEY,
      value: JSON.stringify(favorites),
    });
  }

  async removeFavorite(alpha3Code: string): Promise<void> {
    let favorites = await this.getFavorites();
    favorites = favorites.filter((c) => c.alpha3Code !== alpha3Code);
    await Preferences.set({
      key: this.FAVORITES_KEY,
      value: JSON.stringify(favorites),
    });
  }

  async clearFavorites(): Promise<void> {
    await Preferences.remove({ key: this.FAVORITES_KEY });
  }
}
