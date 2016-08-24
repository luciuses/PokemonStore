    'use strict';
    app.controller("HomeCtrl", [
        "$scope", "$http", "ROUTES", "Notification", function ($scope, $http, ROUTES, Notification) {
            $http.defaults.headers.post["Content-Type"] = "application/json";
        }
    ]);