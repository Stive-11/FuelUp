import { Observable } from 'rxjs/Observable';
import { Component, OnInit, NgZone } from '@angular/core';
import { Http, Headers, RequestOptions } from '@angular/http';
import {AgmCoreModule} from 'angular2-google-maps/core';
import {SebmGoogleMapMarker, SebmGoogleMapInfoWindow, GoogleMapsAPIWrapper} from 'angular2-google-maps/core';
import { MapsAPILoader, NoOpMapsAPILoader} from 'angular2-google-maps/core';
import Httpservice = require("../http/http.service");
let styles = String(require('./home.component.scss'));
import {Station} from '../http/station.interface';
import {PathPoints} from '../http/pathpoints.interface';
import {Coordinates} from "../http/coordinates.interface";
//import {ImgComponent} from '../image.component';
declare var jQuery: any;
declare var google: any;


@Component({
    selector: 'homecomponent',
    template: require('./home.component.html'),
    styles: [styles],    
    providers: [Httpservice.HTTPService],
    //directives: [ImgComponent]
})

export class HomeComponent implements OnInit {
    button: string = "Поехали";
    zoom: number = 8;
    public message: string;
    public errorMessage: string;
    public servicesCode: number;
    test: number;
    mode = 'Observable';
    stations: Station[];
    lat: number = 53.8840092;
    lng: number = 27.4548901;
    private stPoint: Coordinates = new Coordinates();
    private finPoint: Coordinates = new Coordinates();
    constructor(private _httpService: Httpservice.HTTPService, private zone: NgZone) { }
    
    getStations() {
        this._httpService.getAllStations()
            .subscribe(
            stations => this.stations = stations,
            error => this.errorMessage = <any>error);
    };
    getPath(stPoint, finPoint) {
        if (!stPoint || !finPoint) { return; }
        this._httpService.getPath(this.stPoint, this.finPoint)
            .subscribe(
            error => this.errorMessage = <any>error);
    }
    getFiltered(servicesCode) {
        if (!servicesCode || servicesCode == 0) { return; }
        this._httpService.getFiltres(this.servicesCode)
            .subscribe(
            stations => this.stations = stations,
            error => this.errorMessage = <any>error);
    }
  
    ngOnInit() {
        jQuery(".menu-opener").click(function () {
            jQuery(".menu-opener, .menu-opener-inner, .sidenav").toggleClass("active");
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
        this.getPath(this.stPoint, this.finPoint);
        //this.test = this.imgComponent.servicesCode;
        //console.info("test: " + this.test);
    }
    onNotify(code: number): void {
        this.servicesCode = code;
        this.getFiltered(this.servicesCode);
    }
}
