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
var core_2 = require('angular2-google-maps/core');
var coordinates_interface_1 = require("../http/coordinates.interface");
var directionsDisplay;
var MyMapControlComponent = (function () {
    function MyMapControlComponent(wrapper) {
        this.wrapper = wrapper;
        this.start = new coordinates_interface_1.Coordinates();
        this.end = new coordinates_interface_1.Coordinates();
        this.distance = '';
        this.wrapper.getNativeMap().then(function (m) { });
    }
    MyMapControlComponent.prototype.buildRoute = function () {
        var directionsService = new google.maps.DirectionsService;
        directionsDisplay = new google.maps.DirectionsRenderer;
        var start = new google.maps.LatLng(this.start.latitude, this.start.longitude);
        var end = new google.maps.LatLng(this.end.latitude, this.end.longitude);
        this.wrapper.getNativeMap().then(function (map) { return directionsDisplay.setMap(map); });
        var bounds = new google.maps.LatLngBounds();
        bounds.extend(start);
        bounds.extend(end);
        this.wrapper.fitBounds(bounds);
        var request = {
            origin: start,
            destination: end,
            travelMode: google.maps.TravelMode.DRIVING
        };
        directionsService.route(request, function (response, status) {
            if (status == google.maps.DirectionsStatus.OK) {
                var info = document.getElementById('routeInfo');
                info.innerHTML = '';
                directionsDisplay.setDirections(response);
                var route = response.routes[0];
                info.innerHTML += route.legs[0].distance.text + '<br><br>';
                info.innerHTML += route.legs[0].duration.text;
            }
        });
    };
    MyMapControlComponent.prototype.clearRoute = function () {
        if (directionsDisplay != null) {
            directionsDisplay.setMap(null);
            directionsDisplay = null;
        }
    };
    __decorate([
        core_1.Input('stPoint'), 
        __metadata('design:type', coordinates_interface_1.Coordinates)
    ], MyMapControlComponent.prototype, "start", void 0);
    __decorate([
        core_1.Input('finPoint'), 
        __metadata('design:type', coordinates_interface_1.Coordinates)
    ], MyMapControlComponent.prototype, "end", void 0);
    MyMapControlComponent = __decorate([
        core_1.Component({
            selector: 'my-map-control',
            template: "",
        }), 
        __metadata('design:paramtypes', [core_2.GoogleMapsAPIWrapper])
    ], MyMapControlComponent);
    return MyMapControlComponent;
}());
exports.MyMapControlComponent = MyMapControlComponent;
//# sourceMappingURL=my-map-control.component.js.map