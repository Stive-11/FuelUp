"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var core_1 = require('@angular/core');
var styles = String(require('./image.component.scss'));
var ImgComponent = (function () {
    function ImgComponent() {
        this.images = IMAGES;
        this.currentServices = [];
    }
    ImgComponent.prototype.toggleImage = function (image) {
        if (image.class == "imageUnpressed") {
            image.class = "imagePressed";
            this.currentServices.push(image.id);
            console.info("MASSIVE:" + this.currentServices.length);
        }
        else {
            image.class = "imageUnpressed";
            var index = this.currentServices.indexOf(image.id);
            this.currentServices.splice(index, 1);
            console.info("MASSIVE:" + this.currentServices.length);
        }
    };
    ImgComponent = __decorate([
        core_1.Component({
            selector: 'filtres',
            template: " \n  <ul class=\"filters\"> \n    <li *ngFor=\"let image of images\">\n        <div data-title=\"{{image.title}}\" (click)=\"toggleImage(image)\" class=\"{{image.class}}\"> \n            <img src=\"{{image.url}}\"/>\n         </div>\n    </li>\n  </ul>\n  ",
            styles: ["require('./image.component.scss')"],
        }), 
        __metadata('design:paramtypes', [])
    ], ImgComponent);
    return ImgComponent;
}());
exports.ImgComponent = ImgComponent;
var IMAGES = [
    { "title": "Круглосуточное обслуживание", "url": "assets/24.png", "id": 1, "class": "imageUnpressed" },
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
//# sourceMappingURL=image.component.js.map