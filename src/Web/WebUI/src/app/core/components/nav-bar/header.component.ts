import {Component, OnInit, ViewEncapsulation} from '@angular/core';
import {BasketService} from "../../../features/basket/basket.service";
import {debounceTime, distinctUntilChanged, Observable, of, switchMap} from "rxjs";
import {IBasket} from "../../models/basket";
import {MatDialog, MatDialogConfig, MatDialogRef} from "@angular/material/dialog";
import {BasketComponent} from "../../../features/basket/basket/basket.component";
import {Overlay} from "@angular/cdk/overlay";
import {NavigationEnd, Router} from "@angular/router";
import {IUser} from "../../models/user";
import {AccountService} from "../../../features/account/account.service";
import {WishlistService} from "../../../features/wishlist/wishlist.service";
import {IWishlist} from "../../models/customer/wishlist";
import {LoginComponent} from "../../../features/account/login/login.component";
import {WishlistComponent} from "../../../features/wishlist/wishlist/wishlist.component";
import {NavModalComponent} from "../nav-modal/nav-modal/nav-modal.component";
import {SearchService} from "../../services/search.service";
import {FormBuilder, FormGroup} from "@angular/forms";
import {IProduct} from "../../models/product";
import {IPagination} from "../../models/pagination";


@Component({
  selector: 'app-nav-bar',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class HeaderComponent implements OnInit {

  basket$: Observable<IBasket>;
  wishlist$: Observable<IWishlist>;
  currentUser$: Observable<IUser>;
  searchResults$: Observable<IPagination>;


  isMenuActive: boolean = false;
  isSearchActive: boolean = false;
  dialogRef: MatDialogRef<BasketComponent>;
  isCheckoutPage: boolean = false;

  searchForm: FormGroup;


  constructor(
    private basketService: BasketService,
    public dialog: MatDialog,
    private overlay: Overlay,
    private router: Router,
    private accountService: AccountService,
    private wishlistService: WishlistService,
    private searchService: SearchService,
    private formBuilder: FormBuilder
  ) {
    this.searchForm = this.formBuilder.group({
      search: ['']
    });
  }

  ngOnInit() {
    this.basket$ = this.basketService.basket$;
    this.currentUser$ = this.accountService.currentUser$;
    this.wishlist$ = this.wishlistService.wishlist$;
    this.checkIfCheckoutPage();

    this.searchResults$ = this.searchForm.get('search').valueChanges.pipe(
      debounceTime(300),
      distinctUntilChanged(),
      switchMap((searchValue: string) => {
        if (searchValue.trim() === '') {
          return of({ pageIndex: 0, pageSize: 0, count: 0, data: [] });
        } else {
          return this.searchService.search(searchValue);
        }
      })
    );
  }


  openLoginModal() {
    this.dialog.open(LoginComponent, {
      width: '415px',
      height: '570px',
    })
  }

  openWishlistModal()  {
    this.dialog.open(WishlistComponent, {
      width: '1180px',
      height: '675px',
    })
  }

  openMenuModal () {
    this.dialog.open(NavModalComponent, {
      width: '1180px',
      height: '715px',
      hasBackdrop: false
    })
  }

  toggleSearch() {
    this.isSearchActive = !this.isSearchActive;
    if (!this.isSearchActive) this.searchForm.patchValue({ search: '' });
  }

  toggleMenu() {
    this.isMenuActive = !this.isMenuActive;
    console.log("toggled");
  }

  openDialog() {

    const dialogConfig = new MatDialogConfig();

    dialogConfig.id = 'my-dialog-id';
    dialogConfig.width = '1008px';
    dialogConfig.height = '648px';
    dialogConfig.scrollStrategy = this.overlay.scrollStrategies.noop();
    dialogConfig.hasBackdrop = true;
    dialogConfig.disableClose = false
    dialogConfig.panelClass = 'custom-dialog-class';
    dialogConfig.restoreFocus = true;
    dialogConfig.closeOnNavigation = true;

    this.dialogRef = this.dialog.open(BasketComponent, dialogConfig);

    this.dialogRef.afterClosed().subscribe(result => {
      console.log(`Dialog result: ${result}`);
    });
  }

  closeDialog(): void {
    const dialogRef = this.dialog.getDialogById('my-dialog-id');
    if (dialogRef) {
      dialogRef.close();
    }
  }



  logout() {
    this.accountService.logout();
    this.router.navigateByUrl('/');
  }

  private checkIfCheckoutPage() {
    this.router.events.subscribe(event => {
      if (event instanceof NavigationEnd) {
        this.isCheckoutPage = (event.urlAfterRedirects === '/checkout');
      }
    });
  }

}
