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
    }
    ImgComponent = __decorate([
        core_1.Component({
            selector: 'filtres',
            template: "\n  <ul class=\"filters\">\n    <li *ngFor=\"let image of images\">\n      <img src=\"{{image.url}}\" alt=\"{{image.title}}\">\n    </li>\n  </ul>\n  ",
            styles: ["require('./image.component.scss')"]
        }), 
        __metadata('design:paramtypes', [])
    ], ImgComponent);
    return ImgComponent;
}());
exports.ImgComponent = ImgComponent;
var IMAGES = [
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
//# sourceMappingURL=image.component.js.map