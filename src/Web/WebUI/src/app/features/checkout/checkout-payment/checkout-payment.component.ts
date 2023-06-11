import {AfterViewInit, Component, ElementRef, Input, OnDestroy, OnInit, ViewChild} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {BasketService} from "../../basket/basket.service";
import {CheckoutService} from "../checkout.service";
import {ToastrService} from "ngx-toastr";
import {IBasket} from "../../../core/models/basket";
import {IOrder} from "../../../core/models/order";
import {NavigationExtras, Router} from "@angular/router";
import {environment} from "../../../../environments/environment";
import {Observable} from "rxjs";
/*import { StripeService, StripeCardComponent } from 'ngx-stripe';*/


declare var Stripe;

@Component({
  selector: 'app-checkout-payment',
  templateUrl: './checkout-payment.component.html',
  styleUrls: ['./checkout-payment.component.scss']
})
export class CheckoutPaymentComponent implements OnInit, AfterViewInit, OnDestroy {


  @Input() checkoutForm: FormGroup;
  @ViewChild('cardNumber', {static: true}) cardNumberElement: ElementRef;
  @ViewChild('cardExpiry', {static: true}) cardExpiryElement: ElementRef;
  @ViewChild('cardCvc', {static: true}) cardCvcElement: ElementRef;

  basket$: Observable<IBasket>;

  stripe: any;
  cardNumber: any;
  cardExpiry: any;
  cardCvc: any;
  cardErrors: any;

  loading: boolean = false;
/*  stripeService: StripeService;*/

  value: string;
  isOnlineSelected: boolean = false;
  cardNumberValid: boolean = false;
  cardExpiryValid: boolean = false;
  cardCvcValid: boolean = false;

  cardHandler = this.onChange.bind(this);

  constructor(
    private basketService: BasketService,
    private checkoutService: CheckoutService,
    private toastr: ToastrService,
    private router: Router,
    private _formBuilder: FormBuilder
  ) { }


  ngOnInit(): void {
    this.basket$ = this.basketService.basket$;
  }

  ngAfterViewInit(): void {

    this.stripe = Stripe('pk_test_51N2dxoAoGAOX0ZrldcpNA9P3tDlCWnSlv1S1dHfEcuqRxdJ6d4td8X0bINRoEOAF1vq99FvWIcQaRqj6NYSA5iZ200jX0tZYRh');
    const elements = this.stripe.elements();

    this.cardNumber = elements.create('cardNumber');
    this.cardNumber.mount(this.cardNumberElement.nativeElement);
    this.cardNumber.addEventListener('change', this.cardHandler);

    this.cardExpiry = elements.create('cardExpiry');
    this.cardExpiry.mount(this.cardExpiryElement.nativeElement);
    this.cardExpiry.addEventListener('change', this.cardHandler);

    this.cardCvc = elements.create('cardCvc');
    this.cardCvc.mount(this.cardCvcElement.nativeElement);
    this.cardCvc.addEventListener('change', this.cardHandler);
  }

  ngOnDestroy() {
    this.cardNumber.destroy();
    this.cardExpiry.destroy();
    this.cardCvc.destroy();
  }

  onChange(event) {
    if (event.error) {
      this.cardErrors = event.error.message;
    } else {
      this.cardErrors = null;
    }

    switch (event.elementType) {

      case 'cardNumber':
        this.cardNumberValid = event.complete;
        break;
      case 'cardExpiry':
        this.cardExpiryValid = event.complete;
        break;
      case 'cardCvc':
        this.cardCvcValid = event.complete;
        break;

      default:
        break;
    }
  }

  radioButtonChange(event: any) {
    this.isOnlineSelected = event.source.value === "2";
  }

  /*submitOrder() {
    const basket = this.basketService.getCurrentBasketValue();

    this.createOrder(basket).then(createdOrder =>
      {

        this.confirmPaymentWithStripe(basket).then(paymentResult =>
          {
            if (paymentResult.paymentIntent) {
              this.basketService.deleteBasket(basket);
              const navigationExtras: NavigationExtras = {state: createdOrder};
              this.router.navigate(['checkout/success'], navigationExtras);
              this.toastr.success("Success");
            } else {
              this.toastr.error(paymentResult.error.message);
            }
          });
      });
  }*/

  async submitOrder() {

    try {
      const basket = this.basketService.getCurrentBasketValue();
      const createdOrder = await this.createOrder(basket);
      const paymentResult = await this.confirmPaymentWithStripe(basket);

      this.toastr.success('Success');
      this.router.navigate(['/']);


      if (paymentResult.paymentIntent) {
        console.log("inside payment intent")
        this.basketService.deleteBasket(basket);
        const navigationExtras: NavigationExtras = { state: createdOrder };
        this.router.navigate(['checkout/success'], navigationExtras);
        this.toastr.success('Success');
        console.log("exit if block")
      } else {
        this.toastr.error(paymentResult.error.message);
      }
    } catch (error) {
      // Обработка ошибок
      console.error(error);
      this.toastr.error('An error occurred while submitting the order.');
    }
  }


  /*  async submitOrder() {

      this.loading = true;

      const basket = this.basketService.getCurrentBasketValue();

      try {

        const createdOrder = await this.createOrder(basket);

        const paymentResult = await this.confirmPaymentWithStripe(basket);

        if (paymentResult.paymentIntent) {
          this.basketService.deleteBasket(basket);
          const navigationExtras: NavigationExtras = {state: createdOrder};
          this.router.navigate(['checkout/success'], navigationExtras);
        } else {
          this.toastr.error(paymentResult.error.message);
        }

        this.loading = false;
      } catch (e) {
        console.log(e);
        this.loading = false;
        this.toastr.error(e.message);
      }

    }*/

  private getOrderToCreate(basket: IBasket) {
    return {
      basketId: basket.id,
      deliveryMethodId: +this.checkoutForm.get('deliveryForm').get('deliveryMethod').value,
      shipToAddress: this.checkoutForm.get('addressForm').value
    }

  }


  private async createOrder(basket: IBasket) {
    const orderToCreate = this.getOrderToCreate(basket);
    return this.checkoutService.createOrder(orderToCreate);
  }

  private async confirmPaymentWithStripe(basket: IBasket) {
    return this.stripe.confirmCardPayment(basket.clientSecret, {
      payment_method: {
        card: this.cardNumber,
        billing_details: {
          name: this.checkoutForm.get('paymentForm').get('nameOnCard').value
        }
      }
    });
  }

  createPaymentIntent() {
    return this.basketService.createPaymentIntent()
      .subscribe({
        next: (response) => {
          this.toastr.success('Payment intent created');
        },
        error: (error) => {
          console.log(error);
          this.toastr.error(error.message);
        }
      })
  }
}
