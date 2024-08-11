import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Storage } from '@ionic/storage-angular';

@Component({
  selector: 'app-p-upd',
  templateUrl: './p-upd.page.html',
  styleUrls: ['./p-upd.page.scss'],
})
export class PUpdPage implements OnInit {
  profileForm: FormGroup = this.fb.group({}); // Initialize with an empty form

  constructor(private fb: FormBuilder, private storage: Storage) {}

  ngOnInit() {
    this.initializeForm();
    this.loadProfile();
  }

  private initializeForm() {
    this.profileForm = this.fb.group({
      fullName: ['', [Validators.required, Validators.minLength(3)]],
      email: ['', [Validators.required, Validators.email]],
      phone: [
        '',
        [Validators.required, Validators.pattern('^\\+?[1-9][0-9]{7,14}$')],
      ], // Example pattern for international phone numbers
    });
  }

  private async loadProfile() {
    await this.storage.create();
    const profile = await this.storage.get('profile');
    if (profile) {
      this.profileForm.setValue(profile);
    }
  }

  async onSubmit() {
    if (this.profileForm.valid) {
      await this.storage.set('profile', this.profileForm.value);
      alert('Profile updated successfully!');
    } else {
      alert('Please correct the errors in the form.');
    }
  }
}
