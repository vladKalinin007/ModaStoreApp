import {Component, Input, OnInit} from '@angular/core';
import {IProduct} from "../../../core/models/product";
import {BasketService} from "../../../features/basket/basket.service";
import {WishlistService} from "../../../features/wishlist/wishlist.service";
import {IWishlistItem} from "../../../core/models/customer/wishlistItem";
import {ActivatedRoute, Router} from "@angular/router";

@Component({
  selector: 'app-product-item',
  templateUrl: './product-item.component.html',
  styleUrls: ['./product-item.component.scss']
})
export class ProductItemComponent {

  @Input() product: IProduct;
  @Input() isFavoritesIconVisible: boolean = true;
  @Input() isCaptionVisible: boolean;
  @Input() categoryName: string;

  id: string;

  constructor(
    private basketService: BasketService,
    private wishlistService: WishlistService,
    private activatedRoute: ActivatedRoute,
    private router: Router,
  ) { }

  onProductClicked(productId: string) {
    let categoryName: string = this.activatedRoute.snapshot.paramMap.get('categoryName');

    if (categoryName === '') {
      categoryName = this.categoryName;
    }

    this.router.navigate(['shop', categoryName, productId]);
  }

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
