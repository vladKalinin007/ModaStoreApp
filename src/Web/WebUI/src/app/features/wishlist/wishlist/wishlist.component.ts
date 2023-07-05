import {Component, OnInit} from '@angular/core';
import {WishlistService} from "../wishlist.service";
import {IWishlist} from "../../../core/models/customer/wishlist";
import {Observable} from "rxjs";
import {IWishlistItem} from "../../../core/models/customer/wishlistItem";
import {map} from "rxjs/operators";
import {IProduct} from "../../../core/models/product";
import { BasketService } from '../../basket/basket.service';
import {IBasket} from "../../../core/models/basket";


@Component({
  selector: 'app-wishlist',
  templateUrl: './wishlist.component.html',
  styleUrls: ['./wishlist.component.scss']
})
export class WishlistComponent implements OnInit {

  products$: Observable<IProduct[]>;

  constructor(private wishlistService: WishlistService) {}

  ngOnInit() {
    this.products$ = this.wishlistService.wishlist$.pipe(
      map(wishlist => wishlist.wishlistItems.map(item => ({
        id: item.id,
        name: item.name,
        description: item.description,
        price: item.price,
        pictureUrl: item.pictureUrl,
        productType: item.productType,
        productBrand: item.productBrand
      } as IProduct)))
    );
  }


}
