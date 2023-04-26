import {Component, OnInit, ViewEncapsulation} from '@angular/core';
import {BasketService} from "../../basket/basket.service";
import {Observable} from "rxjs";
import {IBasket} from "../../shared/models/basket";
import {MatDialog, MatDialogConfig} from "@angular/material/dialog";
import {BasketComponent} from "../../basket/basket/basket.component";
import {Overlay} from "@angular/cdk/overlay";
import {Router} from "@angular/router";
import {IUser} from "../../shared/models/user";
import {AccountService} from "../../account/account.service";


@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class NavBarComponent implements OnInit {

  //#region Properties

  basket$: Observable<IBasket>;
  currentUser$: Observable<IUser>;
  isIconRotated: boolean = false;

  //#endregion

  //#region Constructor

  constructor(private basketService: BasketService,
              public dialog: MatDialog,
              private overlay: Overlay,
              private router: Router,
              private accountService: AccountService
) {}

  //#endregion

  //#region Methods

  toggleIconRotation(): void {
    this.isIconRotated = !this.isIconRotated;
  }

  openDialog() {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.width = '1008px';
    dialogConfig.height = '648px';
    dialogConfig.scrollStrategy = this.overlay.scrollStrategies.noop();
    dialogConfig.hasBackdrop = true;
    dialogConfig.panelClass = 'custom-dialog-class';

    const dialogRef = this.dialog.open(BasketComponent, dialogConfig);

    dialogRef.afterClosed().subscribe(result => {
      console.log(`Dialog result: ${result}`);
    });
  }

  ngOnInit() {
    this.basket$ = this.basketService.basket$;
    this.currentUser$ = this.accountService.currentUser$;
  }

  logout() {
    this.accountService.logout();
    this.isIconRotated = false;
    this.router.navigateByUrl('/');
  }

  //#endregion
}
