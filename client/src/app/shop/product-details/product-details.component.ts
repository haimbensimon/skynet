import { ActivatedRoute} from '@angular/router';
import { IProduct } from './../../shared/Models/products';
import { Component, Input, OnInit } from '@angular/core';
import { ShopService } from '../shop.service';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss']
})
export class ProductDetailsComponent implements OnInit {
  product!:IProduct;

  constructor(private shopService:ShopService,private activatedRoutes:ActivatedRoute) { }

  ngOnInit(): void {
    this.loadProduct();
  }
  loadProduct(){
    this.shopService.getProduct(this.activatedRoutes.snapshot.paramMap.get('id')).subscribe(product => {
      this.product = product;
    }, error => {
      console.log(error);
    });
  }

}
