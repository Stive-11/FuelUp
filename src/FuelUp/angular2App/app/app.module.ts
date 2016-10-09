import { NgModule, OnInit } from '@angular/core';
import { CommonModule }   from '@angular/common';
import { FormsModule }    from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent }  from './app.component';
import { Configuration } from './app.constants';
import { routing } from './app.routes';
import { HttpModule, JsonpModule } from '@angular/http';
import { HomeComponent } from './home/home.component';
import { AboutComponent } from './about/about.component';
import { AgmCoreModule } from 'angular2-google-maps/core';
import {SebmGoogleMapMarker} from 'angular2-google-maps/core';
import {ImgComponent} from "./image.component";
import { MapsAPILoader, NoOpMapsAPILoader} from 'angular2-google-maps/core';
import {GoogleMapsAPIWrapper} from 'angular2-google-maps/core/services';
import {MyMapControlComponent} from "./home/my-map-control.component";

//{ apiKey: 'AIzaSyAkWj_SbGsQB4xu8dH0v7PvCP2jz9yt24Y', libraries: ['places'] }
@NgModule({
    imports: [
        BrowserModule,
        CommonModule,
        FormsModule,
        routing,
        HttpModule,
        JsonpModule,
        AgmCoreModule.forRoot()
        
    ],
    declarations: [
        AppComponent,
        AboutComponent,
        HomeComponent,
        ImgComponent,
        MyMapControlComponent
    ],
    providers: [
       // TestDataService,
        GoogleMapsAPIWrapper,
        Configuration,
        { provide: MapsAPILoader, useClass: NoOpMapsAPILoader }
    ],
    bootstrap:    [AppComponent]
})

export class AppModule {}