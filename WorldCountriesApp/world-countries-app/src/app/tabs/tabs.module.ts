import { IonicModule } from '@ionic/angular';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { TabsPage } from './tabs.page';

import { TabsRoutingModule } from './tabs-routing.module';

@NgModule({
  imports: [IonicModule, CommonModule, FormsModule, TabsRoutingModule],
  declarations: [TabsPage],
})
export class TabsPageModule {}
