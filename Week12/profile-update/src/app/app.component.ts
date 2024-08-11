import { Component } from '@angular/core';
import { Storage } from '@ionic/storage-angular';

@Component({
  selector: 'app-root',
  templateUrl: 'app.component.html',
  styleUrls: ['app.component.scss'],
})
export class AppComponent {
  isLoggedIn: boolean = false;

  constructor(private storage: Storage) {
    this.initializeApp();
  }

  async initializeApp() {
    await this.storage.create();
    this.isLoggedIn = !!(await this.storage.get('user'));
  }

  async logout() {
    await this.storage.remove('user');
    this.isLoggedIn = false;
  }
}
