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
var Observable_1 = require('rxjs/Observable');
var HTTPService = (function () {
    function HTTPService(_http, _configuration) {
        this._http = _http;
        this._configuration = _configuration;
        this.getAllStationsURL = _configuration.Server + _configuration.URLgetMainInfo;
        this.getPathsURL = _configuration.Server + _configuration.URLgetPath;
        this.getFiltersURL = _configuration.Server + _configuration.URLgetFiltered;
    }
    HTTPService.prototype.getAllStations = function () {
        return this._http.get(this.getAllStationsURL)
            .map(this.extractData)
            .catch(this.handleError);
    };
    HTTPService.prototype.extractData = function (res) {
        var body = res.json();
        return body || {};
    };
    HTTPService.prototype.handleError = function (error) {
        var errMsg = (error.message) ? error.message :
            error.status ? error.status + " - " + error.statusText : 'Server error';
        console.error(errMsg);
        return Observable_1.Observable.throw(errMsg);
    };
    HTTPService.prototype.getPath = function (stPoint, finPoint) {
        var str1 = JSON.stringify(stPoint);
        var str2 = JSON.stringify(finPoint);
        var body = '{"startPoint":' + str1 + ',"finishPoint":' + str2 + '}';
        var headers = new http_1.Headers({ 'Content-Type': 'application/json' });
        var options = new http_1.RequestOptions({ headers: headers });
        return this._http.post(this.getPathsURL, body, options)
            .map(this.extractData)
            .catch(this.handleError);
    };
    HTTPService.prototype.getFiltres = function (filters) {
        var body = JSON.stringify({ filters: filters });
        var headers = new http_1.Headers({ 'Content-Type': 'application/json' });
        var options = new http_1.RequestOptions({ headers: headers });
        return this._http.post(this.getFiltersURL, body, options)
            .map(this.extractData)
            .catch(this.handleError);
    };
    HTTPService = __decorate([
        core_1.Injectable(), 
        __metadata('design:paramtypes', [http_1.Http, app_constants_1.Configuration])
    ], HTTPService);
    return HTTPService;
}());
exports.HTTPService = HTTPService;
//# sourceMappingURL=http.service.js.map