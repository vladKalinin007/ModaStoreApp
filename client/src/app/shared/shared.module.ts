import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {PaginationModule} from "ngx-bootstrap/pagination";
import { PagingHeaderComponent } from './components/paging-header/paging-header.component';
import { PagerComponent } from './components/pager/pager.component';
import {CarouselModule} from "ngx-bootstrap/carousel";
import { OrderTotalsComponent } from './components/order-totals/order-totals.component';
import {RouterLink, RouterModule} from "@angular/router";
import {ReactiveFormsModule} from "@angular/forms";
import {MatSelectModule} from "@angular/material/select";
import {MatFormFieldModule} from "@angular/material/form-field";
import {MatMenuModule} from "@angular/material/menu";
import { TextInputComponent } from './components/text-input/text-input.component';
import { StepperComponent } from './components/stepper/stepper.component';
import { BasketSummaryComponent } from './components/basket-summary/basket-summary.component';
import { CheckoutOptionContainerComponent } from './components/checkout-option-container/checkout-option-container.component';

@NgModule({
  declarations: [
    PagingHeaderComponent,
    PagerComponent,
    OrderTotalsComponent,
    TextInputComponent,
    StepperComponent,
    BasketSummaryComponent,
    CheckoutOptionContainerComponent
  ],
  imports: [
    CommonModule,
    PaginationModule.forRoot(),
    CarouselModule.forRoot(),
    RouterLink,
    ReactiveFormsModule,
    MatSelectModule,
    MatFormFieldModule,
    MatMenuModule,
    RouterModule,

  ],
  exports: [
    PaginationModule,
    PagingHeaderComponent,
    PagerComponent,
    CarouselModule,
    OrderTotalsComponent,
    ReactiveFormsModule,
    MatSelectModule,
    MatFormFieldModule,
    MatMenuModule,
    TextInputComponent,
    BasketSummaryComponent,
    CheckoutOptionContainerComponent
  ]
})
export class SharedModule { }
