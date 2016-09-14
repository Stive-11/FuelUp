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
var testDataService_1 = require('../services/testDataService');
var Httpservice = require("../http/http.service");
var styles = String(require('./home.component.scss'));
var HomeComponent = (function () {
    function HomeComponent(_httpService) {
        this._httpService = _httpService;
        this.lat = 53.8840092;
        this.lng = 27.4548901;
        this.lat1 = 53.8940092;
        this.lng1 = 27.4648901;
        this.cord1 = { latitude: this.lat, longitude: this.lng };
        this.cord2 = { latitude: this.lat1, longitude: this.lng1 };
        this.markers = [this.cord1, this.cord2];
        this.zoom = 8;
        this.message = "Hello from HomeComponent constructor";
    }
    HomeComponent.prototype.ngOnInit = function () {
        var _this = this;
        this._httpService.getAllStations()
            .subscribe(function (allStations) { return _this.allStations = allStations; });
        document.getElementById("gMap").style.height = "90vh";
    };
    HomeComponent = __decorate([
        core_1.Component({
            selector: 'homecomponent',
            template: require('./home.component.html'),
            styles: [styles],
            providers: [testDataService_1.TestDataService, Httpservice.HTTPService]
        }), 
        __metadata('design:paramtypes', [Httpservice.HTTPService])
    ], HomeComponent);
    return HomeComponent;
}());
exports.HomeComponent = HomeComponent;
//# sourceMappingURL=home.component.js.map