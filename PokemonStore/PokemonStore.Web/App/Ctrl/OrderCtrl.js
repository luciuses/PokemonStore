'use strict';
    app.controller("OrderCtrl", [
        "$scope", "$http", '$location', "ROUTES", "Notification", function ($scope, $http, $location, ROUTES, Notification) {
            $scope.$root.title = 'Pokemon Store | Order';
            $http.defaults.headers.post["Content-Type"] = "application/json";
            $scope.order = function (name, email, phone) {
                $http.post(ROUTES.API.OPDER,
                    {
                        name: name,
                        email: email,
                        phone: phone
                    })
                    .then(function (pack) {
                        $scope.orderResult = pack.data;
                        $location.path(ROUTES.UI.ORDERS_FEED);
                        Notification.success("Pokemon is ordered for you!");
                    }, function () {
                        Notification.error("Error while order Pokemon!");
                    });
            }
        }
    ]);