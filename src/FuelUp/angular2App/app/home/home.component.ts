import { Observable } from 'rxjs/Observable';
import { Component, OnInit, NgZone, Input, Output, EventEmitter } from '@angular/core';
import { Http, Headers, RequestOptions } from '@angular/http';
import { AgmCoreModule } from 'angular2-google-maps/core';
import {SebmGoogleMapMarker, SebmGoogleMapInfoWindow, GoogleMapsAPIWrapper} from 'angular2-google-maps/core';
import { MapsAPILoader, NoOpMapsAPILoader} from 'angular2-google-maps/core';
import Httpservice = require("../http/http.service");
let styles = String(require('./home.component.scss'));
import {Station} from '../http/station.interface';
import {Coordinates} from "../http/coordinates.interface";
import {MyMapControlComponent} from "./my-map-control.component";
import { AfterViewInit, ViewChild } from '@angular/core';
declare var jQuery: any;
declare var google: any;


@Component({
    selector: 'homecomponent',
    template: require('./home.component.html'),
    styles: [styles],    
    providers: [Httpservice.HTTPService]
})

export class HomeComponent implements OnInit  {
    stPoint: Coordinates = new Coordinates();
    finPoint: Coordinates = new Coordinates();
    zoom: number = 8;
    public message: string;
    public errorMessage: string;
    public servicesCode: number = 0;
    mode = 'Observable';
    stations: Station[];
    lat: number = 53.8840092;
    lng: number = 27.4548901;
    @Output() notify = new EventEmitter<Coordinates>();
    @ViewChild(MyMapControlComponent)
    private controlComponent: MyMapControlComponent;
    constructor(private _httpService: Httpservice.HTTPService, private zone: NgZone) { }
 
    getStations() {
        this._httpService.getAllStations()
            .subscribe(
            stations => this.stations = stations,
            error => this.errorMessage = <any>error);
    };

    getPath(stPoint, finPoint, servicesCode) {
        if (!stPoint || !finPoint) { return; }
        this._httpService.getPath(this.stPoint, this.finPoint, this.servicesCode)
            .subscribe(
            stations => this.stations = stations,
            error => this.errorMessage = <any>error);
    }
    getFiltered(servicesCode) {
        if (servicesCode == 0) {
            this.getStations(); 
        } 
        this._httpService.getFiltres(this.servicesCode)
            .subscribe(
            stations => this.stations = stations,
            error => this.errorMessage = <any>error);
    }
  
    ngOnInit() {
        jQuery(".menu-opener").click(function () {
            jQuery(".menu-opener, .menu-opener-inner, .sidenav, .way").toggleClass("active");
        });
        jQuery("#gMap").height("83vh");
        this.getStations(); 
        var autocompleteFrom: any;
        var autocompleteTo: any;
        var from = jQuery('#addressFrom')[0];
        var to = jQuery('#addressTo')[0];
        autocompleteFrom = new google.maps.places.Autocomplete(from, {});
        autocompleteTo = new google.maps.places.Autocomplete(to, {});
        google.maps.event.addListener(autocompleteFrom, 'place_changed', () => {
            this.zone.run(() => {
                var place = autocompleteFrom.getPlace();
                this.stPoint.latitude = place.geometry.location.lat();
                this.stPoint.longitude = place.geometry.location.lng();
            });
        });
        google.maps.event.addListener(autocompleteTo, 'place_changed', () => {
            this.zone.run(() => {
                var place = autocompleteTo.getPlace();           
                this.finPoint.latitude = place.geometry.location.lat();
                this.finPoint.longitude = place.geometry.location.lng();
            });
        });
    }
    onClick(event) {
        jQuery(".route-info").addClass("visible");
        this.controlComponent.clearRoute();
        this.controlComponent.buildRoute();
        this.getPath(this.stPoint, this.finPoint, this.servicesCode);
    }
    onNotify(code: number): void {
        this.servicesCode = code;
        this.getFiltered(this.servicesCode);
    }
    mapClicked($event: MouseEvent) {
        
    }
}
