import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { path: '', redirectTo: 'news-list', pathMatch: 'full' },
  {
    path: 'news-list',
    loadChildren: () =>
      import('./news-list/news-list.module').then((m) => m.NewsListPageModule),
  },
  {
    path: 'news-details/:id',
    loadChildren: () =>
      import('./news-details/news-details.module').then(
        (m) => m.NewsDetailsPageModule
      ),
  },
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules }),
  ],
  exports: [RouterModule],
})
export class AppRoutingModule {}
