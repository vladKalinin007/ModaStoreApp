import { Component } from '@angular/core';
import {IProduct} from "../shared/models/product";
import {ShopService} from "./shop.service";
import {IPagination} from "../shared/models/pagination";

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent {
  products: IProduct[];

  constructor(private shopService: ShopService) { }

  ngOnInit(): void {
    this.shopService.getProducts()
      .subscribe({
        next: (response: IPagination) => {
          this.products = response.data;
        },
        error: (error) => {
          console.log(error);
        }
      });

  }
}
