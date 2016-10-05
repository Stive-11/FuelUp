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
var Subject_1 = require('rxjs/Subject');
var MapService = (function () {
    function MapService() {
        this.missionAnnouncedSource = new Subject_1.Subject();
        this.missionConfirmedSource = new Subject_1.Subject();
        this.missionAnnounced$ = this.missionAnnouncedSource.asObservable();
        this.missionConfirmed$ = this.missionConfirmedSource.asObservable();
    }
    MapService.prototype.announceMission = function (mission) {
        this.missionAnnouncedSource.next(mission);
    };
    MapService.prototype.confirmMission = function (astronaut) {
        this.missionConfirmedSource.next(astronaut);
    };
    MapService = __decorate([
        core_1.Injectable(), 
        __metadata('design:paramtypes', [])
    ], MapService);
    return MapService;
}());
exports.MapService = MapService;
//# sourceMappingURL=MapService.js.map