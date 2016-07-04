/// <reference path="angular.js" />

(function () {
    'use-strict';
    var app = angular.module('MyApplication', ['ngMaterial', 'ngMessages', 'material.svgAssetsCache']);

    var selectedMakeId = '';

    app.controller('AutoCompleteCtrl', AutoCompleteCtrl);
    app.controller('AutoCompleteModelCtrl', AutoCompleteModelCtrl);

    function AutoCompleteModelCtrl($http, $timeout, $q, $log) {

        var self = this;
        self.simulateQuery = true;
        self.models = loadAllModels($http);
        self.querySearch = querySearch;
        self.selectedItemChange = selectedItemChange;
        self.selectedItem = '';
        self.selectedMakeId = selectedMakeId;

        function querySearch(query) {
            var results = query ? self.models.filter(createFilterFor(query)) :
                self.models,
                deffered;

            if (self.simulateQuery) {
                deffered = $q.defer();
                $timeout(function () {
                    deffered.resolve(results);
                }, Math.random() * 1000, false);
                return deffered.promise;
            }
            else {
                console.clear();
                angular.forEach(results, function (m, k) {
                    console.log(m.Id + ' ' + m.value);
                });
                return results;
            }
        }

        function selectedItemChange(item) {
            self.selectedItem = item;
        }

        function createFilterFor(query) {
            var lowerCaseQuery = angular.lowercase(query);
            return function filterFn(make) {
                return (make.value.indexOf(lowerCaseQuery) == 0 && make.Id == selectedMakeId);
            }
        }

        function loadAllModels($http) {
          
            var allMakes = [];
            var url = '';
            var result = [];
            url = 'api/carapi/getmodels';
            $http(
                {
                    method: 'GET',
                    url: url
                }).then(function successCallback(response) {
                    allMakes = response.data;
                    
                    angular.forEach(allMakes, function (make, key) {
                        result.push(
                            {
                                Id: make.MakeId,
                                value: make.Name.toLowerCase(),
                                display: make.Name
                            });
                    });

                }, function errorCallback(response) {
                    console.log('Ooops something went wrong' + response.status + ' Status text: ' + response.statusText);

                });
            return result;
        }
        
    }

    function AutoCompleteCtrl($http, $timeout, $q, $log) {
        var self = this;
        self.simulateQuery = true;
        self.makes = loadAllMakes($http);
        self.querySearch = querySearch;
        self.selectedItemChange = selectedItemChange;
        self.selectedItem = '';

        function querySearch(query) {
            var results = query ? self.makes.filter(createFilterFor(query)) :
                self.makes,
                deffered;

            if (self.simulateQuery) {
                deffered = $q.defer();
                $timeout(function () {
                    deffered.resolve(results);
                }, Math.random() * 1000, false);
                return deffered.promise;
            }
            else {
                return results;
            }
        }

        function selectedItemChange(item) {
            self.selectedItem = item;

            if (typeof self.selectedItem != "undefined")
            {
                selectedMakeId = self.selectedItem.Id;
            }
            //$log.info('Item changed to ' + JSON.stringify(self.selectedItem));
        }

        function createFilterFor(query) {
            var lowerCaseQuery = angular.lowercase(query);
            return function filterFn(make) {
                return (make.value.indexOf(lowerCaseQuery) == 0);
            }
        }

        function loadAllMakes($http) {
            
            var allMakes = [];
            var url = '';
            var result = [];
            url = 'api/carapi/getmakes';
            $http(
                {
                    method: 'GET',
                    url: url
                }).then(function successCallback(response) {
                    allMakes = response.data;

                    angular.forEach(allMakes, function (make, key) {
                        result.push(
                            {
                                Id: make.Id,
                                value: make.Name.toLowerCase(),
                                display: make.Name
                            });
                    });

                }, function errorCallback(response) {
                    console.log('Ooops something went wrong' + response.status + ' Status text: ' + response.statusText);

                });
            return result;
        }
    }
})();