'use strict';
var app = angular.module('makePendrive', [
    'ngRoute',
    'ui.bootstrap',
    'utilModule',
    'mp.autoFocus',
    'angular-svg-round-progressbar'
])
        .constant(
                'CONSTANTS', { 
                }).config(['$routeProvider', '$httpProvider', 'CONSTANTS', function ($routeProvider, $httpProvider, EDUCATUX_CONSTANTS) {

        $httpProvider.defaults.headers.post['Content-Type'] = 'application/json';
        $httpProvider.defaults.headers.post['Accept'] = 'application/json';

        $routeProvider.
                when('/loading', {
                    templateUrl: '/views/loading/index.html',
                    controller: 'LoadingController'
                }).
                otherwise({
                    redirectTo: '/loading'
                });

    }

]).run(['utilTraceService', function (utilTraceService) {

        // Set to debug mode
        utilTraceService.setDebugMode(true);


    }]);
         