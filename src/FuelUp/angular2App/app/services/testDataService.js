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
var http_1 = require('@angular/http');
require('rxjs/add/operator/map');
var app_constants_1 = require('../app.constants');
var TestDataService = (function () {
    function TestDataService(_http, _configuration) {
        var _this = this;
        this._http = _http;
        this._configuration = _configuration;
        this.GetServices = function () {
            var res = _this._http.get(_this.getServicesURL)
                .map(function (res) { return res.json(); });
            console.info(res + " ");
            console.info(JSON.stringify(res));
            return res;
        };
        this.GetMainInfo = function (id) {
            return _this._http.get(_this.getMainInfoUrl).map(function (res) { return res.json(); });
        };
        this.getMainInfoUrl = _configuration.Server + _configuration.URLgetMainInfo;
        this.getServicesURL = _configuration.Server + _configuration.URLgetServiceTypes;
        this.headers = new http_1.Headers();
        this.headers.append('Content-Type', 'application/json');
        this.headers.append('Accept', 'application/json');
    }
    TestDataService = __decorate([
        core_1.Injectable(), 
        __metadata('design:paramtypes', [http_1.Http, app_constants_1.Configuration])
    ], TestDataService);
    return TestDataService;
}());
exports.TestDataService = TestDataService;
//# sourceMappingURL=testDataService.js.map