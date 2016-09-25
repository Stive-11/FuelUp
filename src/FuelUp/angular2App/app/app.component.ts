﻿import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import {ImgComponent} from "./image.component";
let styles = String(require('./app.component.scss'));
declare var jQuery: any;
import './rxjs-operators';

@Component({
    selector: 'my-app',
    template: require('./app.component.html'),
    styles: [styles]
})


export class AppComponent implements OnInit{
    home: string = "На главную";
    about: string = "О сайте";
    button: string = "Поехали";
    constructor(private router: Router) {
    }

    ngOnInit() {
        jQuery(".menu-opener").click(function () {
            jQuery(".menu-opener, .menu-opener-inner, .sidenav").toggleClass("active");
        });
    }
}