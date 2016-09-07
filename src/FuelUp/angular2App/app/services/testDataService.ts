import { Injectable } from '@angular/core';
import { Http, Response, Headers } from '@angular/http';
import 'rxjs/add/operator/map'
import { Observable } from 'rxjs/Observable';
import { Configuration } from '../app.constants';

@Injectable()
export class TestDataService {

    private getMainInfoUrl: string;
    private headers: Headers;
    private getServicesURL: string;

    constructor(private _http: Http, private _configuration: Configuration) {

        this.getMainInfoUrl = _configuration.Server + _configuration.URLgetMainInfo;
        this.getServicesURL = _configuration.Server + _configuration.URLgetServiceTypes;

        this.headers = new Headers();
        this.headers.append('Content-Type', 'application/json');
        this.headers.append('Accept', 'application/json');

      
    }

    public GetServices = (): Observable<any> => {
        var res = this._http.get(this.getServicesURL).map((response: Response) => <any>response.json());
        console.log(res);
        return res;
    }

    public GetMainInfo = (id: number): Observable<Response> => {
        return this._http.get(this.getMainInfoUrl).map(res => res.json());
    }

    //public Add = (itemName: string): Observable<Response> => {
    //    var toAdd = JSON.stringify({ ItemName: itemName });

    //    return this._http.post(this.getMainInfoUrl, toAdd, { headers: this.headers }).map(res => res.json());
    //}
}