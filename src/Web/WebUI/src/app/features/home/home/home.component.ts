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
  product: IProduct;
  categories: ICategory[];
  shopParams: ShopParams = new ShopParams();

  responsiveOptions: any[];

  constructor(
    private homeService: HomeService,
    private productService: ProductService,
  ) {}

  ngOnInit() {

    this.getProducts();
    this.loadProduct();

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

  p

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
        next: (response) => {
          this.products = response.data;
          console.log("HomeComponent.getProducts.RESPONSE", response.data);

        },
        error: (error) => {
          console.log("NO PRODUCT FOR CAROUSEL");
          console.log(error);
        }
      });
  }

  loadProduct() {
    this.productService.getProduct("87c12f75-8176-4ea9-8ee4-a117a2a27d1e").subscribe({
      next: (response) => {
        console.log(`HomeComponent.loadProduct.RESPONSE: ${response}`)
        this.product = response;
        /*this.bcService.set('@productDetails', this.product.name);*/
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


