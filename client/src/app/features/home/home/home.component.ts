import {Component, OnInit} from '@angular/core';
import {IProduct} from "../../../core/models/product";
import {HomeService} from "../home.service";
import {ICategory} from "../../../core/models/category";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  products: IProduct[];
  categories: ICategory[];

  responsiveOptions: any[];

  constructor(
    private homeService: HomeService
  ) {}

  ngOnInit() {

    this.getCategories();

    this.responsiveOptions = [
      {
        breakpoint: '1199px',
        numVisible: 1,
        numScroll: 1
      },
      {
        breakpoint: '991px',
        numVisible: 2,
        numScroll: 1
      },
      {
        breakpoint: '767px',
        numVisible: 1,
        numScroll: 1
      }
    ];
  }

  getCategories() {
    this.homeService.getCategories().subscribe(categories => {
      this.categories = categories;
      console.log(categories);
    });
  }

  getNewProducts() {

  }

  getBestSellersProducts() {

  }

  getRecentlyViewedProducts() {

  }

  getLastReviews() {

  }

}


