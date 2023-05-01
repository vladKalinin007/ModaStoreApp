import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BasketComponent } from './basket/basket.component';
import {BasketRoutingModule} from "./basket-routing.module";
import {SharedModule} from "../../shared/shared.module";
import {MatDialogModule} from "@angular/material/dialog";
import {FeaturesModule} from "../features.module";




@NgModule({
  declarations: [
    BasketComponent
  ],
  imports: [
    FeaturesModule,
    BasketRoutingModule,
    MatDialogModule, // delete
  ]
})
export class BasketModule { }
