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
var HomeComponent = (function () {
    function HomeComponent(_httpService, zone) {
        this._httpService = _httpService;
        this.zone = zone;
        this.zoom = 8;
        this.mode = 'Observable';
        this.lat = 53.8840092;
        this.lng = 27.4548901;
    }
    HomeComponent.prototype.getStations = function () {
        var _this = this;
        this._httpService.getAllStations()
            .subscribe(function (stations) { return _this.stations = stations; }, function (error) { return _this.errorMessage = error; });
    };
    ;
    HomeComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.getStations();
        jQuery("#gMap").height("85vh");
        var autocompleteFrom;
        var autocompleteTo;
        var from = jQuery('#addressFrom')[0];
        var to = document.getElementById("addressTo");
        autocompleteFrom = new google.maps.places.Autocomplete(from, {});
        autocompleteTo = new google.maps.places.Autocomplete(to, {});
        google.maps.event.addListener(autocompleteFrom, 'place_changed', function () {
            _this.zone.run(function () {
                var place = autocompleteFrom.getPlace();
                console.log(place);
            });
        });
        google.maps.event.addListener(autocompleteTo, 'place_changed', function () {
            _this.zone.run(function () {
                var place = autocompleteTo.getPlace();
                console.log(place);
            });
        });
    };
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