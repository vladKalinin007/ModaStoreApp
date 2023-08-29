import {Component, OnInit} from '@angular/core';
import {AccountService} from "../account.service";
import {IProductReview} from "../../../core/models/catalog/product-review";
import {ReviewService} from "../../../shared/services/review-service/review.service";

@Component({
  selector: 'app-reviews',
  templateUrl: './reviews.component.html',
  styleUrls: ['./reviews.component.scss']
})
export class ReviewsComponent implements OnInit {

  reviews: IProductReview[]

  constructor(
    private accountService: AccountService,
    private reviewService: ReviewService
  ) { }

  ngOnInit(): void {
    this.loadReviews();
  }

  loadReviews(): void {
    this.reviewService.getUserReviews().subscribe({
      next: (reviews: IProductReview[]) => {
        this.reviews = reviews;
      },
      error: (err: any) => {
        console.log(err);
      }
    })
  }
}
