import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {PaginationModule} from "ngx-bootstrap/pagination";
import { PagingHeaderComponent } from './components/paging-header/paging-header.component';
import { PagerComponent } from './components/pager/pager.component';
import { CarouselModule } from 'primeng/carousel';
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
import {MatDialogModule} from "@angular/material/dialog";
import {SliderModule} from "primeng/slider";
import {RatingModule} from "primeng/rating";
import {RadioButtonModule} from "primeng/radiobutton";
import {GalleriaModule} from "primeng/galleria";
import {BadgeModule} from "primeng/badge";
import {BrowserAnimationsModule} from "@angular/platform-browser/animations";
import {SpeedDialModule} from "primeng/speeddial";
import {SelectButtonModule} from "primeng/selectbutton";
import {ToggleButtonModule} from "primeng/togglebutton";
import {OverlayPanelModule} from "primeng/overlaypanel";
import {TabViewModule} from "primeng/tabview";
import {InputMaskModule} from "primeng/inputmask";
import {AccordionModule} from "primeng/accordion";
import {TriStateCheckboxModule} from "primeng/tristatecheckbox";
import {TagModule} from "primeng/tag";
import {SidebarModule} from "primeng/sidebar";

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
    /*BrowserAnimationsModule,*/
    RouterLink,
    ReactiveFormsModule,
    MatSelectModule,
    MatFormFieldModule,
    MatMenuModule,
    RouterModule,
    MatDialogModule,
    SliderModule,
    RatingModule,
    RadioButtonModule,
    GalleriaModule,
    BadgeModule,
    SpeedDialModule,
    SelectButtonModule,
    ToggleButtonModule,
    OverlayPanelModule,
    TabViewModule,
    InputMaskModule,
    AccordionModule,
    TriStateCheckboxModule,
    CarouselModule,
    TagModule,
    SidebarModule
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
    CheckoutOptionContainerComponent,
    MatDialogModule,
    SliderModule,
    RatingModule,
    RadioButtonModule,
    GalleriaModule,
    BadgeModule,
    SpeedDialModule,
    SelectButtonModule,
    ToggleButtonModule,
    OverlayPanelModule,
    TabViewModule,
    InputMaskModule,
    AccordionModule,
    TriStateCheckboxModule,
    CarouselModule,
    TagModule,
    SidebarModule
  ]
})
export class SharedModule { }
