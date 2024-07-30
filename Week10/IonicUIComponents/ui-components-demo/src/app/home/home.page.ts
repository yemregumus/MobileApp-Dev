import { Component } from '@angular/core';
import { Router } from '@angular/router';
import Student from '../models/Student';

@Component({
  selector: 'app-home',
  templateUrl: 'home.page.html',
  styleUrls: ['home.page.scss'],
})
export class HomePage {
  constructor(private router: Router) {}
  addFruit() {
    this.fruitsList.push(this.fruit);
    this.fruit = '';
  }

  text = 'Welcome to my app';
  name: string = '';
  age: number = 0;
  fruit: string = '';

  fruitsList = ['Apple', 'Banana', 'Cherry', 'Mango'];

  buttonSubmit() {
    console.log(`Hi ${this.name}! You are ${this.age} years old.`);
    this.text = `Hi ${this.name}! You are ${this.age} years old.`;

    let student: Student = {
      name: this.name,
      age: this.age,
    };

    this.router.navigate(['/second-page'], {
      queryParams: {
        student: JSON.stringify(student),
      },
    });
  }

  buttonReset() {
    console.log('Data Reset!');
    this.text = 'Welcome to my app';
    this.name = '';
    this.age = 0;
  }
}
