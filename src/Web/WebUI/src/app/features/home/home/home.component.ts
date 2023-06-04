import {Component, OnInit} from '@angular/core';
import {IProduct} from "../../../core/models/product";
import {HomeService} from "../home.service";
import {ICategory} from "../../../core/models/category";
import {IPagination} from "../../../core/models/pagination";
import {ProductService} from "../../../core/services/product.service/product.service";
import {ShopParams} from "../../../core/models/shopParams";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  products: IProduct[];
  categories: ICategory[];
  shopParams: ShopParams = new ShopParams();

  responsiveOptions: any[];

  constructor(
    private homeService: HomeService,
    private productService: ProductService,
  ) {}

  ngOnInit() {

    this.getProducts();

    this.getCategories();

    this.responsiveOptions = [
      {
        breakpoint: '1199px',
        numVisible: 1,
        numScroll: 1
      },
      {
        breakpoint: '991px',
        numVisible: 2,
        numScroll: 1
      },
      {
        breakpoint: '767px',
        numVisible: 1,
        numScroll: 1
      }
    ];
  }

  getCategories() {
    this.homeService.getCategories()
      .subscribe(categories => {
      this.categories = categories;
      console.log(categories);
    });
  }

  getProducts() {
    this.productService.getProducts(this.shopParams)
      .subscribe({
        next: (response: IPagination) => {
          this.products = response.data;
        },
        error: (error) => {
          console.log(error);
        }
      });
  }

  getNewProducts() {

  }

  getBestSellersProducts() {

  }

  getRecentlyViewedProducts() {

  }

  getLastReviews() {

  }

}


