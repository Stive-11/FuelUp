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
var ImgComponent = (function () {
    function ImgComponent() {
        this.images = IMAGES;
    }
    ImgComponent = __decorate([
        core_1.Component({
            selector: 'filtres',
            template: "\n  <ul class=\"slides\">\n    <li *ngFor=\"let image of images\">\n      <h2>{{image.title}}</h2>\n      <img src=\"{{image.url}}\" alt=\"\">\n    </li>\n  </ul>\n  ",
            styles: [""],
        }), 
        __metadata('design:paramtypes', [])
    ], ImgComponent);
    return ImgComponent;
}());
exports.ImgComponent = ImgComponent;
var IMAGES = [
    { "title": "We are covered", "url": "./images/fabianGosebrink.jpg" },
    { "title": "Generation Gap", "url": "./images/damienbod.jpg" },
];
//# sourceMappingURL=image.component.js.map