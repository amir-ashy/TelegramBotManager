import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';

import { BotRoutingModule } from './bot-routing.module';
import { BotComponent } from './bot.component';


@NgModule({
  declarations: [BotComponent],
  imports: [
    SharedModule,
    BotRoutingModule
  ]
})
export class BotModule { }
