import {Component, OnInit, ViewEncapsulation} from '@angular/core';
import {BasketService} from "../../../features/basket/basket.service";
import {Observable} from "rxjs";
import {IBasket} from "../../models/basket";
import {MatDialog, MatDialogConfig, MatDialogRef} from "@angular/material/dialog";
import {BasketComponent} from "../../../features/basket/basket/basket.component";
import {Overlay} from "@angular/cdk/overlay";
import {Router} from "@angular/router";
import {IUser} from "../../models/user";
import {AccountService} from "../../../features/account/account.service";


@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class NavBarComponent implements OnInit {

  basket$: Observable<IBasket>;
  currentUser$: Observable<IUser>;
  isIconRotated: boolean = false;
  dialogRef: MatDialogRef<BasketComponent>;

  constructor(private basketService: BasketService,
              public dialog: MatDialog,
              private overlay: Overlay,
              private router: Router,
              private accountService: AccountService
) {}


  toggleIconRotation(): void {
    this.isIconRotated = !this.isIconRotated;
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



    //TODO: Решить проблему с модальным окном

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
