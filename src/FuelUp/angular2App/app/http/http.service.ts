import {Injectable} from "@angular/core";
import {Http, Headers, Response, RequestOptions } from "@angular/http";
import 'rxjs/add/operator/map';
import { Configuration } from '../app.constants';
import {Coordinates} from './coordinates.interface';
import {Station} from './station.interface';
import { Observable }     from 'rxjs/Observable';
import {PathPoints} from './pathpoints.interface';

@Injectable()
export class HTTPService {
    private getAllStationsURL: string;
    private getPathsURL: string;

    constructor(private _http: Http, private _configuration: Configuration) {
        this.getAllStationsURL = _configuration.Server + _configuration.URLgetMainInfo;
        this.getPathsURL = _configuration.Server + _configuration.URLgetPath;
    }
   
    getAllStations(): Observable<Station[]> {
        return this._http.get(this.getAllStationsURL)
            .map(this.extractData)
            .catch(this.handleError);

    }
    private extractData(res: Response) {
        let body = res.json();
        console.info(body);
        return body || {};
    }
    private handleError(error: any) {
       
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
    getPath(stPoint: Coordinates, finPoint: Coordinates): Observable<Coordinates[]> {
        var str1 = JSON.stringify(stPoint);
        var str2 = JSON.stringify(finPoint);
        let body = '{"startPoint":' + str1 + ',"finishPoint":' + str2 + '}';
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });

        return this._http.post(this.getPathsURL, body, options)
            .map(this.extractData)
            .catch(this.handleError);
    }
}