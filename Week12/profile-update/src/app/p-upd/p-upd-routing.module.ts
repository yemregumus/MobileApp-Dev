import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { PUpdPage } from './p-upd.page';

const routes: Routes = [
  {
    path: '',
    component: PUpdPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class PUpdPageRoutingModule {}
