import {IViewedProduct} from "./viewedProduct";
import { v4 as uuidv4 } from 'uuid';

export interface IViewedProductList {
  id: string;
  viewedProducts: IViewedProduct[];
  createdAt: Date;
}

export class ViewedProductList implements IViewedProductList {

  id: string;
  createdAt: Date;

  constructor() {
    this.id = uuidv4();
    this.viewedProducts = [];
    this.createdAt = new Date();
  }

  viewedProducts: IViewedProduct[] = [];
}
