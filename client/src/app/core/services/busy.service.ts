import { Injectable } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';

@Injectable({
  providedIn: 'root'
})
export class BusyService {
busyRequestCount = 0;
  constructor(private sprService:NgxSpinnerService) { }

  busy(){
    this.busyRequestCount++;
    this.sprService.show(undefined,{
      type: 'square-loader',
      bdColor:'rgba(255,255,255,0.7)',
      color:'#333333'
    });
  }

  idle(){
    this.busyRequestCount--;
    if(this.busyRequestCount <= 0 ){
      this.busyRequestCount = 0;
      this.sprService.hide();
    }
  }
}
