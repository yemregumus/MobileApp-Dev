import { IonicModule } from '@ionic/angular';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { CountryDetailPage } from './country-detail.page';

import { CountryDetailPageRoutingModule } from './country-detail-routing.module';

@NgModule({
  imports: [
    IonicModule,
    CommonModule,
    FormsModule,
    CountryDetailPageRoutingModule,
  ],
  declarations: [CountryDetailPage],
})
export class CountryDetailPageModule {}
