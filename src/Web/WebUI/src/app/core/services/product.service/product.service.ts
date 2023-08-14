import { Injectable } from '@angular/core';
import {environment} from "../../../../environments/environment";
import {HttpClient, HttpParams} from "@angular/common/http";
import {ShopParams} from "../../models/shopParams";
import {IPagination} from "../../models/pagination";
import {map} from "rxjs/operators";
import {IProduct} from "../../models/product";
import {IBrand} from "../../models/brand";
import {IType} from "../../models/productType";
import {Observable} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  baseUrl: string = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getProducts(shopParams?: ShopParams) {

    const url: string = `${this.baseUrl}product`;
    let params = new HttpParams();

    params = shopParams?.brandId ? params.append('brandId', shopParams.brandId) : params;
    params = shopParams?.typeId ? params.append('typeId', shopParams.typeId) : params;
    params = shopParams?.search ? params.append('search', shopParams.search) : params;

    params = params.append('sort', shopParams.sort);
    params = params.append('pageIndex', shopParams.pageNumber.toString());
    params = params.append('pageSize', shopParams.pageSize.toString());

    const options = { observe: 'response' as const, params };

    return this.http.get<IPagination>(url, options).pipe(
      map(response => response.body)
    );
  }

  //https://localhost:5001/odata/Product?IsBestSeller=true
  getBestsellers() {
    const url: string = `${this.baseUrl}Product`;
    let params: HttpParams = new HttpParams();
    params = params.append('IsBestSeller', 'true');
    const options = { observe: 'response' as const, params };
    return this.http.get<IPagination>(url, options).pipe(
      map(response => response.body)
    );
  }

  //https://localhost:5001/odata/Product?IsNew=true
  getNewProducts() {
    const url: string = `${this.baseUrl}Product`;
    let params: HttpParams = new HttpParams();
    params = params.append('IsNew', 'true');
    const options = { observe: 'response' as const, params };
    return this.http.get<IPagination>(url, options).pipe(
      map(response => response.body)
    );
  }

  //https://localhost:5001/odata/Product?IsOnSale=true
  getOnSaleProducts() {
    const url: string = `${this.baseUrl}Product`;
    let params: HttpParams = new HttpParams();
    params = params.append('IsOnSale', 'true');
    const options = { observe: 'response' as const, params };
    return this.http.get<IPagination>(url, options).pipe(
      map(response => response.body)
    );
  }

  getProduct(id: string) {
    const url: string = `${this.baseUrl}product/${id}`;

    return this.http.get<IProduct>(url).pipe(
      map(response => response[0])
    );
  }

  getBrands() {
    return this.http.get<IBrand[]>(this.baseUrl + 'productBrand/');
  }

  getTypes() {
    return this.http.get<IType[]>(this.baseUrl + 'productType/');
  }

  getProductsByCategory(categoryName: string): Observable<IProduct[]> {
    const url: string = `${this.baseUrl}Product?categoryName=${categoryName}`;
    console.log("it works")
    return this.http.get<IProduct[]>(url);
  }
}
