import { IonicModule } from '@ionic/angular';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { CountriesListPage } from './countries-list.page';

import { CountriesListPageRoutingModule } from './countries-list-routing.module';

@NgModule({
  imports: [
    IonicModule,
    CommonModule,
    FormsModule,
    CountriesListPageRoutingModule,
  ],
  declarations: [CountriesListPage],
})
export class CountriesListPageModule {}
