import {Component, Input} from '@angular/core';
import {IProduct} from "../../../core/models/product";
import {BasketService} from "../../../features/basket/basket.service";
import {WishlistService} from "../../../features/wishlist/wishlist.service";
import {IWishlistItem} from "../../../core/models/customer/wishlistItem";

@Component({
  selector: 'app-product-item',
  templateUrl: './product-item.component.html',
  styleUrls: ['./product-item.component.scss']
})
export class ProductItemComponent {

  @Input() product: IProduct;
  @Input() isFavoritesIconVisible: boolean = true;
  @Input() isCaptionVisible: boolean;

  constructor(
    private basketService: BasketService,
    private wishlistService: WishlistService,
  ) { }

  addItemToBasket() {
    this.basketService.addItemToBasket(this.product);
  }

  addItemToWishlist() {
    this.wishlistService.addItemToWishlist(this.product);
  }

  removeItemFromWishlist() {
    this.wishlistService.removeItemFromWishlist(this.product.id);
  }

}
