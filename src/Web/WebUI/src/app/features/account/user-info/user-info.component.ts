import { Component } from '@angular/core';
import {MatSidenavModule} from "@angular/material/sidenav";
import {NgIf} from "@angular/common";

@Component({
  selector: 'app-user-info',
  templateUrl: './user-info.component.html',
  styleUrls: ['./user-info.component.scss']
 /* imports: [NgIf, MatSidenavModule],
  standalone: true*/
})
export class UserInfoComponent {
  shouldRun = true;
}
