import {Component, OnInit} from '@angular/core';
import {IOrder} from "../../../core/models/order";
import {OrderService} from "../../../shared/services/order-service/order.service";

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.scss']
})
export class OrdersComponent implements OnInit {

  orders: IOrder[] = [];

  constructor(private orderService: OrderService) {

  }

  ngOnInit(): void {
    this.orderService.getUserOrders().subscribe({
      next: (orders: IOrder[]) => {
        this.orders = orders;
        console.log("orders for account", this.orders);
      },
      error: (error) => {
        console.log(error);
      }
    })
  }

}
