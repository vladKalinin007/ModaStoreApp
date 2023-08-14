import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {IProduct} from "../../../core/models/product";
import {BasketService} from "../../../features/basket/basket.service";
import {WishlistService} from "../../../features/wishlist/wishlist.service";
import {IWishlistItem} from "../../../core/models/customer/wishlistItem";
import {ActivatedRoute, Router} from "@angular/router";
import {IProductColor} from "../../../core/models/catalog/product-color";
import {IProductImage} from "../../../core/models/catalog/product-image";

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
  @Output() productClicked: EventEmitter<string> = new EventEmitter<string>();

  productColors: IProductColor[];
  productImages: IProductImage[];
  imageIndex: number = 0;

  id: string;

  constructor(
    private basketService: BasketService,
    private wishlistService: WishlistService,
    private activatedRoute: ActivatedRoute,
    private router: Router,
  ) { }

  ngOnInit(): void {
    this.productColors = this.product.colors;
    this.productImages = this.product.pictures;
  }

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

  setImageIndex(index: number) {
    this.imageIndex = index;
  }

}
