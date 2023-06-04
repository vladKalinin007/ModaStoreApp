import {Component, Input, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {CheckoutService} from "../checkout.service";
import {IDeliveryMethod} from "../../../core/models/deliveryMethod";
import {BasketService} from "../../basket/basket.service";
import {ICity} from "../../../core/models/city";

@Component({
  selector: 'app-checkout-delivery',
  templateUrl: './checkout-delivery.component.html',
  styleUrls: ['./checkout-delivery.component.scss']
})
export class CheckoutDeliveryComponent implements OnInit {

  @Input() checkoutForm: FormGroup;
  deliveryMethods: IDeliveryMethod[];
  cities: ICity[];
  selectedCity: ICity;
  isPostalDeliverySelected: boolean = false;

  firstFormGroup = this._formBuilder.group({
    firstCtrl: ['', Validators.required],
  });
  secondFormGroup = this._formBuilder.group({
    secondCtrl: ['', Validators.required],
  });
  isLinear = false;
  isOnlineSelected: boolean = false;

  constructor(
    private _formBuilder: FormBuilder,
    private checkoutService: CheckoutService,
    private basketService: BasketService
  ) { }

  ngOnInit() {
    /*this.getDeliveryMethods();*/
    this.cities = [
      { name: 'New York', code: 'NY' },
      { name: 'Rome', code: 'RM' },
      { name: 'London', code: 'LDN' },
      { name: 'Istanbul', code: 'IST' },
      { name: 'Paris', code: 'PRS' }
    ];
  }

  radioButtonChange(event: any) {
    this.isOnlineSelected = event.source.value === "2";
  }

  getDeliveryMethods() {
    this.checkoutService.getDeliveryMethods().subscribe( {
      next: (dm: IDeliveryMethod[]) => {
        this.deliveryMethods = dm;
      },
      error: (error) => {
        console.log(error);
      }
    });
  }

  isPostalDeliverySelectedChange() {
    this.isPostalDeliverySelected = !this.isPostalDeliverySelected;
  }

  setShippingPrice(deliveryMethod: IDeliveryMethod) {
    this.basketService.setShippingPrice(deliveryMethod);
  }


}
