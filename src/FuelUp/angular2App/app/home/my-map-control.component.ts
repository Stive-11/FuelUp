import {Component, OnInit} from '@angular/core';
import { GoogleMapsAPIWrapper } from 'angular2-google-maps/core';
declare var google: any;

@Component({
    selector: 'my-map-control',
    template: ''
})
export class MyMapControlComponent {
    constructor(private wrapper: GoogleMapsAPIWrapper) {
        this.wrapper.getNativeMap().then((m) => {
            //console.log(google.maps);
            this.buildRoute();
        }
        );
    }
    buildRoute() {
        var directionsService = new google.maps.DirectionsService;
        var directionsDisplay = new google.maps.DirectionsRenderer;
        //var start = new google.maps.LatLng(this.start.latitude, this.start.longitude);
        //var end = new google.maps.LatLng(this.end.latitude, this.end.longitude);
        var start = new google.maps.LatLng(55.75222, 37.61556);
        var end = new google.maps.LatLng(52.22977, 21.01178);
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
                directionsDisplay.setDirections(response);
            }
        });
    }
}
   
