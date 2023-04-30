import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import {AccountRoutingModule} from "./account-routing.module";
import {SharedModule} from "../shared/shared.module";
import { SettingsComponent } from './settings/settings.component';
import { ReviewsComponent } from './reviews/reviews.component';
import { WalletComponent } from './wallet/wallet.component';
import { OrdersComponent } from './orders/orders.component';
import { WishlistComponent } from './wishlist/wishlist.component';



@NgModule({
  declarations: [
    LoginComponent,
    RegisterComponent,
    SettingsComponent,
    ReviewsComponent,
    WalletComponent,
    OrdersComponent,
    WishlistComponent
  ],
  imports: [
    CommonModule,
    AccountRoutingModule,
    SharedModule
  ]
})
export class AccountModule { }