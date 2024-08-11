import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CountryDetailPage } from './country-detail.page';

const routes: Routes = [
  {
    path: '',
    component: CountryDetailPage,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class CountryDetailPageRoutingModule {}
