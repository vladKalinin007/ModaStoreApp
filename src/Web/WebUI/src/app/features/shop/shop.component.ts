import {Component, ElementRef, OnInit, ViewChild} from '@angular/core';
import {IProduct} from "../../core/models/product";
import {ShopService} from "./shop.service";
import {IPagination} from "../../core/models/pagination";
import {IBrand} from "../../core/models/brand";
import {IType} from "../../core/models/productType";
import {ShopParams} from "../../core/models/shopParams";
import {ActivatedRoute, NavigationEnd, Router} from "@angular/router";
import {ProductService} from "../../core/services/product.service/product.service";
import {fastCascade} from "../../shared/animations/fade-in.animation";
import {ICategory} from "../../core/models/category";
import {CategoryService} from "../../core/services/category.service/category.service";
import {filter} from "rxjs";

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss'],
  animations: [
    fastCascade,
  ]
})
export class ShopComponent implements OnInit {

  @ViewChild('search', {static: false}) searchTerm: ElementRef;
  products: IProduct[];
  brands: IBrand[];
  types: IType[];
  categories: ICategory[];
  headerTitle: string;
  shopParams: ShopParams = new ShopParams();
   totalCount: number;
  rangeValues: number[] = [0, 1000];
  isSideBarHidden: boolean;


  constructor(
    private shopService: ShopService,
    private categoryService: CategoryService,
    private productService: ProductService,
    private activatedRoute: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.loadProducts()
    this.getProducts();
    this.getBrands();
    this.getCategories();
    this.getTypes();
  /*  console.log("shop component init")
    this.updateIsSideBarHidden();*/
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

  getCategories() {
    this.categoryService.getCategories()
      .subscribe({
        next: (response: ICategory[]) => {
          this.categories = response;
          this.updateSideBarVisibility(response);
        },
        error: (error) => {
          console.log(error);
        }
      });
  }

  private updateSideBarVisibility(categories: ICategory[]): void {
    const currentRoute: string = this.activatedRoute.snapshot.paramMap.get('categoryName');

    const isCategoryFound = categories.some(category => category.name === currentRoute);

    if (!isCategoryFound) {
      this.isSideBarHidden = true;
    }
  }

  getSizes() {
    this.productService.getSizes().subscribe({
      next: (response: string[]) => {
        console.log(response);
      }
    })
  }

  getColors() {
    this.productService.getColors().subscribe({
      next: (response: string[]) => {
        console.log(response);
      }
    })
  }

  getSeasons() {

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
