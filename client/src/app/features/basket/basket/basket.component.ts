import {Component, OnInit} from '@angular/core';
import {Observable} from "rxjs";
import {IBasket, IBasketItem, IBasketTotals} from "../../../core/models/basket";
import {BasketService} from "../basket.service";
import {MatDialogRef} from "@angular/material/dialog";

@Component({
  selector: 'app-basket',
  templateUrl: './basket.component.html',
  styleUrls: ['./basket.component.scss']
})
export class BasketComponent implements OnInit {

  basket$: Observable<IBasket>;
  basketTotal$: Observable<IBasketTotals> = this.basketService.basketTotal$;
  basketItemsCount: number;

  constructor(
    private basketService: BasketService,
    private dialogRef: MatDialogRef<BasketComponent>
  ) {}

  calculateBasketItems() {
    this.basketItemsCount = this.basketService.countBasketItems()
    console.log(this.basketItemsCount);
  }

  closeDialog(): void {
    this.dialogRef.close();
    console.log('closeDialog()');
  }

  ngOnInit(): void {
    this.basket$ = this.basketService.basket$;
    this.calculateBasketItems();
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


}
