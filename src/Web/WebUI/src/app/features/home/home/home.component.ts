import {Component, OnInit} from '@angular/core';
import {IProduct} from "../../../core/models/product";
import {HomeService} from "../home.service";
import {ICategory} from "../../../core/models/category";
import {ProductService} from "../../../core/services/product.service/product.service";
import {ShopParams} from "../../../core/models/shopParams";
import {PictureService} from "../../../core/services/picture.service";
import {IProductImage} from "../../../core/models/catalog/product-image";
import {HistoryService} from "../../../shared/services/history.service";
import {cascade, fadeIn} from "../../../shared/animations/fade-in.animation";
import {animate, state, style, transition, trigger} from "@angular/animations";
import {Observable} from "rxjs";
import {ISeenProductList} from "../../../core/models/customer/seenProductList";



@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
  animations: [
    fadeIn,
    cascade
  ]
})
export class HomeComponent implements OnInit {

  products: IProduct[];
  newProducts: IProduct[];
  bestSellersProducts: IProduct[];
  onSaleProducts: IProduct[];
  productImage: IProductImage[];
  product: IProduct;
  categories: ICategory[];

  history$: Observable<ISeenProductList>
  shopParams: ShopParams = new ShopParams();

  constructor(
    private pictureService: PictureService,
    private homeService: HomeService,
    private productService: ProductService,
    private historyService: HistoryService,
  ) {}

  ngOnInit() {
    this.getCarouselPictures()
    // this.getProducts();
    this.loadProduct();
    this.getCategories();
    this.getRecentlyViewedProducts()
    this.getNewProducts();
    this.getBestSellersProducts();
    this.getOnSaleProducts();
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

  getBestSellersProducts(): void {
    this.productService.getBestsellers()
      .subscribe({
        next: (response) => {
          this.bestSellersProducts = response.data;
          console.log("HomeComponent.getBestSellersProducts.RESPONSE", response.data);
        },
        error: (error) => {
          console.log("NO PRODUCT FOR CAROUSEL");
          console.log(error);
        }
      });
  }

  getOnSaleProducts(): void {
    this.productService.getOnSaleProducts()
      .subscribe({
        next: (response) => {
          this.onSaleProducts = response.data;
          console.log("HomeComponent.getOnSaleProducts.RESPONSE", response.data);
        },
        error: (error) => {
          console.log("NO PRODUCT FOR CAROUSEL");
          console.log(error);
        }
      });
  }

  getNewProducts(): void {
    this.productService.getNewProducts()
      .subscribe({
        next: (response) => {
          this.newProducts = response.data;
          console.log("HomeComponent.getNewProducts.RESPONSE", response.data);
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

  getRecentlyViewedProducts() {
    this.history$ = this.historyService.history$;
  }

  getLastReviews() {

  }

  getCarouselPictures() {
    this.pictureService.getCarouselPictures().subscribe({
      next: (response: IProductImage[]) => {
        this.productImage = response;
        console.log("RES:", this.productImage);
      },
      error: (error) => {
        console.log("NO PRODUCT FOR CAROUSEL");
        console.log(error);
      }
    });

  }

}


