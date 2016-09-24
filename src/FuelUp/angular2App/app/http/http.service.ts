import {Injectable} from "@angular/core";
import {Http, Headers, Response } from "@angular/http";
import 'rxjs/add/operator/map';
import { Configuration } from '../app.constants';
import {Coordinates} from './coordinates.interface';
import {Station} from './station.interface';
import { Observable }     from 'rxjs/Observable';

@Injectable()
export class HTTPService {
    private getAllStationsURL: string;

    constructor(private _http: Http, private _configuration: Configuration) {
        this.getAllStationsURL = _configuration.Server + _configuration.URLgetMainInfo;
    }
    //getCurrentTime() {
    //    return this._http.get('http://localhost:5000/api/GetServiceTypes')
    //        .map(res => res.json());

    //}
    //getAllStations() {
    //    return this._http.get(this.getAllStationsURL)
    //        .map(res => <Station[]>res.json().data);
    //}
    getAllStations(): Observable<Station[]> {
        return this._http.get(this.getAllStationsURL)
            .map(this.extractData)
            .catch(this.handleError);

    }
    private extractData(res: Response) {
        let body = res.json();
        return body || {};
    }
    private handleError(error: any) {
        // In a real world app, we might use a remote logging infrastructure
        // We'd also dig deeper into the error to get a better message
        let errMsg = (error.message) ? error.message :
            error.status ? `${error.status} - ${error.statusText}` : 'Server error';
        console.error(errMsg); // log to console instead
        return Observable.throw(errMsg);
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