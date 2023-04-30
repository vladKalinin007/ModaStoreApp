import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {HomeComponent} from "./home/home/home.component";
import {TestErrorComponent} from "./core/components/test-error/test-error.component";
import {ServerErrorComponent} from "./core/components/server-error/server-error.component";
import {NotFoundComponent} from "./core/components/not-found/not-found.component";
import {BasketComponent} from "./basket/basket/basket.component";
import {AuthGuard} from "./core/guards/auth.guard";

const routes: Routes = [
  { path: '', component: HomeComponent, data: {breadcrumb: 'Home'} },
  { path: 'test-error', component: TestErrorComponent, data: {breadcrumb: 'Test Error'} },
  { path: 'server-error', component: ServerErrorComponent, data : {breadcrumb: 'Server Error'} },
  { path: 'not-found', component: NotFoundComponent, data: {breadcrumb: 'Not Found'} },
  { path: 'shop', loadChildren: () => import('./shop/shop.module')
      .then(m => m.ShopModule), data: {breadcrumb: 'Shop'} },
  { path: 'basket', loadChildren: () => import('./basket/basket.module')
      .then(m => m.BasketModule), data: {breadcrumb: 'Basket'} },
  { path: 'checkout',
    canActivate: [AuthGuard],
    loadChildren: () => import('./checkout/checkout.module')
      .then(m => m.CheckoutModule), data: {breadcrumb: 'Checkout'} },
  { path: 'account', loadChildren: () => import('./account/account.module')
      .then(m => m.AccountModule), data: {breadcrumb: {skip: true} }, },
  { path: '**', redirectTo: 'not-found', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {
    useHash: false
  })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
