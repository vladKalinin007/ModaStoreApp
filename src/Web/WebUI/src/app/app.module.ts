import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {HTTP_INTERCEPTORS, HttpClientModule} from "@angular/common/http";
import {CoreModule} from "./core/core.module";
import {HomeModule} from "./features/home/home.module";
import {ErrorInterceptor} from "./core/interceptors/error.interceptor";
import {NgxSpinnerModule} from "ngx-spinner";
/*import {LoadingInterceptor} from "./core/interceptors/loading.interceptor";*/
import {DialogService, DynamicDialogModule} from 'primeng/dynamicdialog';
import {MessageService} from "primeng/api";
/*import {MaterialModule} from "../material.module";*/
import {MatNativeDateModule} from "@angular/material/core";
import {DialogModule} from "@angular/cdk/dialog";
import {JwtInterceptor} from "./core/interceptors/jwt.interceptor";
import {CommonModule} from "@angular/common";
import {SpeedDialModule} from "primeng/speeddial";
import {SharedModule} from "./shared/shared.module";
/*import {basketReducer} from "./features/basket/reducers/basket.reducer";*/


@NgModule({
  declarations: [
    AppComponent,
  ],
    imports: [
        CommonModule,
        BrowserModule,
        AppRoutingModule,
        BrowserAnimationsModule,
        HttpClientModule,
        CoreModule,
        HomeModule,
        NgxSpinnerModule,
        MatNativeDateModule,
        DynamicDialogModule,
        DialogModule,
        SpeedDialModule,
        SharedModule,
        /*StoreModule.forRoot({basket: basketReducer}),*/
    ],
  providers: [
    {provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true}
    /*{provide: HTTP_INTERCEPTORS, useClass: LoadingInterceptor, multi: true}*/
    /*{provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true},*/
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
