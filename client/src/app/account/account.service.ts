import { Injectable } from '@angular/core';
import {environment} from "../../environments/environment";
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {BehaviorSubject, Observable, of, ReplaySubject} from "rxjs";
import {IUser} from "../shared/models/user";
import {map} from "rxjs/operators";
import {Router} from "@angular/router";
import {IAddress} from "../shared/models/address";

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  //region Properties
  baseUrl: string = environment.apiUrl;
  private currentUserSource: ReplaySubject<IUser> = new ReplaySubject<IUser>(1);
  currentUser$: Observable<IUser> = this.currentUserSource.asObservable();
  //endregion

  //region Constructor
  constructor(
    private httpClient: HttpClient,
    private router: Router
  ) { }
  //endregion

  //region Methods

  loadCurrentUser(token: string): Observable<void> {

    if (token === null) {
      this.currentUserSource.next(null);
      return of(null);
    }

    let headers = new HttpHeaders();
    headers = headers.set('Authorization', `Bearer ${token}`);
    return this.httpClient
      .get(this.baseUrl + 'account', {headers})
      .pipe(
      map((user: IUser) => {
        if (user) {
          localStorage.setItem('token', user.token);
          this.currentUserSource.next(user);
        }
      }));
  }

  login(values: any) {
    return this.httpClient.post(this.baseUrl + 'account/login', values).pipe(
      map((user: IUser) => {
        if (user) {
          localStorage.setItem('token', user.token);
          this.currentUserSource.next(user);
        }
      }
    ));
  }

  register(values: any) {
    return this.httpClient.post(this.baseUrl + 'account/register', values).pipe(
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

  checkEmailExists(email: string) {
    return this.httpClient.get(this.baseUrl + 'account/emailexists?email=' + email);
  }

  getUserAddress(): Observable<IAddress> {
    return this.httpClient.get<IAddress>(this.baseUrl + 'account/address');
  }

  updateUserAddress(address: IAddress): Observable<IAddress> {
    return this.httpClient.put<IAddress>(this.baseUrl + 'account/address', address);
  }



  //endregion

}
