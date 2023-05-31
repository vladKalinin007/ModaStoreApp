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

  cities: ICity[];

  selectedCity: ICity;

  isPostalDeliverySelected: boolean = false;

  constructor(private _formBuilder: FormBuilder) { }

  ngOnInit() {
    this.cities = [
      { name: 'New York', code: 'NY' },
      { name: 'Rome', code: 'RM' },
      { name: 'London', code: 'LDN' },
      { name: 'Istanbul', code: 'IST' },
      { name: 'Paris', code: 'PRS' }
    ];
  }

  firstFormGroup = this._formBuilder.group({
    firstCtrl: ['', Validators.required],
  });
  secondFormGroup = this._formBuilder.group({
    secondCtrl: ['', Validators.required],
  });
  isLinear = false;

  isPostalDeliverySelectedChange() {
    this.isPostalDeliverySelected = !this.isPostalDeliverySelected;
  }

/*  @Input() checkoutForm: FormGroup;
  deliveryMethods: IDeliveryMethod[];

  constructor(private checkoutService: CheckoutService, private basketService: BasketService) { }

  ngOnInit(): void {
    this.checkoutService.getDeliveryMethods().subscribe( {
      next: (dm: IDeliveryMethod[]) => {
        this.deliveryMethods = dm;
      },
      error: (error) => {
        console.log(error);
      }
    });
  }

  setShippingPrice(deliveryMethod: IDeliveryMethod) {
    this.basketService.setShippingPrice(deliveryMethod);
  }*/


}
