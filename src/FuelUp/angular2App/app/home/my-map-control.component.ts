import {Component, OnInit, Input} from '@angular/core';
import { GoogleMapsAPIWrapper } from 'angular2-google-maps/core';
import {Coordinates} from "../http/coordinates.interface";
//import {GoogleMap} from 'angular2-google-maps/core';
declare var google: any;
let directionsDisplay: any;


@Component({
    selector: 'my-map-control',
    template: ``,
})
export class MyMapControlComponent implements OnInit {  
    @Input('stPoint') start: Coordinates = new Coordinates();
    @Input('finPoint') end: Coordinates = new Coordinates();
    time: string;
    distance: string = '';
    map: any;
    constructor(private wrapper: GoogleMapsAPIWrapper) {
        this.wrapper.getNativeMap().then((m) => {
        this.map = m;
        //let pos = new google.maps.LatLng(52.100512, 23.680022);
        //let marker = new google.maps.Marker({
        //    position: pos,
        //    map: this.map,
        //    title: 'Hello World!'
        //});
        });
    }

    ngOnInit() {
       
    }
    buildRoute() {
        var directionsService = new google.maps.DirectionsService;
        directionsDisplay = new google.maps.DirectionsRenderer;
        var start = new google.maps.LatLng(this.start.latitude, this.start.longitude);
        var end = new google.maps.LatLng(this.end.latitude, this.end.longitude);
        this.wrapper.getNativeMap().then(map => directionsDisplay.setMap(map));
        var bounds = new google.maps.LatLngBounds();
        bounds.extend(start);
        bounds.extend(end);
        this.wrapper.fitBounds(bounds);
        var request = {
            origin: start,
            destination: end,
            travelMode: google.maps.TravelMode.DRIVING
        };
        directionsService.route(request, function (response, status) {
            if (status == google.maps.DirectionsStatus.OK) {
                var info = document.getElementById('routeInfo');
                info.innerHTML = '';
                directionsDisplay.setDirections(response);
                var route = response.routes[0];
                info.innerHTML += '<p><strong>Информация о маршруте</strong></p>';
                info.innerHTML += '<p>Расстояние: '+route.legs[0].distance.text + '</p>';
                info.innerHTML += '<p>Время в пути: ' + route.legs[0].duration.text +'</p>';
            }
        });
    }
    clearRoute() {
        if (directionsDisplay != null) {
            directionsDisplay.setMap(null);
            directionsDisplay = null;
        }
    }
}
   
