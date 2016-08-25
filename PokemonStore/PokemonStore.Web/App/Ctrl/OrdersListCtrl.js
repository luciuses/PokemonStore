'use strict';

    app.controller("OrdersListCtrl", [
        "$scope", "$http", "$timeout", "ROUTES", "Notification", function ($scope, $http, $timeout, ROUTES, Notification) {
            $scope.$root.title = 'Pokemon Store | Orders List';
            $http.defaults.headers.post["Content-Type"] = "application/json";

            $scope.gridOptions = {
                enableFiltering: true,
                treeRowHeaderAlwaysVisible: false,
                columnDefs: [
                    { name: 'Date', enableHiding: false },
                    { name: 'Name', enableHiding: false },
                    { name: 'Email', enableHiding: false, grouping: { groupPriority: 0 } },
                    { name: 'Phone', enableHiding: false }
                ],
                onRegisterApi: function (gridApi) {
                    $scope.gridApi = gridApi;
                },
                data: []
            };

            $scope.updateOrdersList = function () {
                $http.get(ROUTES.API.OPDER)
                    .then(function (pack) {
                        $scope.gridOptions.data = pack.data;
                        $scope.gridApi.grouping.groupColumn('Email');
                    }, function () {
                        Notification.error("Error while getting orders of Pokemons!");
                    });
            };

            $scope.updateOrdersList();
        }
    ]);