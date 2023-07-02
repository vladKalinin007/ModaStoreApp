import { NgModule } from '@angular/core';
import { WishlistComponent } from './wishlist/wishlist.component';
import {SharedModule} from "../../shared/shared.module";
import {FeaturesModule} from "../features.module";

@NgModule({
  declarations: [
    WishlistComponent
  ],
    imports: [
        FeaturesModule,
        SharedModule
    ]
})
export class WishlistModule { }
