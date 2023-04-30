import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {NavBarComponent} from "./components/nav-bar/nav-bar.component";
import { FooterComponent } from './components/footer/footer.component';
import {RouterModule} from "@angular/router";
import { TestErrorComponent } from './components/test-error/test-error.component';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { ServerErrorComponent } from './components/server-error/server-error.component';
import {ToastrModule} from "ngx-toastr";
import { SectionHeaderComponent } from './components/section-header/section-header.component';
import {BreadcrumbModule} from "xng-breadcrumb";
import {SharedModule} from "../shared/shared.module";
import {MaterialModule} from "../../material.module";





@NgModule({
  declarations: [NavBarComponent, FooterComponent, TestErrorComponent, NotFoundComponent, ServerErrorComponent, SectionHeaderComponent],
  imports: [
    CommonModule,
    RouterModule,
    BreadcrumbModule,
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-right',
      preventDuplicates: true
    }),
    SharedModule
  ],
  exports: [NavBarComponent, FooterComponent, SectionHeaderComponent]
})
export class CoreModule { }
