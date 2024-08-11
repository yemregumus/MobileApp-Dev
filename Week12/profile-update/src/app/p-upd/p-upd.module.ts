import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { PUpdPageRoutingModule } from './p-upd-routing.module';

import { PUpdPage } from './p-upd.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    PUpdPageRoutingModule,
    ReactiveFormsModule,
  ],
  declarations: [PUpdPage],
})
export class PUpdPageModule {}
