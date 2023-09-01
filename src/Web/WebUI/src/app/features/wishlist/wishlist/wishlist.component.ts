import {Component, OnInit} from '@angular/core';
import {WishlistService} from "../wishlist.service";
import {Observable} from "rxjs";
import {IProduct} from "../../../core/models/product";


@Component({
  selector: 'app-wishlist',
  templateUrl: './wishlist.component.html',
  styleUrls: ['./wishlist.component.scss']
})
export class WishlistComponent implements OnInit {

  products$: Observable<IProduct[]>;

  constructor(private wishlistService: WishlistService) {

  }


  ngOnInit(): void {
    this.products$ = this.wishlistService.products$;
  }

}
