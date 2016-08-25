    'use strict';

    var app = angular.module('app', ['ngRoute', 'ui.grid', 'ui.grid.grouping', 'ui-notification']);
    app.constant('ROUTES', (function () {
        return {
            UI: {
                DEFAULT: '/',
                ORDER: '/order',
                ORDERS_FEED: '/ordersfeed',
                ORDERS_LIST: '/orderslist'
            },
            API: {
                OPDER: '/api/order'
            }
        }
    })());

    app.config(['$routeProvider', '$locationProvider', 'ROUTES',
        function ($routeProvider, $locationProvider, ROUTES) {
            $locationProvider.html5Mode(true);

            $routeProvider.
                when(ROUTES.UI.DEFAULT, {
                    templateUrl: '/views/order',
                    controller: 'OrderCtrl'
                }).
                when(ROUTES.UI.ORDER, {
                    templateUrl: '/views/order',
                    controller: 'OrderCtrl'
                }).
                when(ROUTES.UI.ORDERS_FEED, {
                    templateUrl: '/views/ordersfeed',
                    controller: 'OrdersFeedCtrl'
                }).
                when(ROUTES.UI.ORDERS_LIST, {
                    templateUrl: '/views/orderslist',
                    controller: 'OrdersListCtrl'
                }).
                otherwise({
                    redirectTo: ROUTES.UI.DEFAULT
                });

        }
    ]);
