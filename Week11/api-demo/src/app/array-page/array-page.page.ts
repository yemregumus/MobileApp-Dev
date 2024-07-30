import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { lastValueFrom } from 'rxjs';
import Digimon from '../models/Digimon';
import { DefaultUrlSerializer } from '@angular/router';

@Component({
  selector: 'app-array-page',
  templateUrl: './array-page.page.html',
  styleUrls: ['./array-page.page.scss'],
})
export class ArrayPagePage implements OnInit {
  digimons: Digimon[] = [] as Digimon[];
  constructor(private http: HttpClient) {}

  ngOnInit() {
    // called after the constructor has been called
    // write the code to connect to the api
    this.getDigimons();
  }

  // helper function
  async getDigimons() {
    try {
      // define the endpoint
      const URL = 'https://digimon-api.vercel.app/api/digimon';

      // get the response
      // lastValueFrom is used to extract the last value from an Observable once it completes.
      // it allows you to convert an Observable to a Promise, which can then be used with async/await.
      this.digimons = await lastValueFrom(this.http.get<Digimon[]>(URL));
    } catch (error) {
      console.log('Error: ', error);
    }
  }
}
