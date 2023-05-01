import {Component, OnInit} from '@angular/core';
import {BasketService} from "./features/basket/basket.service";
import {AccountService} from "./features/account/account.service";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {

  title: string = 'Moda';

  constructor(
    private basketService: BasketService,
    private accountService: AccountService
  ) { }

  ngOnInit(): void {
    this.loadBasket();
    this.loadCurrentUser();
  }

  loadCurrentUser(): void {
    const token: string = localStorage.getItem('token');
      this.accountService.loadCurrentUser(token)
        .subscribe({
        next: () => console.log('loaded user'),
        error: error => console.log(error)
      });
  }

  loadBasket(): void {
    const basketId = localStorage.getItem('basket_id');
    if (basketId) {
      this.basketService.getBasket(basketId).subscribe({
        next: () => console.log('initialized basket'),
        error: error => console.log(error)
      })
    }
  }

}
