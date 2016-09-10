import { Observable } from 'rxjs/Observable';
import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { TestDataService } from '../services/testDataService';
import {AgmCoreModule} from 'angular2-google-maps/core';
import {SebmGoogleMapMarker} from 'angular2-google-maps/core';
import Stationinterface = require("../http/station.interface");
import Httpservice = require("../http/http.service");
let styles = String(require('./home.component.scss'));


@Component({
    selector: 'homecomponent',
    template: require('./home.component.html'),
    styles: [styles],    

    providers: [TestDataService, Httpservice.HTTPService]
})

export class HomeComponent implements OnInit {

    public message: string;
    public values: any[];
    lat: number = 53.8840092;
    lng: number = 27.4548901;
    zoom: number = 8;
    allStations: Stationinterface.Station[];
    

    constructor(private _dataService: TestDataService, private _httpService: Httpservice.HTTPService) {
        this.message = "Hello from HomeComponent constructor";
    }

    ngOnInit() {
        //this._dataService
        //    .GetServices()
        //    .subscribe(data => this.values = data,
        //    error => console.log(error),
        //    () => console.log('Get all complete'));

        this._httpService.getAllStations()
            .subscribe(allStations => this.allStations = allStations);

       // console.info("allStation - " + this.allStations.length);

    }
}
