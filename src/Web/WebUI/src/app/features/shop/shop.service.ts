import { Injectable } from '@angular/core';
import {HttpClient, HttpParams} from "@angular/common/http";
import {IPagination} from "../../core/models/pagination";
import {IBrand} from "../../core/models/brand";
import {IType} from "../../core/models/productType";
import {map} from "rxjs/operators";
import {ShopParams} from "../../core/models/shopParams";
import {IProduct} from "../../core/models/product";
import {environment} from "../../../environments/environment";

@Injectable({
  providedIn: 'root'
})
export class ShopService {

  baseUrl: string = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getProducts(shopParams: ShopParams) {
    let params = new HttpParams();

    if (shopParams.brandId !== 0) {
      params = params.append('brandId', shopParams.brandId.toString());
    }


    if (shopParams.typeId !== 0) {
      params = params.append('typeId', shopParams.typeId.toString());
    }

    if (shopParams.search) {
      params = params.append('search', shopParams.search);
    }

    params = params.append('sort', shopParams.sort);
    params = params.append('pageIndex', shopParams.pageNumber.toString());
    params = params.append('pageSize', shopParams.pageSize.toString());

    return this.http.get<IPagination>(this.baseUrl + 'products', {observe: 'response', params}).pipe(
      map(response => {
        return response.body;
      })
    );
  }

  getProduct(id: number)
  {
    return this.http.get<IProduct>(this.baseUrl + 'products/' + id); // returns an observable'
  }

  getBrands() {
    return this.http.get<IBrand[]>(this.baseUrl + 'products/brands'); // returns an observable
  }

  getTypes() {
    return this.http.get<IType[]>(this.baseUrl + 'products/types'); // returns an observable
  }

}
