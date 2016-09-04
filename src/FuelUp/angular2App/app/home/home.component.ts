import { Observable } from 'rxjs/Observable';
import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { TestDataService } from '../services/testDataService';
import {AgmCoreModule} from 'angular2-google-maps/core';

@Component({
    selector: 'homecomponent',
    template: `<sebm-google-map [latitude]="lat" [longitude]="lng" [zoom]="zoom">
   </sebm-google-map>`,
    styles: [`
   .sebm-google-map-container {
     height: 300px;
   }`],    

    providers: [TestDataService]
})

export class HomeComponent implements OnInit {

    public message: string;
    public values: any[];
    lat: number = 51.678418;
    lng: number = 7.809007;
    zoom: number = 5;

    constructor(private _dataService: TestDataService) {
        this.message = "Hello from HomeComponent constructor";
    }

    ngOnInit() {
        this._dataService
            .GetAll()
            .subscribe(data => this.values = data,
            error => console.log(error),
            () => console.log('Get all complete'));
    }
}
