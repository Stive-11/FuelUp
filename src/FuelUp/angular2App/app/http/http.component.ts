import {Component} from '@angular/core';
import {HTTPService} from "./http.service";
import {Coordinates} from './coordinates.interface';
import {Station} from './station.interface';
import { OnInit } from '@angular/core';


@Component({
    selector: 'http-test',
    template: `
        <button (click)="onTestGet()">Test GET</button>
        <p>Output: {{getData}}</p>
        <button (click)="onTestPost()">Test POST</button>
        <p>Output: {{postData}}</p>    
    `,
    providers: [HTTPService]
})

export class HTTPComponent implements OnInit {
    getData: string;
    postData: string;

    errorMessage: string;

    constructor(private _httpService: HTTPService) { }
    ngOnInit() {
        console.log('onInit');
        this._httpService.getAllStations();

        //.subscribe(data => this.getData = JSON.stringify(data), error => alert(error), () => console.log('finished'));

    }
    onTestPost() {
        this._httpService.postJSON()
            .subscribe(data => this.postData = JSON.stringify(data), error => alert(error), () => console.log('finished'));
    }

}