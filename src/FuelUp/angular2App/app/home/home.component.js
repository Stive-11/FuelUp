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
var my_map_control_component_1 = require("./my-map-control.component");
var image_component_1 = require("../image.component");
var core_2 = require('@angular/core');
var HomeComponent = (function () {
    function HomeComponent(_httpService, zone) {
        this._httpService = _httpService;
        this.zone = zone;
        this.stPoint = new coordinates_interface_1.Coordinates();
        this.finPoint = new coordinates_interface_1.Coordinates();
        this.zoom = 8;
        this.count = 0;
        this.servicesCode = 0;
        this.hard = false;
        this.mode = 'Observable';
        this.services = [];
        this.lat = 53.8840092;
        this.lng = 27.4548901;
    }
    HomeComponent.prototype.getStations = function () {
        var _this = this;
        this._httpService.getAllStations()
            .subscribe(function (stations) { return _this.stations = stations; }, function (error) { return _this.errorMessage = error; });
    };
    ;
    HomeComponent.prototype.getPath = function (stPoint, finPoint, servicesCode) {
        var _this = this;
        if (!stPoint || !finPoint) {
            return;
        }
        this._httpService.getPath(this.stPoint, this.finPoint, this.servicesCode)
            .subscribe(function (stations) { return _this.stations = stations; }, function (error) { return _this.errorMessage = error; });
    };
    HomeComponent.prototype.getHardFiltered = function (servicesCode) {
        var _this = this;
        if (servicesCode == 0) {
            this.getStations();
        }
        this._httpService.getHardFiltres(this.servicesCode)
            .subscribe(function (stations) { return _this.stations = stations; }, function (error) { return _this.errorMessage = error; });
    };
    HomeComponent.prototype.getSoftFiltered = function (servicesCode) {
        var _this = this;
        if (servicesCode == 0) {
            this.getStations();
        }
        this._httpService.getSoftFiltres(this.servicesCode)
            .subscribe(function (stations) { return _this.stations = stations; }, function (error) { return _this.errorMessage = error; });
    };
    HomeComponent.prototype.ngOnInit = function () {
        var _this = this;
        jQuery(".menu-opener").click(function () {
            jQuery(".menu-opener, .menu-opener-inner, .sidenav, .form-move, .way").toggleClass("active");
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
        var _this = this;
        this.controlComponent.clearRoute();
        this.controlComponent.buildRoute();
        this.getPath(this.stPoint, this.finPoint, this.servicesCode);
        setTimeout(function () {
            _this.count = _this.stations.length;
        }, 2500);
        jQuery(".route-info").addClass("visible");
    };
    HomeComponent.prototype.onNotify = function (code) {
        this.servicesCode = code;
    };
    HomeComponent.prototype.onNotify2 = function (hard) {
        this.hard = hard;
        if (this.hard) {
            this.getHardFiltered(this.servicesCode);
        }
        else
            this.getSoftFiltered(this.servicesCode);
    };
    HomeComponent.prototype.mapClicked = function ($event) {
    };
    HomeComponent.prototype.putServicesOnPin = function () {
        for (var _i = 0, _a = this.stations; _i < _a.length; _i++) {
            var station = _a[_i];
            for (var _b = 0, _c = this.imgComponent.images; _b < _c.length; _b++) {
                var image = _c[_b];
                var result = image.code & station.codServices;
                if (result != 0) {
                    while (this.services.length < 15) {
                        this.services.push(station.name);
                    }
                    console.info(this.services);
                }
            }
        }
    };
    __decorate([
        core_2.ViewChild(image_component_1.ImgComponent), 
        __metadata('design:type', image_component_1.ImgComponent)
    ], HomeComponent.prototype, "imgComponent", void 0);
    __decorate([
        core_2.ViewChild(my_map_control_component_1.MyMapControlComponent), 
        __metadata('design:type', my_map_control_component_1.MyMapControlComponent)
    ], HomeComponent.prototype, "controlComponent", void 0);
    HomeComponent = __decorate([
        core_1.Component({
            selector: 'homecomponent',
            template: require('./home.component.html'),
            styles: [styles],
            providers: [Httpservice.HTTPService]
        }), 
        __metadata('design:paramtypes', [Httpservice.HTTPService, core_1.NgZone])
    ], HomeComponent);
    return HomeComponent;
}());
exports.HomeComponent = HomeComponent;
//# sourceMappingURL=home.component.js.map