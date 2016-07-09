(function() {
    'use strict';

    angular
        .module('app')
        .config(routeConfig);

    /* @ngInject */
    function routeConfig($locationProvider, $stateProvider, $urlRouterProvider) {
        // Setup the apps routes
        //$locationProvider.html5Mode({
        //    enabled: true,
        //    requireBase: true//,
        //    //rewriteLinks: true
        //});

        // 404 & 500 pages
        $stateProvider
        .state('404', {
            url: '/404',
            templateUrl: '404.tmpl.html',
            controllerAs: 'vm',
            controller: function($state) {
                var vm = this;
                vm.goHome = function() {
                    $state.go('index');
                };
            }
        })

        .state('500', {
            url: '/500',
            templateUrl: '500.tmpl.html',
            controllerAs: 'vm',
            controller: function($state) {
                var vm = this;
                vm.goHome = function() {
                    $state.go('index');
                };
            }
        });


        // set default routes when no path specified
        $urlRouterProvider.when('', '/index');
        $urlRouterProvider.when('/', '/index');

        // always goto 404 if route not found
        //$urlRouterProvider.otherwise('/404');

        $locationProvider.html5Mode(true);

    }
})();