(function () {
    'use strict';

    angular
        .module('app.fuelup.index')
        .config(moduleConfig);

    /* @ngInject */
    function moduleConfig($translatePartialLoaderProvider, $stateProvider, triMenuProvider, uiGmapGoogleMapApiProvider) {
        $translatePartialLoaderProvider.addPart('app/fuelup/index');

        $stateProvider
        .state('index.layout', {
            abstract: true//,
            //templateUrl: 'app/fuelup/index/layouts/index.tmpl.html'
        })
        .state('index', {
            url: '/index',
            templateUrl: 'app/fuelup/index/index.tmpl.html',
            controller: 'IndexController',
            controllerAs: 'vm',
            data: {
                layout: {
                    footer: true
                }
            }
        });

        // выпущеная версия GoogleMapApi v: '3'
        uiGmapGoogleMapApiProvider.configure({
           v: '3',
           libraries: 'weather,geometry,visualization',
           language: 'ru'
        });


    }
})();