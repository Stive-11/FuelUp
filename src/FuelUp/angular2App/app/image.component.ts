import {Component} from '@angular/core';
import { Observable } from 'rxjs/Observable';
import {Image} from './image.interface';
let styles = String(require('./image.component.scss'));

@Component({
    selector: 'filtres',
    template: `
    <div class="cont">
  <ul class="filters">
    <li *ngFor="let image of images">
      <img src="{{image.url}}" alt="{{image.title}}">
    </li>
  </ul>
</div>
  `,
    styles: ["require('./image.component.scss')"]
    //styles: [styles]
})

//Carousel Component itself
export class ImgComponent {
    //images data to be bound to the template
    public images = IMAGES;
}

//IMAGES array implementing Image interface
var IMAGES: Image[] = [
    { "title": "bankomat", "url": "./assets/bankomat.png" },
    { "title": "24/7", "url": "assets/24.png" },
    { "title": "exchange", "url": "assets/exchange.png" },
    { "title": "phone", "url": "assets/phone.png" },
    { "title": "hotel", "url": "assets/hotel.png" },
    { "title": "shop", "url": "assets/shop.png" },
    { "title": "repair", "url": "assets/repair.png" },
    { "title": "tires", "url": "assets/tires.png" },
    { "title": "wc", "url": "assets/wc.png" },
    { "title": "car auto wash", "url": "assets/carautowash.png" },
    { "title": "carwash", "url": "assets/carwash.png" },
    { "title": "garden", "url": "assets/garden.png" },
    { "title": "insurance", "url": "assets/shield.png" },
    { "title": "trailer", "url": "assets/pri.png" },
    { "title": "remove tires", "url": "assets/remove.png" }
    
];