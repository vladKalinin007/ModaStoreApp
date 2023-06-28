import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {environment} from "../../../environments/environment";
import {IWishlist, Wishlist} from "../../core/models/customer/wishlist";
import {BehaviorSubject} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class WishlistService {

  public baseUrl: string = environment.apiUrl;
  public wishlistSource: BehaviorSubject<IWishlist> = new BehaviorSubject<IWishlist>(null);
  public wishlist$ = this.wishlistSource.asObservable();

  constructor(private http: HttpClient) { }

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
    return this.http.get(this.baseUrl + 'wishlist?id=' + id)
      .subscribe({
      next: (response: IWishlist) => {
        this.wishlistSource.next(response);
      },
      error: (error: any) => {
        console.log(error);
      }
    })
  }

  setWishlist(wishlist: IWishlist) {
    return this.http.post(this.baseUrl + 'wishlist', wishlist)
      .subscribe({
      next: (response: IWishlist) => {
        console.log(response);
      },
      error: (error: any) => {
        console.log(error);
      }
    })
  }

  /*addItemToWishlist(id: string, productId: number) {
    const wishlistItem =
  }*/

  removeItemFromWishlist(id: string, productId: number) {
    return this.http.delete(this.baseUrl + 'wishlist?id=' + id + '&productId=' + productId);
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
