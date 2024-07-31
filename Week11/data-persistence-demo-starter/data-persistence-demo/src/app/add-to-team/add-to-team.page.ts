import { Component, OnInit } from '@angular/core';
import { Preferences } from '@capacitor/preferences';
import Digimon from '../models/Digimon';

@Component({
  selector: 'app-add-to-team',
  templateUrl: './add-to-team.page.html',
  styleUrls: ['./add-to-team.page.scss'],
})
export class AddToTeamPage implements OnInit {
  teamMembers: Digimon[] = [];

  constructor() {}

  async ngOnInit() {
    try {
      let results = await Preferences.get({ key: 'DIGIMON_TEAM' });
      if (results.value === null) {
        console.log('This key does not exist');
        return;
      }

      this.teamMembers = JSON.parse(results.value);
    } catch (e) {
      console.log(e);
    }
  }
}
