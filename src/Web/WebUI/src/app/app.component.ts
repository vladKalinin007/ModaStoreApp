import {Component, OnInit} from '@angular/core';
import {BasketService} from "./features/basket/basket.service";
import {AccountService} from "./features/account/account.service";
import {MenuItem, MessageService} from "primeng/api";
import {NavigationEnd, Router} from "@angular/router";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
  providers: [MessageService]
})
export class AppComponent implements OnInit {

  items: MenuItem[];
  showNavigationBar: boolean = true;

  title: string = 'Moda';

  constructor(
    private basketService: BasketService,
    private accountService: AccountService,
    private messageService: MessageService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.loadBasket();
    this.loadCurrentUser();
    this.addItemsToSpeedDial();
    this.updateComponentVisibility();

  }

  updateComponentVisibility() {
    this.router.events.subscribe(event => {
      if (event instanceof NavigationEnd) {
        const currentRoute = event.urlAfterRedirects; // Получение текущего маршрута

        // Определите условия, когда нужно скрыть компоненты
        this.showNavigationBar = !(currentRoute === '/checkout'); // Пример: Скрыть на странице оформления заказа (checkout)

        // Добавьте другие условия для скрытия компонентов
        // this.showOtherComponent = ...;
      }
    });
  }

  addItemsToSpeedDial() {
    this.items = [
      {
        icon: 'pi pi-facebook',
        command: () => {
          this.messageService.add({ severity: 'info', summary: 'Add', detail: 'Data Added' });
        }
      },
      {
        icon: 'pi pi-linkedin',
        command: () => {
          this.messageService.add({ severity: 'info', summary: 'Delete', detail: 'Data Deleted' });
        }
      },
      {
        icon: 'pi pi-telegram',
        command: () => {
          this.messageService.add({ severity: 'info', summary: 'Help', detail: 'Data Updated' });
        }
      },
      {
        icon: 'pi pi-whatsapp',
        command: () => {
          this.messageService.add({ severity: 'info', summary: 'Search', detail: 'Data Searched' });
        }
      },
      {
        icon: 'pi pi-instagram',
        command: () => {
          this.messageService.add({ severity: 'info', summary: 'Save', detail: 'Data Saved' });
        }
      }
    ];
  }

  loadCurrentUser(): void {
    const token: string = localStorage.getItem('token');

    this.accountService.loadCurrentUser(token)
      .subscribe({
      next: () => console.log('LOADED USER', token),
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
