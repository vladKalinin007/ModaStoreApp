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

    shopParams.brandId ? params = params.append('brandId', shopParams.brandId) : null;

    shopParams.typeId ? params = params.append('typeId', shopParams.typeId) : null;

    shopParams.search ? params = params.append('search', shopParams.search) : null;

    params = params.append('sort', shopParams.sort);
    params = params.append('pageIndex', shopParams.pageNumber.toString());
    params = params.append('pageSize', shopParams.pageSize.toString());

    return this.http.get<IPagination>(url, {observe: 'response', params}).pipe(
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
}
