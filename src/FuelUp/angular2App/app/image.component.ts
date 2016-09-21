import {Component} from '@angular/core';
import { Observable } from 'rxjs/Observable';
import {Image} from './image.interface';
declare var jQuery: any;
let styles = String(require('./image.component.scss'));

@Component({
    selector: 'filtres',
    template: ` 
  <ul class="filters"> 
    <li *ngFor="let image of images">
        <div data-title="{{image.title}}" (click)="toggleImage(image)" class="{{image.class}}"> 
            <img src="{{image.url}}"/>
         </div>
    </li>
  </ul>
  `,
    styles: ["require('./image.component.scss')"],
    //styles: [styles]

})

//Carousel Component itself
export class ImgComponent {
    //images data to be bound to the template
    public images = IMAGES;
    public currentServices = [];
    public toggleImage(image) {
        jQuery(image).toggleClass("imagePressed");
        if (image.class == "imageUnpressed") {
            image.class = "imagePressed";
            this.currentServices.push(image.id);
            console.info("MASSIVE:"+this.currentServices.length);
        } else {
            image.class = "imageUnpressed";
            var index = this.currentServices.indexOf(image.id);
            this.currentServices.splice(index, 1);
            console.info("MASSIVE:" + this.currentServices.length);
        }
       
    }
}


//IMAGES array implementing Image interface
var IMAGES: Image[] = [
    { "title": "Круглосуточное обслуживание", "url": "assets/24.png", "id": 1,  "class":"imageUnpressed" },
    { "title": "Банкомат", "url": "./assets/bankomat.png", "id": 13, "class": "imageUnpressed" },
    { "title": "Обмен валют", "url": "assets/exchange.png", "id": 14, "class": "imageUnpressed" },
    { "title": "Таксофон", "url": "assets/phone.png", "id": 18, "class": "imageUnpressed" },
    { "title": "Отель", "url": "assets/hotel.png", "id": 25, "class": "imageUnpressed" },
    { "title": "Магазин", "url": "assets/shop.png", "id": 23, "class": "imageUnpressed" },
    { "title": "СТО", "url": "assets/repair.png", "id": 27, "class": "imageUnpressed" },
    { "title": "Подкачка шин", "url": "assets/tires.png", "id": 6, "class": "imageUnpressed" },
    { "title": "WC", "url": "assets/wc.png", "id": 5, "class": "imageUnpressed" },
    { "title": "Туалет для инвалидов", "url": "assets/diswc.png", "id": 15, "class": "imageUnpressed" },
    { "title": "Автоматическая мойка", "url": "assets/carautowash.png", "id": 3, "class": "imageUnpressed" },
    { "title": "Ручная мойка", "url": "assets/carwash.png", "id": 4, "class": "imageUnpressed" },
    { "title": "Садовый центр", "url": "assets/garden.png", "id": 12, "class": "imageUnpressed" },
    { "title": "Страхование авто", "url": "assets/shield.png", "id": 20, "class": "imageUnpressed" },
    { "title": "Аренда прицепов", "url": "assets/pri.png", "id": 11, "class": "imageUnpressed" },
    { "title": "Шиномонтаж", "url": "assets/remove.png", "id": 15, "class": "imageUnpressed" },
    { "title": "Ксерокопия", "url": "assets/copy.png", "id": 15, "class": "imageUnpressed" },
    { "title": "WIFI", "url": "assets/wifi.png", "id": 15, "class": "imageUnpressed" },
    { "title": "Аренда велосипедов", "url": "assets/bike.png", "id": 15, "class": "imageUnpressed" },
    { "title": "Паркинг", "url": "assets/parking.png", "id": 15, "class": "imageUnpressed" },
    { "title": "AdBlue", "url": "assets/adblue.png", "id": 15, "class": "imageUnpressed" },
    { "title": "BelToll", "url": "assets/beltoll.png", "id": 15, "class": "imageUnpressed" },
    { "title": "Кафе", "url": "assets/cafe.png", "id": 15, "class": "imageUnpressed" },
    { "title": "Душ", "url": "assets/shower.png", "id": 15, "class": "imageUnpressed" },
    { "title": "Терминал оплаты", "url": "assets/terminal.png", "id": 15, "class": "imageUnpressed" },
    { "title": "Продажа шин", "url": "assets/tiressale.png", "id": 15, "class": "imageUnpressed" },
    { "title": "Пылесос", "url": "assets/vacuum.png", "id": 15, "class": "imageUnpressed" },
    { "title": "Колонка отпуска жидкости в стеклоомыватель", "url": "assets/window.png", "id": 15, "class": "imageUnpressed" },
  
];