import {Component, ElementRef, OnDestroy, OnInit, ViewChild} from '@angular/core';
import {IProduct} from "../../core/models/product";
import {ShopService} from "./shop.service";
import {IPagination} from "../../core/models/pagination";
import {IBrand} from "../../core/models/brand";
import {IType} from "../../core/models/productType";
import {ShopParams} from "../../core/models/shopParams";
import {ActivatedRoute, Router} from "@angular/router";
import {ProductService} from "../../core/services/product.service/product.service";

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit {

  @ViewChild('search', {static: false}) searchTerm: ElementRef;
  products: IProduct[];
  brands: IBrand[];
  types: IType[];
  headerTitle: string;
  shopParams: ShopParams = new ShopParams();
   totalCount: number;
  rangeValues: number[] = [0, 1000];


  constructor(
    private shopService: ShopService,
    private productService: ProductService,
    private activatedRoute: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.loadProducts()
    this.getProducts();
    this.getBrands();
    this.getTypes();
  }

  loadProducts() {
    let query: string = this.activatedRoute.snapshot.paramMap.get('categoryName') ?? '';

    if (query) {
      this.headerTitle = this.activatedRoute.snapshot.paramMap.get('categoryName');
      this.productService.getProductsByCategory(query)
    }
    else {
      this.headerTitle = 'All Products';
      this.productService.getProducts()
    }
  }

  getProducts() {
    this.shopService.getProducts(this.shopParams)
      .subscribe({
        next: (response: IPagination) => {
          this.products = response.data;
          this.shopParams.pageNumber = response.pageIndex;
          this.shopParams.pageSize = response.pageSize;
          this.totalCount = response.count;
        },
        error: (error) => {
          console.log(error);
        }
      });
  }

  getBrands() {
    this.shopService.getBrands()
      .subscribe({
        next: (response: IBrand[]) => {
          this.brands = [
            {
              id: "0",
              name: 'All'
            },
            ...response
          ];
        },
        error: (error) => {
          console.log(error);
        }
      });
  }

  getTypes() {
    this.shopService.getTypes()
      .subscribe({
        next: (response: IType[]) => {
          this.types = response;
        },
        error: (error) => {
          console.log(error);
        }
      });
  }

  onBrandSelected(brandId: string) {
    console.log(brandId);
    this.shopParams.brandId = brandId;
    this.shopParams.pageNumber = 1;
    this.getProducts();
  }

  onProductClicked(productId: string) {
    const categoryName: string = this.activatedRoute.snapshot.paramMap.get('categoryName');
    this.router.navigate(['shop', categoryName, productId]);
  }

  onTypeSelected(typeId: string) {
    this.shopParams.typeId = typeId;
    this.shopParams.pageNumber = 1;
    this.getProducts();
  }

  onSortSelected(sort: string) {
    this.shopParams.sort = sort;
    this.getProducts();
  }

  onPageChanged(event: any) {
    if (this.shopParams.pageNumber !== event) {
      this.shopParams.pageNumber = event;
      this.getProducts();
    }
  }

  onSearch() {
    this.shopParams.search = this.searchTerm.nativeElement.value;
    this.shopParams.pageNumber = 1;
    this.getProducts();
  }

  onReset() {
    this.searchTerm.nativeElement.value = '';
    this.shopParams = new ShopParams();
    this.getProducts();
  }
}
