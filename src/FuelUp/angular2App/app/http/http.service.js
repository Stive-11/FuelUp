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
var core_1 = require("@angular/core");
var http_1 = require("@angular/http");
require('rxjs/add/operator/map');
var app_constants_1 = require('../app.constants');
var HTTPService = (function () {
    function HTTPService(_http, _configuration) {
        this._http = _http;
        this._configuration = _configuration;
        this.getAllStationsURL = _configuration.Server + _configuration.URLgetMainInfo;
    }
    HTTPService.prototype.getCurrentTime = function () {
        return this._http.get('http://localhost:5000/api/GetServiceTypes')
            .map(function (res) { return res.json(); });
    };
    HTTPService.prototype.getAllStations = function () {
        return this._http.get(this.getAllStationsURL)
            .map(function (res) { return res.json().data; });
    };
    HTTPService.prototype.postJSON = function () {
        var json = JSON.stringify({ val1: 'test', var2: 2 });
        var params = 'json=' + json;
        var headers = new http_1.Headers();
        headers.append('Content-Type', 'application/x-www-form-urlencoded');
        return this._http.post('http://validate.jsontest.com', params, { headers: headers })
            .map(function (res) { return res.json(); });
    };
    HTTPService = __decorate([
        core_1.Injectable(), 
        __metadata('design:paramtypes', [http_1.Http, app_constants_1.Configuration])
    ], HTTPService);
    return HTTPService;
}());
exports.HTTPService = HTTPService;
//# sourceMappingURL=http.service.js.map