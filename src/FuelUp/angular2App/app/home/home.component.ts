import { Observable } from 'rxjs/Observable';
import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';
//import { TestDataService } from '../services/testDataService';
import {AgmCoreModule} from 'angular2-google-maps/core';
import {SebmGoogleMapMarker} from 'angular2-google-maps/core';
import Httpservice = require("../http/http.service");
import Coordinatesinterface = require("../http/coordinates.interface");
let styles = String(require('./home.component.scss'));
import {Station} from '../http/station.interface';
declare var jQuery: any;


@Component({
    selector: 'homecomponent',
    //template: require('./home.component.html'),
    template:`<h1>my stations</h1>
                <ul>
                <li *ngFor="let station of stations">
                    {{station.name}}
                </li>
              </ul>
               <div class="error" *ngIf="errorMessage">{{errorMessage}}</div>
`,
    styles: [styles],    

    providers: [Httpservice.HTTPService]
})

export class HomeComponent implements OnInit {
    zoom: number = 8;
    public message: string;
    public errorMessage: string;
    //public values: any[];
    mode = 'Observable';
    stations: Station[];
    lat: number = 53.8840092;
    lng: number = 27.4548901;

    //lat1: number = 53.8940092;
    //lng1: number = 27.4648901;
    //cord1: Coordinatesinterface.Coordinates = {latitude: this.lat, longitude: this.lng};
    //cord2: Coordinatesinterface.Coordinates = { latitude: this.lat1, longitude: this.lng1 };
    //markers: Coordinatesinterface.Coordinates[] = [this.cord1, this.cord2];

   


    constructor(private _httpService: Httpservice.HTTPService) { };

    getStations() {
        console.info("this is getStations method start to work");
        this._httpService.getAllStations()
            .subscribe(
            stations => this.stations = stations,
            error => this.errorMessage = <any>error);
        console.info("this is getStations method end of work");
        console.info('Station:' + this.stations);
    };
  
    ngOnInit() {
        this.getStations();
        jQuery("#gMap").height("90vh");
    }
}
