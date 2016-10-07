import { Injectable } from '@angular/core';

@Injectable()
export class Configuration {
    //public Server: string = "http://193.124.57.9:2000";
    //public Server: string = "http://localhost:13929";
    public Server: string = window.location.protocol + "//" + window.location.host;
    public URLgetMainInfo: string = "/api/GetMainInfo";
    public URLgetServiceTypes: string = "/api/GetServiceTypes";
    public URLgetPath: string = "/api/Pathes/coordinatsPath";
    //public URLgetFiltered: string = "/api/getAllStationsWithFilter";
    public URLgetFiltered: string = "/api/getFiltredStations";
    public URLgetFiltersForRoute: string = "/api/Stations/coordinatsPathWithFilters";
}