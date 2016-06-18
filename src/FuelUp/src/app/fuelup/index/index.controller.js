(function () {
   'use strict';

   angular
       .module('app.fuelup.index')
       .controller('IndexController', IndexController);

   /* @ngInject */
   function IndexController($scope, $q, $timeout, $mdToast, $filter, $mdDialog, uiGmapGoogleMapApi/*, uiGmapIsReady*/) {
      var vm = this;
      //vm.loading = true;

      uiGmapGoogleMapApi.then(function (maps) {
         vm.labeledMap = {
            center: {
               latitude: 53.911403,
               longitude: 27.517065
            },
            zoom: 17,
            marker: {
               id: 0,
               coords: {
                  latitude: 53.911403,
                  longitude: 27.517065
               },
               options: {
                  icon: {
                     anchor: new maps.Point(36, 36),
                     origin: new maps.Point(0, 0),
                     url: 'assets/images/maps/blue_marker.png'
                  }
               }
            },
            options: {
               scrollwheel: true
            }
         };

         vm.labelTitle = 'г. Минск, ул Скрыганова, 6';
         //$timeout(function () {
            //vm.loading = false;
         //}, 500);

      });

      $scope.animateElementIn = function ($el) {
         $el.removeClass('hidden');
         $el.addClass('fadeInUp'); // this example leverages animate.css classes 
      };

      $scope.animateElementOut = function ($el) {
         $el.addClass('hidden');
         $el.removeClass('fadeInUp'); // this example leverages animate.css classes 
      };

      //$scope.$on('$viewContentLoaded', function (event) {
      //   vm.loading = false;
      //});
      
      //uiGmapIsReady.promise()
      //.then(function () {
      //   vm.loading = false;
      //});
   }
})();