import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {environment} from "../../../environments/environment";
import {IWishlist, Wishlist} from "../../core/models/customer/wishlist";
import {BehaviorSubject, Observable} from "rxjs";
import {map} from "rxjs/operators";
import {IWishlistItem} from "../../core/models/customer/wishlistItem";
import {IProduct} from "../../core/models/product";

@Injectable({
  providedIn: 'root'
})
export class WishlistService {

  public baseUrl: string = environment.apiUrl;

  public wishlistSource: BehaviorSubject<IWishlist> = new BehaviorSubject<IWishlist>(null);
  public wishlist$: Observable<IWishlist> = this.wishlistSource.asObservable();


  constructor(
    private http: HttpClient
    ) { }


  getCurrentWishlistValue(): IWishlist {
    return this.wishlistSource.value;
  }

  createLocalWishlist(): IWishlist {
    const wishlist = new Wishlist();
    localStorage.setItem('wishlist_id', wishlist.id);
    return wishlist;
  }

  deleteLocalWishlist(id: string) {
    this.wishlistSource.next(null);
    localStorage.removeItem('wishlist_id');
  }

  getWishlist(id: string) {
    const url: string = this.baseUrl + 'wishlist/' + id;
    return this.http.get(url)
    .pipe(
      map((wishlist: IWishlist) => {
        this.wishlistSource.next(wishlist);
      }
    ));
  }

  addItemToWishlist(product: IProduct) {
    const wishlistItem: IWishlistItem = this.toWishlistItem(product);
    console.log(`addItemToWishlist.wishlistItem =, ${wishlistItem}`)
    const wishlist: IWishlist = this.getCurrentWishlistValue() ?? this.createLocalWishlist();
    wishlist.wishlistItems = this.addOrUpdateWishlistItems(wishlist.wishlistItems, wishlistItem);
    this.setWishlist(wishlist);
  }

  private addOrUpdateWishlistItems(wishlistItems: IWishlistItem[], wishlistItem: IWishlistItem): IWishlistItem[] {
  const index = wishlistItems.findIndex((item: IWishlistItem) => item.id === wishlistItem.id);

    if (index === -1) {
      wishlistItems.push(wishlistItem);
    } else {
      wishlistItems[index] = wishlistItem; // update
    }

    return wishlistItems;
  }


  toWishlistItem(item: IProduct): IWishlistItem {
    return {
      id: item.id,
      name: item.name,
      description: item.description,
      price: item.price,
      pictureUrl: item.pictureUrl,
      productType: item.productType,
      productBrand: item.productBrand
    }
  }

  setWishlist(wishlist: IWishlist) {
    const url = this.baseUrl + 'Wishlist';
    console.log("url:", url);
    return this.http.post(url, wishlist).subscribe({
      next: (response: IWishlist) => {
        this.wishlistSource.next(response);
        console.log(response);
      },
      error: (error: any) => {
        console.log(error);
      }
    })
  }


  removeItemFromWishlist(id: string) {
    const url = this.baseUrl + 'wishlist/' + id;
    return this.http.delete(url);
  }

  deleteWishlist(id: string) {
    return this.http.delete(this.baseUrl + 'wishlist?id=' + id);
  }

  getWishlistItems(id: string) {
    return this.http.get(this.baseUrl + 'wishlist/items?id=' + id);
  }

  getWishlistItemCount(id: string) {
    return this.http.get(this.baseUrl + 'wishlist/count?id=' + id);
  }


  checkWishlistItemExists(id: string, productId: number) {
    return this.http.get(this.baseUrl + 'wishlist/exists?id=' + id + '&productId=' + productId);
  }


}
