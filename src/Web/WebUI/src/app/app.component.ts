import {Component, OnInit} from '@angular/core';
import {BasketService} from "./features/basket/basket.service";
import {AccountService} from "./features/account/account.service";
import {MenuItem, MessageService} from "primeng/api";
import {NavigationEnd, Router} from "@angular/router";
import {WishlistService} from "./features/wishlist/wishlist.service";
import {HistoryService} from "./shared/services/history.service";

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
    private wishlistService: WishlistService,
    private historyService: HistoryService,
    private messageService: MessageService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.loadBasket();
    this.loadWishlist();
    this.addItemsToSpeedDial();
    this.updateComponentVisibility();
    this.loadProductViewsHistory();
  }

  updateComponentVisibility() {
    this.router.events.subscribe(event => {
      if (event instanceof NavigationEnd) {
        const currentRoute = event.urlAfterRedirects;

        this.showNavigationBar = !(currentRoute === '/checkout');

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
    const basketId: string = localStorage.getItem('basket_id');
    if (basketId) {
      this.basketService.getBasket(basketId).subscribe({
        next: () => console.log('initialized basket'),
        error: error => console.log(error)
      })
    }
  }

  loadWishlist(): void {
    const wishlistId = localStorage.getItem('wishlist_id');
    console.log('wishlistId: ', wishlistId)
    if (wishlistId) {
      this.wishlistService.getWishlist(wishlistId).subscribe({
        next: () => console.log('initialized wishlist'),
        error: error => console.log('LoadWishlistError: ', error)
      })
    }
  }

  loadProductViewsHistory(): void {
    const viewsHistoryId: string = localStorage.getItem('views_history_id');
    if (viewsHistoryId) {
      this.historyService.getItemsFromProductsViewsHistory(viewsHistoryId).subscribe({
        next: () => console.log('initialized history'),
        error: error => console.log(error)
      })
    }
  }
}

