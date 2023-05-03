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

/*
TODO: Решить первостепенные задчаи по заданным правилам:
1. Выстроить цепочку от покупки товара до получения оплаты.
2. Делать только те части логики и представлений, которые для этого нужны
3. Решать задачи параллельно. Не ждать, пока одна задача будет решена, чтобы начать решать другую.
4. Не делать ничего, что не нужно для решения задач, которые решают основную - создаение цепочки.
5. Очень медленно по шагам реализовывать логику, создавать коммиты и проверять, работает ли проект.

6. При добавление нового, проверять,
a) не сломал ли это то, что уже работает.
b) не добавил ли я лишнего, что не нужно для решения задачи.
с) делать коммит, только проверив, что все работает.
d) делать коммит, даже если функционал минимален.

*/
