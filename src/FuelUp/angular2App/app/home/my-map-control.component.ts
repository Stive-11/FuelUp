import {Component} from '@angular/core';
import { GoogleMapsAPIWrapper } from 'angular2-google-maps/core';

@Component({
    selector: 'my-map-control',
    template: ''
})
export class MyMapControlComponent {
    constructor(private wrapper: GoogleMapsAPIWrapper) {
        this.wrapper.getNativeMap().then((m) => {
            console.log("test");
        });
    }
}