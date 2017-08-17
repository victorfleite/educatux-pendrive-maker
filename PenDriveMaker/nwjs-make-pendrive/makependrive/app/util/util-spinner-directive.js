'use strict';
angular.module('utilModule')
.directive('spinner', [function () {
    return {
      restrict: 'EA',
      replace: true,
      transclude: true,
      scope: {
        show: '=?'
      },
      template: [
        '<div class="loading"><span ng-show="show">',
        '  <img ng-show="imgSrc" ng-src="{{imgSrc}}" />',
        '  <span ng-transclude></span>',
        '</span></div>'
      ].join(''),
      controller: function ($scope) {

      }
    };
  }]);