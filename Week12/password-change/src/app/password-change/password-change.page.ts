import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-password-change',
  templateUrl: './password-change.page.html',
  styleUrls: ['./password-change.page.scss'],
})
export class PasswordChangePage implements OnInit {
  passwordChangeForm: FormGroup = this.fb.group({}); // Initialize with an empty form
  storedPassword = 'password123'; // Example of a locally stored password
  isLoggedIn = true; // Assume the user is logged in for this example

  constructor(private fb: FormBuilder) {
    this.passwordChangeForm = this.fb.group(
      {
        oldPassword: ['', Validators.required],
        newPassword: ['', [Validators.required, Validators.minLength(8)]],
        confirmPassword: ['', Validators.required],
      },
      { validators: this.passwordMatchValidator }
    );
  }
  ngOnInit(): void {
    throw new Error('Method not implemented.');
  }

  passwordMatchValidator(form: FormGroup) {
    const newPassword = form.get('newPassword')?.value || ''; // Using optional chaining and fallback
    const confirmPassword = form.get('confirmPassword')?.value || ''; // Using optional chaining and fallback

    return newPassword === confirmPassword ? null : { mismatch: true };
  }

  onSubmit() {
    if (!this.passwordChangeForm.valid) {
      return;
    }

    const oldPassword = this.passwordChangeForm.get('oldPassword')?.value || ''; // Optional chaining with fallback

    if (oldPassword !== this.storedPassword) {
      alert('Old password is incorrect');
      return;
    }

    alert('Password changed successfully!');
  }

  logout() {
    this.isLoggedIn = false;
    alert('Logged out successfully');
  }
}
