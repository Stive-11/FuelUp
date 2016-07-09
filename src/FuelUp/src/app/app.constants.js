(function () {
   'use strict';

    angular.module('app')
       .constant('cfg', defineConstants());

    /* @ngInject */ 
   function defineConstants() {
      var constants = {
	        URL : {
	            api: '/api'
	        }
      };

      return constants;
   }

})();
