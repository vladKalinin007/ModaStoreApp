import { Injectable } from '@angular/core';
import {environment} from "../../../../environments/environment";
import {HttpClient} from "@angular/common/http";
import {IProductReview} from "../../../core/models/catalog/product-review";

@Injectable({
  providedIn: 'root'
})
export class ReviewService {

  url: string = environment.apiUrl + 'User/Reviews';

  constructor(private http: HttpClient ) { }

  getUserReviews() {
    return this.http.get(this.url);
  }

  getFeaturedReviews() {
    return this.http.get(this.url + '/featured');
  }

  addUserReview(review: IProductReview) {
    return this.http.post(this.url, review);
  }

  deleteUserReview(id: number) {
    return this.http.delete(this.url + '/' + id);
  }


}
