import {Component, NgZone, OnInit} from '@angular/core';
import {IProduct} from "../../../core/models/product";
import {ShopService} from "../shop.service";
import {IPagination} from "../../../core/models/pagination";
import {ActivatedRoute} from "@angular/router";
import {BreadcrumbService} from "xng-breadcrumb";
import {BasketService} from "../../basket/basket.service";

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss']
})
export class ProductDetailsComponent implements OnInit {

  //region Properties

  product: IProduct;
  /*quantity = 1;*/

  //endregion

  //region Constructor

  constructor(
    private shopService: ShopService,
    private activateRoute: ActivatedRoute,
    private bcService: BreadcrumbService,
    private basketService: BasketService
  ) {
    this.bcService.set('@productDetails', '');
  }

  //endregion

  //region Methods

  ngOnInit(): void {
    this.loadProduct();
  }

  addItemToBasket() {
    this.basketService.addItemToBasket(this.product);
  }

  /*incrementQuantity() {
    this.quantity++;
  }

  decrementQuantity() {
    if (this.quantity > 1) {
      this.quantity--;
    }
  }*/

  loadProduct() {
    this.shopService.getProduct(+this.activateRoute.snapshot.paramMap.get('id'))
      .subscribe({
        next: (response: IProduct) => {
          this.product = response;
          this.bcService.set('@productDetails', this.product.name);
        },
        error: (error) => {
          console.log(error);
        }
      });
  }

  //endregion

}
