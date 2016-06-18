(function () {
   'use strict';

   angular
       .module('app.fuelup.index')
       .directive('headerScroll', headerScroll);

   /* @ngInject */
   function headerScroll($window, $timeout) {
      // Usage:
      //     <div header-scroll></div>
      // Creates:
      // 
      var directive = {
         link: link,
         restrict: 'A'
      };
      return directive;

      function link(scope, element, attrs) {
         // Hide Header on on scroll down
         var didScroll;
         var lastScrollTop = 0;
         var delta = 70;
         var navbar = element[0];
         var navbarHeight = navbar.clientHeight;

         angular.element($window).bind("scroll", function () {
            $timeout(function () {
               hasScrolled();
            }, 250);
         });

         function hasScrolled() {
            var st = $window.scrollY;

            // Make sure they scroll more than delta
            if (Math.abs(lastScrollTop - st) <= delta) {
               return;
            }

            if (st == 0) {
               navbar.classList.remove('is-fixed', 'is-visible');
               return;
            }
            else if (st > 0) {
               navbar.classList.add('is-fixed');
            }

            // If they scrolled down and are past the navbar, add class .nav-up.
            // This is necessary so you never see what is "behind" the navbar.
            if (st > lastScrollTop && st > navbarHeight) {
               navbar.classList.remove('is-visible');
            } else {
               // Scroll Up
               if (st + $(window).height() < $(document).height()) {
                  navbar.classList.add('is-visible');
               }
            }

            lastScrollTop = st;
         }
      }
   }

})();