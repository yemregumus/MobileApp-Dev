import { Component, ElementRef, ViewChild, AfterViewInit } from '@angular/core';
import { Geolocation } from '@capacitor/geolocation';
import { GoogleMap } from '@capacitor/google-maps';

@Component({
  selector: 'app-home',
  templateUrl: 'home.page.html',
  styleUrls: ['home.page.scss'],
})
export class HomePage implements AfterViewInit {
  lat: number = 0;
  long: number = 0;

  @ViewChild('map', { static: false }) mapRef?: ElementRef<HTMLElement>;
  newMap?: GoogleMap;

  constructor() {}

  ngAfterViewInit() {
    this.displayMap();
  }

  async getCurrentLocation() {
    console.log('Getting current location..');

    const { coords: coordinates } = await Geolocation.getCurrentPosition();
    const { latitude, longitude } = coordinates;

    this.lat = latitude;
    this.long = longitude;

    console.log('Current position:', coordinates, latitude, longitude);
  }

  async displayMap() {
    if (this.mapRef) {
      this.newMap = await GoogleMap.create({
        id: 'my-cool-map',
        element: this.mapRef.nativeElement,
        apiKey: 'AIzaSyAzddKcWHFxstsZzqHHuZjpGJb2Kpy4Ic8',
        config: {
          center: {
            lat: this.lat || 33.6, // Use current location if available
            lng: this.long || -117.9, // Use current location if available
          },
          zoom: 8,
        },
      });
    } else {
      console.error('Map element not available');
    }
  }
}
