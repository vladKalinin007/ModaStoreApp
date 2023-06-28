import {IWishlistItem} from "./wishlistItem";
import { v4 as uuidv4 } from 'uuid';

export interface IWishlist {
  id: string;
  wishlistItems: IWishlistItem[];
}

export class Wishlist implements IWishlist {

  id: string;

  constructor() {
    this.id = uuidv4();
    this.wishlistItems = [];
  }

  wishlistItems: IWishlistItem[] = [];
}
