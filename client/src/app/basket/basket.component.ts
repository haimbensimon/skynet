import { BasketService } from 'src/app/basket/basket.service';
import { Basket, IBasket, IBasketItem } from './../shared/Models/basket';
import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-basket',
  templateUrl: './basket.component.html',
  styleUrls: ['./basket.component.scss']
})
export class BasketComponent implements OnInit {
basket$!:Observable<IBasket>;
  constructor(private basketService :BasketService) { }

  ngOnInit(): void {
    this.basket$ = this.basketService.basket$;
  }

  removeBasketItem(item : IBasketItem){
    this.basketService.removeItemFromBasket(item);
  }
incrementItemQuantity(item : IBasketItem){
  this.basketService.incrementItemQuantity(item);
}

decrementItemQuantity(item : IBasketItem){
  this.basketService.decrementItemQuantity(item);
}

}
