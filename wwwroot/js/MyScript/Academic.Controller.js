var app = angular.module('MainModule', []);

// Get Api
var baseUrl = 'http://localhost:21043/AcademicResult/';

app.factory('ProductFact', function ($http) {
    var factory = {};

    factory.GetProducts = function () {
        return $http.get(baseUrl);
    };

    factory.SaveProducts = function (obj) {
        return $http.post(baseUrl, obj);
    };

    factory.UpdateProducts = function (obj) {
        return $http.put(baseUrl + obj.academicResultID, obj);
    };

    factory.DeleteProducts = function (id) {
        return $http.delete(baseUrl + id);
    };
    return factory;
});

app.controller('ProductCtrl', function ($scope, ProductFact) {
    Init();
    function Init() {
        ProductFact.GetProducts().then(function (res) {
            $scope.ProductList = res.data;
        })
    }

    $scope.SaveProduct = function () {
        ProductFact.SaveProducts($scope.objProduct).then(function () {
            Init();
            Clear();
        })
    }

    $scope.EditProduct = function (p) {
        $scope.objProduct = p;
    }

    $scope.UpdateProduct = function () {
        ProductFact.UpdateProducts($scope.objProduct).then(function () {
            Init();
            Clear();
        })
    }

    $scope.DeleteProduct = function (id) {
        ProductFact.DeleteProducts(id).then(function () {
            Init();
        })
    }

    function Clear() {
        $scope.objProduct = null;
    }

});



