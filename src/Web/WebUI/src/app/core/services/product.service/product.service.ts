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

    let params = new HttpParams();

    if (shopParams.brandId) {
      params = params.append('brandId', shopParams.brandId);
    }


    if (shopParams.typeId) {
      params = params.append('typeId', shopParams.typeId);
    }

    if (shopParams.search) {
      params = params.append('search', shopParams.search);
    }

    params = params.append('sort', shopParams.sort);
    params = params.append('pageIndex', shopParams.pageNumber.toString());
    params = params.append('pageSize', shopParams.pageSize.toString());

    return this.http.get<IPagination>(this.baseUrl + 'product', {observe: 'response', params})
      .pipe(
      map(response => {
        console.log("RESPONSE: ", response);
        return response.body;
      })
    );
  }

  getProduct(id: number)
  {
    return this.http.get<IProduct>(this.baseUrl + 'product/' + id); // returns an observable'
  }

  getBrands() {
    return this.http.get<IBrand[]>(this.baseUrl + 'productBrand/'); // returns an observable
  }

  getTypes() {
    return this.http.get<IType[]>(this.baseUrl + 'productType/');
  }
}
