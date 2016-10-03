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
var Httpservice = require("../http/http.service");
var styles = String(require('./home.component.scss'));
var coordinates_interface_1 = require("../http/coordinates.interface");
var HomeComponent = (function () {
    function HomeComponent(_httpService, zone) {
        this._httpService = _httpService;
        this.zone = zone;
        this.button = "Поехали";
        this.zoom = 8;
        this.mode = 'Observable';
        this.lat = 53.8840092;
        this.lng = 27.4548901;
        this.stPoint = new coordinates_interface_1.Coordinates();
        this.finPoint = new coordinates_interface_1.Coordinates();
    }
    HomeComponent.prototype.getStations = function () {
        var _this = this;
        this._httpService.getAllStations()
            .subscribe(function (stations) { return _this.stations = stations; }, function (error) { return _this.errorMessage = error; });
    };
    ;
    HomeComponent.prototype.getPath = function (stPoint, finPoint) {
        var _this = this;
        if (!stPoint || !finPoint) {
            return;
        }
        this._httpService.getPath(this.stPoint, this.finPoint)
            .subscribe(function (error) { return _this.errorMessage = error; });
    };
    HomeComponent.prototype.getFiltered = function (servicesCode) {
        var _this = this;
        if (!servicesCode || servicesCode == 0) {
            return;
        }
        this._httpService.getFiltres(this.servicesCode)
            .subscribe(function (stations) { return _this.stations = stations; }, function (error) { return _this.errorMessage = error; });
    };
    HomeComponent.prototype.ngOnInit = function () {
        var _this = this;
        jQuery(".menu-opener").click(function () {
            jQuery(".menu-opener, .menu-opener-inner, .sidenav").toggleClass("active");
        });
        jQuery("#gMap").height("83vh");
        this.getStations();
        var autocompleteFrom;
        var autocompleteTo;
        var from = jQuery('#addressFrom')[0];
        var to = jQuery('#addressTo')[0];
        autocompleteFrom = new google.maps.places.Autocomplete(from, {});
        autocompleteTo = new google.maps.places.Autocomplete(to, {});
        google.maps.event.addListener(autocompleteFrom, 'place_changed', function () {
            _this.zone.run(function () {
                var place = autocompleteFrom.getPlace();
                _this.stPoint.latitude = place.geometry.location.lat();
                _this.stPoint.longitude = place.geometry.location.lng();
            });
        });
        google.maps.event.addListener(autocompleteTo, 'place_changed', function () {
            _this.zone.run(function () {
                var place = autocompleteTo.getPlace();
                _this.finPoint.latitude = place.geometry.location.lat();
                _this.finPoint.longitude = place.geometry.location.lng();
            });
        });
    };
    HomeComponent.prototype.onClick = function (event) {
        this.getPath(this.stPoint, this.finPoint);
    };
    HomeComponent.prototype.onNotify = function (code) {
        this.servicesCode = code;
        this.getFiltered(this.servicesCode);
    };
    HomeComponent = __decorate([
        core_1.Component({
            selector: 'homecomponent',
            template: require('./home.component.html'),
            styles: [styles],
            providers: [Httpservice.HTTPService],
        }), 
        __metadata('design:paramtypes', [Httpservice.HTTPService, core_1.NgZone])
    ], HomeComponent);
    return HomeComponent;
}());
exports.HomeComponent = HomeComponent;
//# sourceMappingURL=home.component.js.map