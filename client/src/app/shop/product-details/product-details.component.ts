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

  constructor(private shopService:ShopService,private activatedRoutes:ActivatedRoute,private bc:BreadcrumbService) {
    this.bc.set('@productDetails', ' ');
   }

  ngOnInit(): void {
    this.loadProduct();
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
