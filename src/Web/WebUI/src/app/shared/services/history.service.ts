import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {
  ISeenProductList,
  SeenProductList,
} from "../../core/models/customer/seenProductList";
import {environment} from "../../../environments/environment";
import {map} from "rxjs/operators";
import {BehaviorSubject, Observable} from "rxjs";
import {ISeenProduct} from "../../core/models/customer/seen-product";
import {IProduct} from "../../core/models/product";

@Injectable({
  providedIn: 'root'
})
export class HistoryService {

  public baseUrl: string = environment.apiUrl;
  public historySource: BehaviorSubject<ISeenProductList> = new BehaviorSubject<ISeenProductList>(null);
  public history$ : Observable<ISeenProductList> = this.historySource.asObservable();

  constructor(private http: HttpClient) { }

  createLocalProductsViewsHistoryId() {
    const seenProductList: SeenProductList = new SeenProductList();
    localStorage.setItem('views_history_id', seenProductList.id);
    return seenProductList;
  }

  deleteLocalProductsViewsHistoryId(id: string) {
    localStorage.removeItem('views_history_id');
  }

  getItemsFromProductsViewsHistory(id: string) {
    const url: string = this.baseUrl + 'SeenProduct/' + id;
    return this.http.get(url).pipe(
      map((viewedProductsList: ISeenProductList) => {
        this.historySource.next(viewedProductsList);
      }
    ));
  }

  setProductsViewsHistory(seenProductList: ISeenProductList) {
    const url: string = this.baseUrl + 'SeenProduct';
    return this.http.post(url, seenProductList).subscribe((response: ISeenProductList) => {
      this.historySource.next(response);
    }, error => {
      console.log(error);
    });
  }

  addItemToProductsViewsHistory(product: IProduct) {
    const seenProduct: ISeenProduct = this.toViewedProduct(product);
    const seenProductList: ISeenProductList = this.getCurrentProductsViewsHistoryValue() ?? this.createLocalProductsViewsHistoryId();
    seenProductList.seenProducts = this.addOrUpdateViewedProducts(seenProductList.seenProducts, seenProduct);
    this.setProductsViewsHistory(seenProductList);
  }

  private addOrUpdateViewedProducts(viewedProducts: ISeenProduct[], viewedProduct: ISeenProduct): ISeenProduct[] {
    const index = viewedProducts.findIndex((item: ISeenProduct) => item.id === viewedProduct.id);
    if (index === -1) {
      viewedProducts.push(viewedProduct);
    } else {
      viewedProducts[index] = viewedProduct;
    }
    return viewedProducts;
  }


  private toViewedProduct(product: IProduct): ISeenProduct {
    return { ...product };
  }

  private getCurrentProductsViewsHistoryValue(): ISeenProductList {
    return this.historySource.value;
  }
}
