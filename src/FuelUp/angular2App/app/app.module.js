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
var common_1 = require('@angular/common');
var forms_1 = require('@angular/forms');
var platform_browser_1 = require('@angular/platform-browser');
var app_component_1 = require('./app.component');
var app_constants_1 = require('./app.constants');
var app_routes_1 = require('./app.routes');
var http_1 = require('@angular/http');
var home_component_1 = require('./home/home.component');
var about_component_1 = require('./about/about.component');
var core_2 = require('angular2-google-maps/core');
var image_component_1 = require("./image.component");
var core_3 = require('angular2-google-maps/core');
var services_1 = require('angular2-google-maps/core/services');
var my_map_control_component_1 = require("./home/my-map-control.component");
var AppModule = (function () {
    function AppModule() {
    }
    AppModule = __decorate([
        core_1.NgModule({
            imports: [
                platform_browser_1.BrowserModule,
                common_1.CommonModule,
                forms_1.FormsModule,
                app_routes_1.routing,
                http_1.HttpModule,
                http_1.JsonpModule,
                core_2.AgmCoreModule.forRoot()
            ],
            declarations: [
                app_component_1.AppComponent,
                about_component_1.AboutComponent,
                home_component_1.HomeComponent,
                image_component_1.ImgComponent,
                my_map_control_component_1.MyMapControlComponent
            ],
            providers: [
                services_1.GoogleMapsAPIWrapper,
                app_constants_1.Configuration,
                { provide: core_3.MapsAPILoader, useClass: core_3.NoOpMapsAPILoader }
            ],
            bootstrap: [app_component_1.AppComponent]
        }), 
        __metadata('design:paramtypes', [])
    ], AppModule);
    return AppModule;
}());
exports.AppModule = AppModule;
//# sourceMappingURL=app.module.js.map