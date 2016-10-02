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
var Httpservice = require("./http/http.service");
var styles = String(require('./image.component.scss'));
var ImgComponent = (function () {
    function ImgComponent(_httpService) {
        this._httpService = _httpService;
        this.apply = "Применить фильтры";
        this.images = IMAGES;
        this.servicesCode = 0;
    }
    ImgComponent.prototype.toggleImage = function (image) {
        jQuery(image).toggleClass("imagePressed");
        if (image.class == "imageUnpressed") {
            image.class = "imagePressed";
            this.servicesCode += image.code;
            console.info("Code: " + this.servicesCode);
        }
        else {
            image.class = "imageUnpressed";
            this.servicesCode -= image.code;
            console.info("Code: " + this.servicesCode);
        }
    };
    ImgComponent.prototype.getFiltered = function (servicesCode) {
        var _this = this;
        if (!servicesCode || servicesCode == 0) {
            return;
        }
        this._httpService.getFiltres(this.servicesCode)
            .subscribe(function (error) { return _this.errorMessage = error; });
    };
    ImgComponent.prototype.onClick = function (event) {
        this.getFiltered(this.servicesCode);
    };
    ImgComponent = __decorate([
        core_1.Component({
            selector: 'filtres',
            template: " \n     <button type=\"button\" (click)=\"onClick($event)\" class=\"btn btn-success apply\">{{apply}}</button>\n  <ul class=\"filters\"> \n    <li *ngFor=\"let image of images\">\n        <div data-title=\"{{image.title}}\" (click)=\"toggleImage(image)\" class=\"{{image.class}}\"> \n            <img src=\"{{image.url}}\"/>\n         </div>\n    </li>\n  </ul>\n   \n  ",
            styles: ["require('./image.component.scss')"],
            providers: [Httpservice.HTTPService]
        }), 
        __metadata('design:paramtypes', [Httpservice.HTTPService])
    ], ImgComponent);
    return ImgComponent;
}());
exports.ImgComponent = ImgComponent;
var IMAGES = [
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
//# sourceMappingURL=image.component.js.map