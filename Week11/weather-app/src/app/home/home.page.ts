import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { lastValueFrom } from 'rxjs';

@Component({
  selector: 'app-home',
  templateUrl: 'home.page.html',
  styleUrls: ['home.page.scss'],
})
export class HomePage {
  city: string = '';
  weather: any;

  private apiKey: string = '40cffaaab15a4a1c231e1d390022e1c8'; // Replace with your OpenWeatherMap API key
  private apiUrl: string = 'https://api.openweathermap.org/data/2.5/weather';

  constructor(private http: HttpClient) {}

  async getWeather(city: string) {
    if (!city) return;

    const url = `${this.apiUrl}?q=${city}&units=metric&appid=${this.apiKey}`;
    try {
      this.weather = await lastValueFrom(this.http.get(url));
    } catch (error) {
      console.error('Error fetching weather data:', error);
    }
  }
}
