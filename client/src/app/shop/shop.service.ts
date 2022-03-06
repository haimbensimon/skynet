import { IProduct } from './../shared/Models/products';
import { ShopParams } from './../shared/Models/shopParams';
import { IPagination } from './../shared/Models/paginations';
import { IBrand } from './../shared/Models/brand';

import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs';
import { IType } from '../shared/Models/productType';

@Injectable({
  providedIn: 'root',
})
export class ShopService {
  baseUrl = 'https://localhost:5001/api/';
  constructor(private http: HttpClient) {}

  getProducts(shopParams:ShopParams) {
    let params = new HttpParams();
    if (shopParams.brandId != 0) {
      params = params.append('brandId', shopParams.brandId.toString());
    }
    if (shopParams.typeId != 0) {
      params = params.append('typeId', shopParams.typeId.toString());

    }
    if (shopParams.search) {
      params = params.append('search', shopParams.search);

    }

      params = params.append('sort', shopParams.sort);
      params = params.append('pageIndex' ,shopParams.pageNumber.toString());
      params = params.append('pageIndex' , shopParams.pageSize.toString());
    console.log({ observe: 'response', params });
    return this.http
      .get<IPagination>(this.baseUrl + 'products', {
        observe: 'response',
        params,
      })
      .pipe(
        map((respone): any => {
          return respone.body;
        })
      );
  }

 getProduct(id :any){
   return this.http.get<IProduct>(this.baseUrl + 'products/' + id);
 }

  getBrand() {
    return this.http.get<IBrand[]>(this.baseUrl + 'products/brands');
  }

  getTypes() {
    return this.http.get<IType[]>(this.baseUrl + 'products/types');
  }
}
