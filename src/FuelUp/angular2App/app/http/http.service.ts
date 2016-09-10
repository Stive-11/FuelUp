import {Injectable} from "@angular/core";
import {Http, Headers} from "@angular/http";
import 'rxjs/add/operator/map';
import { Configuration } from '../app.constants';
import {Coordinates} from './coordinates.interface';
import {Station} from './station.interface';

@Injectable()
export class HTTPService {
    private getAllStationsURL: string;

    constructor(private _http: Http, private _configuration: Configuration) {
        this.getAllStationsURL = _configuration.Server + _configuration.URLgetMainInfo;
    };
    getCurrentTime() {
        return this._http.get('http://localhost:13929/api/GetServiceTypes')
            .map(res => res.json());

    }
    getAllStations() {
        return this._http.get(this.getAllStationsURL)
            .map(res => <Station[]>res.json().data)
    }
    postJSON() {
        var json = JSON.stringify({ val1: 'test', var2: 2 });
        var params = 'json=' + json;
        var headers = new Headers();
        headers.append('Content-Type', 'application/x-www-form-urlencoded');
        return this._http.post('http://validate.jsontest.com', params, { headers: headers })
            .map(res => res.json());
    }
}