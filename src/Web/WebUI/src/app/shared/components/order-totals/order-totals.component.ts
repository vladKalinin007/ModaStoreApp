import {Component, OnInit} from '@angular/core';
import {Observable} from "rxjs";
import {IBasketTotals} from "../../../core/models/basket";
import {BasketService} from "../../../features/basket/basket.service";

@Component({
  selector: 'app-order-totals',
  templateUrl: './order-totals.component.html',
  styleUrls: ['./order-totals.component.scss']
})
export class OrderTotalsComponent implements OnInit {

    basketTotal$: Observable<IBasketTotals> = this.basketService.basketTotal$;
    shippingPrice$: Observable<number> = this.basketService.shipping$;

    constructor(
      private basketService: BasketService
    ) {}


    ngOnInit(): void {
      this.basketTotal$ = this.basketService.basketTotal$;
      this.shippingPrice$ = this.basketService.shipping$;
    }


}
