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
    private getFiltersURL: string;
    private getFiltersForRouteURL: string;
    constructor(private _http: Http, private _configuration: Configuration) {
        this.getAllStationsURL = _configuration.Server + _configuration.URLgetMainInfo;
        this.getPathsURL = _configuration.Server + _configuration.URLgetPath;
        this.getFiltersURL = _configuration.Server + _configuration.URLgetFiltered;
        this.getFiltersForRouteURL = _configuration.Server + _configuration.URLgetFiltersForRoute;

    }
   
    getAllStations(): Observable<Station[]> {
        return this._http.get(this.getAllStationsURL)
            .map(this.extractData)
            .catch(this.handleError);

    }
    private extractData(res: Response) {
        let body = res.json();
        //console.info(body);
        return body || {};
    }
    private handleError(error: any) {
       
        let errMsg = (error.message) ? error.message :
            error.status ? `${error.status} - ${error.statusText}` : 'Server error';
        console.error(errMsg); // log to console
        return Observable.throw(errMsg);
    }

    getPath(stPoint: Coordinates, finPoint: Coordinates, filters: number): Observable<Station[]> {
        var str1 = JSON.stringify(stPoint);
        var str2 = JSON.stringify(finPoint);

        let body = '{"startPoint":' + str1 + ',"finishPoint":' + str2 + ',"filters":' + filters + '}';
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });

        return this._http.post(this.getFiltersForRouteURL, body, options)
            .map(this.extractData)
            .catch(this.handleError);
    }
    getFiltres(filters: number): Observable<Station[]> {
        let body = JSON.stringify({ filters });    
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });

        return this._http.post(this.getFiltersURL, body, options)
            .map(this.extractData)
            .catch(this.handleError);
    }
    //getFiltersForRoute(filters: number): Observable<Station[]> {
    //    let body = JSON.stringify({ filters });
    //    let headers = new Headers({ 'Content-Type': 'application/json' });
    //    let options = new RequestOptions({ headers: headers });

    //    return this._http.post(this.getFiltersURL, body, options)
    //        .map(this.extractData)
    //        .catch(this.handleError);
    //}
}