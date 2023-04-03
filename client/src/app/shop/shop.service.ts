import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {IPagination} from "../shared/models/pagination";

@Injectable({
  providedIn: 'root'
})
export class ShopService {

  baseUrl = 'https://localhost:5001/api/';
  constructor(private http: HttpClient) { }

  getProducts() {
    return this.http.get<IPagination>(this.baseUrl + 'products?pageSize=50'); // returns an observable
  }

  getProduct(id: number)
  {
    return this.http.get(this.baseUrl + 'products/' + id); // returns an observable'
  }


}
