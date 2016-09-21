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
    function HomeComponent(_httpService) {
        this._httpService = _httpService;
        this.zoom = 8;
        this.lat = 53.8840092;
        this.lng = 27.4548901;
        this.mode = 'Observable';
    }
    ;
    HomeComponent.prototype.getStations = function () {
        var _this = this;
        this._httpService.getAllStations()
            .subscribe(function (allStations) { return _this.allStations = allStations; }, function (error) { return _this.errorMessage = error; });
    };
    ;
    HomeComponent.prototype.ngOnInit = function () {
        this.getStations();
        jQuery("#gMap").height("90vh");
    };
    HomeComponent = __decorate([
        core_1.Component({
            selector: 'homecomponent',
            template: "<ul>\n    <li>\n            hehsjhksjhfksjd\n    </li>\n     </ul>",
            styles: [styles],
            providers: [Httpservice.HTTPService]
        }), 
        __metadata('design:paramtypes', [Httpservice.HTTPService])
    ], HomeComponent);
    return HomeComponent;
}());
exports.HomeComponent = HomeComponent;
//# sourceMappingURL=home.component.js.map