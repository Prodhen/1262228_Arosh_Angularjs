MainApp.controller('UnitController', ['$scope','$http', function ($scope,$http) {

    $scope.ListUnit = null;
    $scope.unitModel = {};
    $scope.unitModel.unitID = 0;
    getallData();

    //https://www.tutorialspoint.com/angularjs/angularjs_ajax.htm

    function getallData() {

        var url = '/api/Unit/GetUnit/';
        $http.get(url).then(function (response) {
            $scope.ListUnit = response.data;
        });

    };

   
    $scope.getUnit = function (unit) {
        $http({
            method: 'GET',
            url: '/api/Unit/GetUnitByID/' + parseInt(unit.unitID)
        }).then(function (response) {
            $scope.unitModel = response.data;
        }, function (error) {
            console.log(error);
        });
    };


    $scope.saveUnit = function () {
        $http({
            method: 'POST',
            url: '/api/Unit/PostUnit/',
            data: $scope.unitModel
        }).then(function (response) {
            $scope.reset();
            getallData();
        }, function (error) {
            console.log(error);
        });
    };


    $scope.updateUnit = function () {
        $http({
            method: 'PUT',
            url: '/api/Unit/PutUnit/' + parseInt($scope.unitModel.unitID),
            data: $scope.unitModel
        }).then(function (response) {
            $scope.reset();
            getallData();
        }, function (error) {
            console.log(error);
        });
    };

 
    $scope.deleteUnit = function (unit) {
        var IsConf = confirm('You are  delete ' + unit.Name + '. Are you sure?');
        if (IsConf) {
            $http({
                method: 'DELETE',
                url: '/api/Unit/DeleteUnitByID/' + parseInt(unit.unitID)
            }).then(function (response) {
                $scope.reset();
                getallData();
            }, function (error) {
                console.log(error);
            });
        }
    };

    $scope.reset = function () {
        var msg = "Form Cleared";
        $scope.unitModel = {};
        $scope.unitModel.unitID = 0;
    };
}]);
