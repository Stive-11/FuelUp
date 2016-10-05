import { Component, OnInit } from '@angular/core';
let styles = String(require('./about.component.scss'));

@Component({
    selector: 'about',
    template: require('./about.component.html'),
    styles: [styles], 
})

export class AboutComponent  {

    //public message: string;

    //constructor() {}

    //ngOnInit() {
       
    //}
}
