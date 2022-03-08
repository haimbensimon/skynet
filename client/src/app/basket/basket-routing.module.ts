import { BasketComponent } from './basket.component';
import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';


const route:Routes = [
  {path:'',component:BasketComponent}
]

@NgModule({
  declarations: [],
  imports: [
   RouterModule.forChild(route)
  ],
  exports:[RouterModule]
})
export class BasketRoutingModule { }
