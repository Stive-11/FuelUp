import { Injectable } from '@angular/core';

@Injectable()
export class Configuration {
    //public Server: string = "http://193.124.57.9:2000";
    public Server: string = "http://localhost:5000";
    public URLgetMainInfo: string = "/api/GetMainInfo";
    public URLgetServiceTypes: string = "/api/GetServiceTypes";
}