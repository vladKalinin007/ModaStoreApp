import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {CoreModule} from "../core/core.module";
import {SharedModule} from "../shared/shared.module";



@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    CoreModule,
    SharedModule
  ],
  exports: [
    CoreModule,
    SharedModule,
    CommonModule
  ]
})
export class FeaturesModule { }
