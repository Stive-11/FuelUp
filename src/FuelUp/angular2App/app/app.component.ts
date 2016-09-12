import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import {ImgComponent} from "./image.component";
let styles = String(require('./app.component.scss'));

@Component({
    selector: 'my-app',
    template: require('./app.component.html'),
    styles: [styles]
})


export class AppComponent {
    home: string = "На главную";
    about: string = "О сайте";
    constructor(private router: Router) {
    }
}