import { Observable } from 'rxjs/Observable';
import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import {AgmCoreModule} from 'angular2-google-maps/core';
import {SebmGoogleMapMarker, SebmGoogleMapInfoWindow, GoogleMapsAPIWrapper} from 'angular2-google-maps/core';
import Httpservice = require("../http/http.service");
let styles = String(require('./home.component.scss'));
import {Station} from '../http/station.interface';
declare var jQuery: any;


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
    mode = 'Observable';
    stations: Station[];
    //coordinates: Coordinates[];
    lat: number = 53.8840092;
    lng: number = 27.4548901;

    constructor(private _httpService: Httpservice.HTTPService) { }
    
    getStations() {
        this._httpService.getAllStations()
            .subscribe(
            stations => this.stations = stations,
            error => this.errorMessage = <any>error);
    };
  
    ngOnInit() {
        this.getStations();
        jQuery("#gMap").height("90vh");
    }
}
