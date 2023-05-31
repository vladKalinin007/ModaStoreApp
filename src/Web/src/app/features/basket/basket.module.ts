import { NgModule } from '@angular/core';
import { BasketComponent } from './basket/basket.component';
import {BasketRoutingModule} from "./basket-routing.module";
import {MatDialogModule} from "@angular/material/dialog";
import {FeaturesModule} from "../features.module";


@NgModule({
  declarations: [
    BasketComponent
  ],
  imports: [
    FeaturesModule,
    BasketRoutingModule,
  ]
})
export class BasketModule { }
