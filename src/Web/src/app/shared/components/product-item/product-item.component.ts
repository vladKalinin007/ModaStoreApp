import {Component, Input} from '@angular/core';
import {IProduct} from "../../../core/models/product";
import {BasketService} from "../../../features/basket/basket.service";

@Component({
  selector: 'app-product-item',
  templateUrl: './product-item.component.html',
  styleUrls: ['./product-item.component.scss']
})
export class ProductItemComponent {
  @Input() product: IProduct;
  @Input() isFavoritesIconVisible: boolean;
  @Input() isCaptionVisible: boolean;

  constructor(private basketService: BasketService) { }

  addItemToBasket() {
    this.basketService.addItemToBasket(this.product);
  }


}
