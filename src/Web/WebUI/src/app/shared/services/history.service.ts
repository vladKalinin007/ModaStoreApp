import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {IViewedProductList, ViewedProductList} from "../../core/models/customer/viewedProductList";
import {environment} from "../../../environments/environment";
import {map} from "rxjs/operators";
import {BehaviorSubject} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class HistoryService {

  public baseUrl: string = environment.apiUrl;
  public historySource: BehaviorSubject<IViewedProductList> = new BehaviorSubject<IViewedProductList>(null);
  public history$ = this.historySource.asObservable();

  constructor(private http: HttpClient) { }

  createLocalProductsViewsHistoryId() {
    const viewedProductList = new ViewedProductList();
    localStorage.setItem('views_history_id', viewedProductList.id);
    return viewedProductList;
  }

  deleteLocalProductsViewsHistoryId(id: string) {
    localStorage.removeItem('views_history_id');
  }

  getItemsFromProductsViewsHistory(id: string) {
    const url: string = this.baseUrl + 'history/' + id;
    return this.http.get(url).pipe(
      map((viewedProductsList: IViewedProductList) => {
        this.historySource.next(viewedProductsList);
      }
    ));
  }

  addItemToProductsViewsHistory(item: string) {
    return this.http.post('http://localhost:3000/api/history', item);
  }
}
