import {Component, OnInit} from '@angular/core';
import {Observable} from "rxjs";
import {IBasket, IBasketItem, IBasketTotals} from "../../shared/models/basket";
import {BasketService} from "../basket.service";

@Component({
  selector: 'app-basket',
  templateUrl: './basket.component.html',
  styleUrls: ['./basket.component.scss']
})
export class BasketComponent implements OnInit {

  //region Properties
  basket$: Observable<IBasket>;
  basketTotal$: Observable<IBasketTotals> = this.basketService.basketTotal$;
  /*totalPrice: number = 0;*/
  //endregion

  //region Constructor

  constructor(
    private basketService: BasketService
  ) {}

  //endregion

  //region Methods

  ngOnInit(): void {
    this.basket$ = this.basketService.basket$;
    /*this.calculateTotalPrice();*/
  }

  removeBasketItem(item: IBasketItem): void {
    this.basketService.removeItemFromBasket(item);
  }

  incrementItemQuantity(item: IBasketItem): void {
    this.basketService.incrementItemQuantity(item);
  }

  decrementItemQuantity(item: IBasketItem): void {
    this.basketService.decrementItemQuantity(item);
  }

  //endregion

}
