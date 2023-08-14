import {Component, Input, OnInit} from '@angular/core';
import {IProductReview} from "../../../core/models/catalog/product-review";

@Component({
  selector: 'app-review',
  templateUrl: './review.component.html',
  styleUrls: ['./review.component.scss']
})
export class ReviewComponent implements OnInit {

  @Input()
  review: IProductReview;

  rating: number;

  constructor() { }

  ngOnInit() {
    this.rating = this.review.rating;
  }
}
