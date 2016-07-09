(function() {
    'use strict';

    angular
        .module('app', [
            
            'ngAnimate', 'ngCookies', 'ngSanitize', 'ngMessages', 'ngMaterial', 
            'ui.router', 'angularMoment', 'uiGmapgoogle-maps',   
            'app.fuelup'
        ])
       
        // set a constant for the API we are connecting to
        .constant('API_CONFIG', {
            
            'url': '/api/'
        });
        
})();