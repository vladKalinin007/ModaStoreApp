import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {HTTP_INTERCEPTORS, HttpClientModule} from "@angular/common/http";
import {CoreModule} from "./core/core.module";
import {HomeModule} from "./home/home.module";
import {ErrorInterceptor} from "./core/interceptors/error.interceptor";
import {NgxSpinnerModule} from "ngx-spinner";
import {LoadingInterceptor} from "./core/interceptors/loading.interceptor";
import {DialogService, DynamicDialogModule} from 'primeng/dynamicdialog';
import {MessageService} from "primeng/api";
import {MaterialModule} from "../material.module";
import {MatNativeDateModule} from "@angular/material/core";
import {DialogModule} from "@angular/cdk/dialog";


@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    CoreModule,
    HomeModule,
    MaterialModule,
    NgxSpinnerModule,
    MatNativeDateModule,
    DynamicDialogModule,
    DialogModule
  ],

  providers: [
    {provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true},
    {provide: HTTP_INTERCEPTORS, useClass: LoadingInterceptor, multi: true},
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
