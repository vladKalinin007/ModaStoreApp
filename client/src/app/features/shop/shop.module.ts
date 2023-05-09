import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShopComponent } from './shop.component';
import { ProductItemComponent } from './product-item/product-item.component';
import {FormsModule} from "@angular/forms";
import { ProductDetailsComponent } from './product-details/product-details.component';
import {ShopRoutingModule} from "./shop-routing.module";
import {FeaturesModule} from "../features.module";



@NgModule({
    declarations: [
        ShopComponent,
        ProductItemComponent,
        ProductDetailsComponent,
    ],
    exports: [

    ],
    imports: [
        FeaturesModule,
        FormsModule,
        ShopRoutingModule,
    ]
})
export class ShopModule { }
