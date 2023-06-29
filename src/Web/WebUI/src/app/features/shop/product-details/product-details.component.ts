import {Component, NgZone, OnInit} from '@angular/core';
import {IProduct} from "../../../core/models/product";
import {ShopService} from "../shop.service";
import {IPagination} from "../../../core/models/pagination";
import {ActivatedRoute} from "@angular/router";
import {BreadcrumbService} from "xng-breadcrumb";
import {BasketService} from "../../basket/basket.service";
import {ShopParams} from "../../../core/models/shopParams";
import {ProductService} from "../../../core/services/product.service/product.service";

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss']
})
export class ProductDetailsComponent implements OnInit {

  product: IProduct;
  products: IProduct[];

  shopParams: ShopParams = new ShopParams();
  responsiveOptions: any[];
  ratingValue: number;
  totalCount: number;
  sidebarVisible: boolean;
  images: any[] = [
    {
      previewImageSrc:
        'https://cdn.dressa.com.ua/ostrov-cache/sylius_extra_large/12/sirenevoe-plate-trapeciya-s-cvetochnym-printom-58847-1679824328-1.jpg',
      thumbnailImageSrc:
        'https://cdn.dressa.com.ua/ostrov-cache/sylius_extra_large/12/sirenevoe-plate-trapeciya-s-cvetochnym-printom-58847-1679824328-1.jpg',
      alt: 'Description for Image 1',
      title: 'Title 1'
    },
    {
      previewImageSrc:
        'https://cdn.dressa.com.ua/ostrov-cache/sylius_extra_large/08/beloe-plate-trapeciya-s-cvetochnym-printom-58845-1680510135-1.jpg',
      thumbnailImageSrc:
        'https://cdn.dressa.com.ua/ostrov-cache/sylius_extra_large/08/beloe-plate-trapeciya-s-cvetochnym-printom-58845-1680510135-1.jpg',
      alt: 'Description for Image 2',
      title: 'Title 2'
    },
    {
      previewImageSrc:
        'https://cdn.dressa.com.ua/ostrov-cache/sylius_extra_large/fd/plate-na-uzkih-bretelyah-s-cvetochnym-printom-beloe-59103-1683010716-1.jpg',
      thumbnailImageSrc:
        'https://cdn.dressa.com.ua/ostrov-cache/sylius_extra_large/fd/plate-na-uzkih-bretelyah-s-cvetochnym-printom-beloe-59103-1683010716-1.jpg',
      alt: 'Description for Image 3',
      title: 'Title 3'
    },
    {
      previewImageSrc:
        'https://cdn.dressa.com.ua/ostrov-cache/sylius_extra_large/fd/plate-na-uzkih-bretelyah-s-cvetochnym-printom-beloe-59103-1683095599-4.jpg',
      thumbnailImageSrc:
        'https://cdn.dressa.com.ua/ostrov-cache/sylius_extra_large/fd/plate-na-uzkih-bretelyah-s-cvetochnym-printom-beloe-59103-1683095599-4.jpg',
      alt: 'Description for Image 4',
      title: 'Title 4'
    },
  ];

  value: number;

  paymentOptions: any[] = [
    { name: '42', value: 1 },
    { name: '44', value: 2 },
    { name: '46', value: 3 },
    { name: '48', value: 4 },
  ];



  constructor(
    private shopService: ShopService,
    private activateRoute: ActivatedRoute,
    private bcService: BreadcrumbService,
    private basketService: BasketService,
    private productService: ProductService,
  ) {
    this.bcService.set('@productDetails', '');
  }

  ngOnInit(): void {
    this.loadProduct();
    this.getProducts();
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
    this.productService.getProduct(this.activateRoute.snapshot.paramMap.get('id')).subscribe({
        next: (response) => {
          /*console.log("Details.loadProduct.RESPONSE", response);*/
          this.product = response;
          console.log("Details.product =", this.product);
          this.bcService.set('@productDetails', this.product.name);
        },
        error: (error) => {
          console.log(error);
        }
      });
  }

  /*getProducts() {
    this.productService.getProducts(this.shopParams).subscribe({
        next: (response) => {
          this.products = response.data;
          console.log(`ProductDetailsComponent.getProducts.RESPONSE: ${response.data}`);
          this.shopParams.pageNumber = response.pageIndex;
          this.shopParams.pageSize = response.pageSize;
          this.totalCount = response.count;
        },
        error: (error) => {
          console.log(error);
        }
      });
  }*/

  getProducts() {
    this.productService.getProducts(this.shopParams)
      .subscribe({
        next: (response) => {
          this.products = response.data;
          /*console.log("Details.getProducts.RESPONSE", response.data);*/
          console.log("Details.products =", this.products);

        },
        error: (error) => {
          console.log(error);
        }
      });
  }

}
