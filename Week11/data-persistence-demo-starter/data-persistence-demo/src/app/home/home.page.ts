import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { lastValueFrom } from 'rxjs';
import Digimon from '../models/Digimon';
import { Preferences } from '@capacitor/preferences';
import { ToastController } from '@ionic/angular';

@Component({
  selector: 'app-home',
  templateUrl: 'home.page.html',
  styleUrls: ['home.page.scss'],
})
export class HomePage {
  digimonList: Digimon[] = [];

  constructor(
    private http: HttpClient,
    private toastController: ToastController
  ) {}

  ngOnInit() {
    this.getDigimon();
  }

  async getDigimon() {
    try {
      const URL = 'https://digimon-api.vercel.app/api/digimon';
      const response: Digimon[] = await lastValueFrom(
        this.http.get<Digimon[]>(URL)
      );
      this.digimonList = response;
    } catch (e) {
      console.log('Error when executing getDigimon()');
      console.log(e);
    }
  }

  async rowPressed(selectedDigimon: Digimon) {
    try {
      let team = await Preferences.get({ key: 'DIGIMON_TEAM' });
      let teamList: Digimon[] = [];

      if (team.value) {
        try {
          teamList = JSON.parse(team.value);
        } catch (e) {
          console.log('Error parsing JSON:', e);
        }
      }

      teamList.push(selectedDigimon);

      await Preferences.set({
        key: 'DIGIMON_TEAM',
        value: JSON.stringify(teamList),
      });
      console.log('SUCCESS: Data saved!');

      const toast = await this.toastController.create({
        message: `Saved: ${selectedDigimon.name}`,
        duration: 1500,
        position: 'bottom',
      });

      await toast.present();
    } catch (e) {
      console.log(e);
    }
  }
}
