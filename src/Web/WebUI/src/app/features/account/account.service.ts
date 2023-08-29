import { Injectable } from '@angular/core';
import {environment} from "../../../environments/environment";
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {BehaviorSubject, Observable, of, ReplaySubject} from "rxjs";
import {IUser} from "../../core/models/user";
import {map} from "rxjs/operators";
import {Router} from "@angular/router";
import {IAddress} from "../../core/models/address";
import {IProductReview} from "../../core/models/catalog/product-review";

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  baseUrl: string = environment.apiUrl;
  private currentUserSource: ReplaySubject<IUser> = new ReplaySubject<IUser>(1);
  currentUser$: Observable<IUser> = this.currentUserSource.asObservable();

  constructor(
    private httpClient: HttpClient,
    private router: Router,
  ) { }

  loadCurrentUser(token: string) {

    console.log("triggered0")

    if (token === null) {
      this.currentUserSource.next(null);
      return of(null);
    }

    return this.httpClient.get(this.baseUrl + 'User')
      .pipe(map((user: IUser) => {
        console.log("triggered")
        if (user) {
          localStorage.setItem('token', user.token);
          this.currentUserSource.next(user);
          console.log("triggered2")
          console.log(user)
        }
      }));
  }

  login(values: any) {
    return this.httpClient.post(this.baseUrl + 'authentication/login', values).pipe(
      map((user: IUser) => {
        if (user) {
          localStorage.setItem('token', user.token);
          this.currentUserSource.next(user);
        }
      }
    ));
  }

  logout() {
    localStorage.removeItem('token');
    this.currentUserSource.next(null);
    this.router.navigateByUrl('/');
  }

  register(values: any) {
    return this.httpClient.post(this.baseUrl + 'authentication/register', values).pipe(
      map((user: IUser) => {
        if (user) {
          localStorage.setItem('token', user.token);
          this.currentUserSource.next(user);
        }
      }
    ));
  }

  checkEmailExists(email: string) {
    return this.httpClient.get(this.baseUrl + 'User/Emailexists?email=' + email);
  }

  getUserAddress(): Observable<IAddress> {
   /* const headers = new HttpHeaders().set('Authorization', `Bearer ${localStorage.getItem('token')}`);*/
    return this.httpClient.get<IAddress>(this.baseUrl + 'User/Address');
    /*return this.httpClient.get<IAddress>(this.baseUrl + 'account/address');*/
  }

  updateUserAddress(address: IAddress): Observable<IAddress> {
    /*const headers = new HttpHeaders().set('Authorization', `Bearer ${localStorage.getItem('token')}`);*/
    return this.httpClient.put<IAddress>(this.baseUrl + 'User/Address', address);
    /*return this.httpClient.put<IAddress>(this.baseUrl + 'account/address', address);*/
  }

  createUserAddress(address: IAddress): Observable<IAddress> {
    return this.httpClient.post<IAddress>(this.baseUrl + 'account/address', address);
  }

  getUserReviews(): Observable<IProductReview[]> {
    return this.httpClient.get<IProductReview[]>(this.baseUrl + 'User/Reviews');
  }


}
