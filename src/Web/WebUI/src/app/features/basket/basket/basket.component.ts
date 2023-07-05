import {Component, OnInit} from '@angular/core';
import {Observable} from "rxjs";
import {IBasket, IBasketItem, IBasketTotals} from "../../../core/models/basket";
import {BasketService} from "../basket.service";
import {MatDialogRef} from "@angular/material/dialog";
import {BasketState} from "../reducers/basket.state";
import {Store} from "@ngrx/store";
import {BasketActions} from "../basket.actions";
import {WishlistService} from "../../wishlist/wishlist.service";
import {IWishlist} from "../../../core/models/customer/wishlist";

@Component({
  selector: 'app-basket',
  templateUrl: './basket.component.html',
  styleUrls: ['./basket.component.scss']
})
export class BasketComponent implements OnInit {

  basket$: Observable<IBasket>;
  wishlist$: Observable<IWishlist>;
  basketTotal$: Observable<IBasketTotals> = this.basketService.basketTotal$;
  basketItemsCount: number;
  count$: Observable<number>;

  constructor(
    private basketService: BasketService,
    private wishlistService: WishlistService,
    private dialogRef: MatDialogRef<BasketComponent>,
  ) {}

  calculateBasketItems() {
    this.basketItemsCount = this.basketService.countBasketItems()
    console.log("BASKET =", this.basket$)
  }

  closeDialog(): void {
    this.dialogRef.close();
    console.log('closeDialog()');
  }

  ngOnInit(): void {
    this.basket$ = this.basketService.basket$;
    this.wishlist$ = this.wishlistService.wishlist$;
    this.calculateBasketItems();
    console.log(this.basket$);
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

 /* incrementItemQuantity(item: IBasketItem): void {
    this.store$.dispatch(BasketActions.incrementItemQuantity())
  }

  decrementItemQuantity(item: IBasketItem): void {
    this.store.dispatch(decrementItemQuantity({ item })); // Используйте действие decrementItemQuantity и передайте элемент
  }*/



}
