import {Component, EventEmitter, Input, Output} from '@angular/core';
import { Observable } from 'rxjs/Observable';
import {Image} from './image.interface';
import Httpservice = require("./http/http.service");
import { Http, Headers, RequestOptions } from '@angular/http';
declare var jQuery: any;
let styles = String(require('./image.component.scss'));

@Component({
    selector: 'filtres',
    template: ` 
     <button type="button" (click)="onClick($event)" class="btn btn-success apply">{{apply}}</button>
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
    providers: [Httpservice.HTTPService]

})

export class ImgComponent {
    public apply: string = "Применить фильтры";
    public images = IMAGES;
    public servicesCode: number = 0;
    public errorMessage: string;
    constructor(private _httpService: Httpservice.HTTPService) { }
    @Output() notify = new EventEmitter<number>();
    public toggleImage(image) {
        jQuery(image).toggleClass("imagePressed");
        if (image.class == "imageUnpressed") {
            image.class = "imagePressed";
            this.servicesCode += image.code;
            console.info("Code: " + this.servicesCode);
        } else {
            image.class = "imageUnpressed";
            this.servicesCode -= image.code;
            console.info("Code: " + this.servicesCode);
        }    
    }
    
    onClick(event) {
        this.notify.emit(this.servicesCode);
    }
}


//IMAGES array implementing Image interface
var IMAGES: Image[] = [
    { "title": "Круглосуточное обслуживание", "url": "assets/24.png", "code": 1, "class": "imageUnpressed" },
    { "title": "AdBlue", "url": "assets/adblue.png", "code": 2, "class": "imageUnpressed" },
    { "title": "Автоматическая мойка", "url": "assets/carautowash.png", "code": 4, "class": "imageUnpressed" },
    { "title": "Ручная мойка", "url": "assets/carwash.png", "code": 8, "class": "imageUnpressed" },
    { "title": "WC", "url": "assets/wc.png", "code": 16, "class": "imageUnpressed" },
    { "title": "Подкачка шин", "url": "assets/tires.png", "code": 32, "class": "imageUnpressed" },
    { "title": "Пылесос", "url": "assets/vacuum.png", "code": 64, "class": "imageUnpressed" },
    { "title": "Терминал оплаты", "url": "assets/terminal.png", "code": 128, "class": "imageUnpressed" },
    { "title": "Паркинг", "url": "assets/parking.png", "code": 256, "class": "imageUnpressed" },
    { "title": "Продажа шин", "url": "assets/tiressale.png", "code": 512, "class": "imageUnpressed" },
    { "title": "Аренда прицепов", "url": "assets/pri.png", "code": 1024, "class": "imageUnpressed" },
    { "title": "Садовый центр", "url": "assets/garden.png", "code": 2048, "class": "imageUnpressed" },
    { "title": "Банкомат", "url": "./assets/bankomat.png", "code": 4096, "class": "imageUnpressed" },
    { "title": "Обмен валют", "url": "assets/exchange.png", "code": 8192, "class": "imageUnpressed" },
    { "title": "Шиномонтаж", "url": "assets/remove.png", "code": 16384, "class": "imageUnpressed" },
    { "title": "Колонка отпуска жидкости в стеклоомыватель", "url": "assets/window.png", "code": 32768, "class": "imageUnpressed" },
    { "title": "WIFI", "url": "assets/wifi.png", "code": 65536, "class": "imageUnpressed" },
    { "title": "Таксофон", "url": "assets/phone.png", "code": 131072, "class": "imageUnpressed" },
    { "title": "Ксерокопия", "url": "assets/copy.png", "code": 262144, "class": "imageUnpressed" },
    { "title": "Страхование авто", "url": "assets/shield.png", "code": 524288, "class": "imageUnpressed" },
    { "title": "Туалет для инвалидов", "url": "assets/diswc.png", "code": 1048576, "class": "imageUnpressed" },
    { "title": "Аренда велосипедов", "url": "assets/bike.png", "code": 2097152, "class": "imageUnpressed" },
    { "title": "Магазин", "url": "assets/shop.png", "code": 4194304, "class": "imageUnpressed" },
    { "title": "Кафе", "url": "assets/cafe.png", "code": 8388608, "class": "imageUnpressed" },
    { "title": "Отель", "url": "assets/hotel.png", "code": 16777216, "class": "imageUnpressed" },
    { "title": "BelToll", "url": "assets/beltoll.png", "code": 33554432, "class": "imageUnpressed" },
    { "title": "СТО", "url": "assets/repair.png", "code": 67108864, "class": "imageUnpressed" },
    { "title": "Душ", "url": "assets/shower.png", "code": 134217728, "class": "imageUnpressed" }
  
];