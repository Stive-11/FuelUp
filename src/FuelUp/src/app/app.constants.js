(function () {
   'use strict';

   var config = {
      api: {
         url: '/api/v1'
         
         }
      }
   };


    angular.module('app')
       .constant('cfg', defineConstants());

   function defineConstants() {
      var constants = {
	URL : {
	api: config.api.url
	}

      };

      return constants;
   }

})();
