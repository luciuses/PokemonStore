'use strict';

    app.controller("OrdersFeedCtrl", [
        "$scope", "$http", "$timeout", "ROUTES", "Notification", function ($scope, $http, $timeout, ROUTES, Notification) {
            $scope.$root.title = 'Pokemon Store | Orders Feed';
            $http.defaults.headers.post["Content-Type"] = "application/json";

            function updateData(date) {
                $http.get(ROUTES.API.OPDER + "?date=" + date).success(function (data) {
                    $scope.totalOrders = data.length;
                    $scope.ordersPerEmail = _.chain(data).groupBy(function (item) {
                        return item.Email;
                    }).map(function (items, email) {
                            return {
                                email: email,
                                ordersCount: items.length,
                                name: items[items.length-1].Name,
                                date: items[items.length - 1].Date.toString()
                            };
                        }
                    ).value();
                });
            }

            $scope.dateReport = new Date();

            $scope.refreshData = function () {
                updateData($scope.dateReport.toDateString());
            }

            $scope.refreshData();
        }
    ]);