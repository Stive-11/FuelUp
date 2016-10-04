import { Observable } from 'rxjs/Observable';
import { Component, OnInit, NgZone } from '@angular/core';
import { Http, Headers, RequestOptions } from '@angular/http';
import { AgmCoreModule } from 'angular2-google-maps/core';
import {SebmGoogleMapMarker, SebmGoogleMapInfoWindow, GoogleMapsAPIWrapper} from 'angular2-google-maps/core';
import { MapsAPILoader, NoOpMapsAPILoader} from 'angular2-google-maps/core';
import Httpservice = require("../http/http.service");
let styles = String(require('./home.component.scss'));
import {Station} from '../http/station.interface';
import {PathPoints} from '../http/pathpoints.interface';
import {Coordinates} from "../http/coordinates.interface";
import {MyMapControlComponent} from "./my-map-control.component";
declare var jQuery: any;
declare var google: any;


@Component({
    selector: 'homecomponent',
    template: require('./home.component.html'),
    styles: [styles],    
    providers: [Httpservice.HTTPService]
})

export class HomeComponent implements OnInit {
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
        var directionsService = new google.maps.DirectionsService;
        var directionsDisplay = new google.maps.DirectionsRenderer;
        //var map = jQuery('#gMap');
        //directionsDisplay.setMap(map);
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
                //calculateAndDisplayRoute(directionsService, directionsDisplay);
            });
        });
       
        //function calculateAndDisplayRoute(directionsService, directionsDisplay) {
        //    directionsService.route({
        //        origin: document.getElementById('start').value,
        //        destination: document.getElementById('end').value,
        //        travelMode: google.maps.TravelMode.DRIVING
        //    }, function (response, status) {
        //        if (status === google.maps.DirectionsStatus.OK) {
        //            directionsDisplay.setDirections(response);
        //        } else {
        //            window.alert('Directions request failed due to ' + status);
        //        }
        //    });
        //}
    }
    onClick(event) {
        this.getPath(this.stPoint, this.finPoint);
        
    }
    onNotify(code: number): void {
        this.servicesCode = code;
        this.getFiltered(this.servicesCode);
    }
}
