import {Component, OnInit} from '@angular/core';
import {WishlistService} from "../wishlist.service";
import {IWishlist} from "../../../core/models/customer/wishlist";
import {Observable} from "rxjs";
import {IWishlistItem} from "../../../core/models/customer/wishlistItem";
import {map} from "rxjs/operators";
import {IProduct} from "../../../core/models/product";
import { BasketService } from '../../basket/basket.service';
import {IBasket} from "../../../core/models/basket";
import { ProductService } from '../../../core/services/product.service/product.service';
import { switchMap } from 'rxjs/operators';
import { forkJoin } from 'rxjs';
import { of } from 'rxjs';
import { scan } from 'rxjs/operators';


@Component({
  selector: 'app-wishlist',
  templateUrl: './wishlist.component.html',
  styleUrls: ['./wishlist.component.scss']
})
export class WishlistComponent implements OnInit {

  products$: Observable<IProduct[]>;
  wishlistProducts: IProduct[] = [];

  constructor(private wishlistService: WishlistService,
              private productService: ProductService) {}


  ngOnInit(): void {
    this.products$ = this.wishlistService.products$;
  }
  
}
