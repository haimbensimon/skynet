import { BasketService } from 'src/app/basket/basket.service';
import { ActivatedRoute} from '@angular/router';
import { IProduct } from './../../shared/Models/products';
import { Component, Input, OnInit } from '@angular/core';
import { ShopService } from '../shop.service';
import { BreadcrumbService } from 'xng-breadcrumb';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss']
})
export class ProductDetailsComponent implements OnInit {
  product!:IProduct;
  quantity = 1;

  constructor(private shopService:ShopService,private activatedRoutes:ActivatedRoute,private bc:BreadcrumbService,private basketService:BasketService) {
    this.bc.set('@productDetails', ' ');
   }

  ngOnInit(): void {
    this.loadProduct();
  }
addItemToCart(){
  this.basketService.addItemsToBasket(this.product,this.quantity);
}

incQuantity(){
  this.quantity++;
}

decQuantity(){
  if(this.quantity > 1){
    this.quantity--;
  }

}

  loadProduct(){
    this.shopService.getProduct(this.activatedRoutes.snapshot.paramMap.get('id')).subscribe(product => {
      this.product = product;
      this.bc.set('@productDetails',product.name)
    }, error => {
      console.log(error);
    });
  }

}
