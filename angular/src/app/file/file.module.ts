import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';

import { FileRoutingModule } from './file-routing.module';
import { FileComponent } from './file.component';


@NgModule({
  declarations: [FileComponent],
  imports: [
    SharedModule,
    FileRoutingModule,

  ]
})
export class FileModule { }
