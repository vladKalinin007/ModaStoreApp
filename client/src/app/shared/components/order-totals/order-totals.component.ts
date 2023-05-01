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

  //region Properties

    basketTotal$: Observable<IBasketTotals> = this.basketService.basketTotal$;

  //endregion

  //region Constructor

    constructor(
      private basketService: BasketService
    ) {}

  //endregion

  //region Methods

    ngOnInit(): void {
      this.basketTotal$ = this.basketService.basketTotal$;
    }

  //endregion

}
