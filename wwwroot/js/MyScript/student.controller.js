var MainApp;
/*var ProducApp;*/

(
    function () {
        'use strict';
        MainApp = angular.module('MainModule_app', ['ui.router']);
    }
)();



var baseUrl = 'http://localhost:21043/api/Student/';


MainApp.factory('StudentFact', function ($http) {
    var factory = {};

    factory.GetStu = function () {
        return $http.get(baseUrl);
    };

    return factory;


});



MainApp.controller('StudentController', ['$scope', '$http', 'StudentFact', function ($scope, $http, StudentFact) {

    $scope.ListStudent = null;
    $scope.ListOrder = null;
    $scope.studentModel = {};
    $scope.studentModel.studentID = 0;
    getallData();
    getallPrimary();



    /*function p() { o({ method: "GET", url: "/api/Student/GetBook/" }).then(function (e) { t.ListOrder = e.data }, function (e) { console.log(e) }) }*/



    function getallPrimary() {
        $http({
            method: 'GET',
            url: '/api/Student/GetUnit/'
        }).then(function (response) {
            $scope.ListOrder = response.data;
        }, function (error) {
            console.log(error);
        });
    };




    //function getallData() {
    //    $http({
    //        method: 'GET',
    //        url: '/api/Student/GetUser/'
    //    }).then(function (response) {
    //        $scope.ListStudent = response.data;
    //    }, function (error) {
    //        console.log(error);
    //    });
    //};


    //https://www.tutorialspoint.com/angularjs/angularjs_ajax.htm


    function getallData() {
        StudentFact.GetStu().then(function (response) {
            $scope.ListStudent = response.data;

        });
    }


    $scope.getUser = function (student) {
        $http({
            method: 'GET',
            url: '/api/Student/GetStudentByID/' + parseInt(student.studentID)
        }).then(function (response) {
            $scope.studentModel = response.data;
        }, function (error) {
            console.log(error);
        });
    };


    $scope.saveUser = function () {
        $http({
            method: 'POST',
            url: '/api/Student/PostStudent/',
            data: $scope.studentModel
        }).then(function (response) {
            $scope.reset();
            getallData();
        }, function (error) {
            console.log(error);
        });
    };


    $scope.updateUser = function () {
        $http({
            method: 'PUT',
            url: '/api/Student/PutStudent/' + parseInt($scope.studentModel.studentID),
            data: $scope.studentModel
        }).then(function (response) {
            $scope.reset();
            getallData();
        }, function (error) {
            console.log(error);
        });
    };


    $scope.deleteUser = function (stu) {
        var IsConf = confirm('You are  delete ' + stu.name + '. Are you sure?');
        if (IsConf) {
            $http({
                method: 'DELETE',
                url: '/api/Student/DeleteStudentByID/' + parseInt(stu.studentID)
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
        $scope.studentModel = {};
        $scope.studentModel.id = 0;
    };
}]);


MainApp.component('manuList', {
    templateUrl: './Pages/menupage.html',
    controller: 'StudentController'

})

//MainApp.component('resultList', {
//    templateUrl: './Pages/Academic/academic.html',
//    controller: 'StudentController'

//})


MainApp.config(['$locationProvider', '$stateProvider', '$urlRouterProvider', '$urlMatcherFactoryProvider', '$compileProvider',
    function ($locationProvider, $stateProvider, $urlRouterProvider, $urlMatcherFactoryProvider, $compileProvider) {


        if (window.history && window.history.pushState) {
            $locationProvider.html5Mode({
                enabled: true,
                requireBase: true
            }).hashPrefix('!');
        };
        $urlMatcherFactoryProvider.strictMode(false);
        $compileProvider.debugInfoEnabled(false);

        $stateProvider
            .state('home', {
                url: '/',
                templateUrl: './views/home/home.html',
                controller: 'HomeController'
            })
            .state('book', {
                url: '/Book',
                templateUrl: './views/Book/Book.html',
                controller: 'BookController'
            })
            .state('product', {
                url: '/Product',
                templateUrl: './views/Product/Product.html',
                controller: 'ProductController'
            })
            .state('user4', {
                url: '/User4',
                templateUrl: './views/Book/Book.html',
                controller: 'AddController'
            })
            .state('student', {
                url: '/student',
                templateUrl: './Pages/Student/student.html',
                controller: 'StudentController'
            })
            .state('unit', {
                url: '/unit',
                templateUrl: './Pages/Unit/unit.html',
                controller: 'UnitController'
            })

            .state('about', {
                url: '/about',
                templateUrl: './views/about/about.html',
                controller: 'AboutController'
            });

        $urlRouterProvider.otherwise('/');
    }]);

            //.state('academic', {
            //    url: '/academic',
            //    templateUrl: '/Pages/Academic/academic.html',
            //    controller: 'AcademicController'
            //})


















































////var MainApp;
////var ProducApp;
//////(
//////    function () {
//////        'use strict';
//////        ProducApp = angular.module('Product_app', ['ui.router']);
//////    }
//////)();
/////*ProducApp = angular.module('templating_app', ['ngRoute']);*/



////(
////    function () {
////        'use strict';
////        MainApp = angular.module('MainModule_app', ['ui.router']);
////    }
////)();



////var baseUrl = 'http://localhost:21043/api/Values/';
//////var url = 'http://localhost:2670/api/Values/GetUser';

////MainApp.factory('ProductFact', function ($http) {
////    var factory = {};

////    factory.GetProducts = function () {
////        return $http.get(baseUrl);
////    };

////    return factory;


////});

//////templatingApp.controller('ProductCtrl', function ($scope, ProductFact) {
//////    Init();
//////    function Init() {
//////        ProductFact.GetUser().then(function (res) {
//////            $scope.ListUserTest = res.data;
//////        })
//////    };



//////});

//////app.config(function ($routeProvider, $locationProvider) {
//////    $routeProvider
//////        .when('/', { templateUrl: '/Pages/Default.html' })
//////        .when('/Product', { templateUrl: './views/user/Product.html', controller: 'ProductCtrl' })
//////        .otherwise({ redirectTo: '/' });

//////    $locationProvider.hashPrefix('');
//////})





////MainApp.controller('StudentController', ['$scope', '$http', 'ProductFact', function ($scope, $http, ProductFact) {
////    $scope.title = "All User";
////    $scope.ListUser = null;
////    $scope.ListOrder = null;
////    $scope.BookArray = [];
////    /*    $scope.ListUserTest;*/
////    $scope.userModel = {};
////    $scope.userModel.studentID = 0;
////    getallData();
////    getallPrimary();


////    //someFactory.getallData().then(function (result) {
////    //    $scope.ListUser = result.data;
////    //}, function (err) {
////    //    console.log(err);
////    //});



////    //$scope.ListUserTest = function () {
////    //    $.ajax({
////    //        type: 'GET',
////    //        contentType: 'application/json',
////    //        url: '/api/Values/GetUser/',
////    //        success: function (data) {
////    //            $scope.BookArray = data;
////    //            $scope.$apply();
////    //        }
////    //    });
////    //};





////    /*function p() { o({ method: "GET", url: "/api/Values/GetBook/" }).then(function (e) { t.ListOrder = e.data }, function (e) { console.log(e) }) }*/


////    //******=========Get All User=========******
////    function getallPrimary() {
////        $http({
////            method: 'GET',
////            url: '/api/Values/GetBook/'
////        }).then(function (response) {
////            $scope.ListOrder = response.data;
////        }, function (error) {
////            console.log(error);
////        });
////    };







////    //******=========Get All User=========******
////    ////function getallData() {
////    ////    $http({
////    ////        method: 'GET',
////    ////        url: '/api/Values/GetUser/'
////    ////    }).then(function (response) {
////    ////        $scope.ListUser = response.data;
////    ////    }, function (error) {
////    ////        console.log(error);
////    ////    });
////    ////};


////    //https://www.tutorialspoint.com/angularjs/angularjs_ajax.htm

////    //function getallData() {

////    //    var url = '/api/Values/GetUser/';
////    //    $http.get(url).then(function (response) {
////    //        $scope.ListUser = response.data;
////    //     });

////    //};

////    function getallData() {
////        ProductFact.GetProducts().then(function (response) {
////            $scope.ListUser = response.data;

////        });
////    }





////    //******=========Get Single User=========******
////    $scope.getUser = function (user) {
////        $http({
////            method: 'GET',
////            url: '/api/Values/GetUserByID/' + parseInt(user.studentID)
////        }).then(function (response) {
////            $scope.userModel = response.data;
////        }, function (error) {
////            console.log(error);
////        });
////    };

////    //******=========Save User=========******
////    $scope.saveUser = function () {
////        $http({
////            method: 'POST',
////            url: '/api/Values/PostUser/',
////            data: $scope.userModel
////        }).then(function (response) {
////            $scope.reset();
////            getallData();
////        }, function (error) {
////            console.log(error);
////        });
////    };

////    //******=========Update User=========******
////    $scope.updateUser = function () {
////        $http({
////            method: 'PUT',
////            url: '/api/Values/PutUser/' + parseInt($scope.userModel.studentID),
////            data: $scope.userModel
////        }).then(function (response) {
////            $scope.reset();
////            getallData();
////        }, function (error) {
////            console.log(error);
////        });
////    };

////    //$scope.updateUser = function () {

////    //    var url = '/api/Values/PutUser/' + parseInt($scope.userModel.id);
////    //    $http.PUT(url).then(function (response) {
////    //        $scope.reset();
////    //        getallData();
////    //    });
////    //};




////    //******=========Delete User=========******
//////    $scope.deleteUser = function (user) {
//////        var IsConf = confirm('You are about to delete ' + user.Name + '. Are you sure?');
//////        if (IsConf) {
//////            $http({
//////                method: 'DELETE',
//////                url: '/api/Values/DeleteUserByID/' + parseInt(user.studentID)
//////            }).then(function (response) {
//////                $scope.reset();
//////                getallData();
//////            }, function (error) {
//////                console.log(error);
//////            });
//////        }
//////    };

//////    //******=========Clear Form=========******
//////    $scope.reset = function () {
//////        var msg = "Form Cleared";
//////        $scope.userModel = {};
//////        $scope.userModel.id = 0;
//////    };
//////}]);
//////var url = 'http://localhost:2670/api/Values/GetUser';
//////templatingApp.factory('someFactory', ['$http', function ($http) {
//////    var service = {
//////        getallData: function () {
//////            return $http.get(url);
//////        }
//////    };
//////    return service;
//////}]);
//////MainApp.component('manuList', {
//////    templateUrl: './Pages/htmlpage.html',
//////    controller: 'StudentController'

//////})


//////MainApp.config(['$locationProvider', '$stateProvider', '$urlRouterProvider', '$urlMatcherFactoryProvider', '$compileProvider',
//////    function ($locationProvider, $stateProvider, $urlRouterProvider, $urlMatcherFactoryProvider, $compileProvider) {

//////        //console.log('Appt.Main is now running')
//////        if (window.history && window.history.pushState) {
//////            $locationProvider.html5Mode({
//////                enabled: true,
//////                requireBase: true
//////            }).hashPrefix('!');
//////        };
//////        $urlMatcherFactoryProvider.strictMode(false);
//////        $compileProvider.debugInfoEnabled(false);

//////        $stateProvider
//////            .state('home', {
//////                url: '/',
//////                templateUrl: './views/home/home.html',
//////                controller: 'HomeController'
//////            })
//////            .state('book', {
//////                url: '/Book',
//////                templateUrl: './views/Book/Book.html',
//////                controller: 'BookController'
//////            })
//////            .state('product', {
//////                url: '/Product',
//////                templateUrl: './views/Product/Product.html',
//////                controller: 'ProductController'
//////            })
//////            .state('user4', {
//////                url: '/User4',
//////                templateUrl: './views/Book/Book.html',
//////                controller: 'AddController'
//////            })
//////            .state('user', {
//////                url: '/user',
//////                templateUrl: './Pages/Student/student.html',
//////                controller: 'StudentController'
//////            })
//////            .state('unit', {
//////                url: '/unit',
//////                templateUrl: './Pages/Unit/unit.html',
//////                controller: 'UnitController'
//////            })
//////            .state('about', {
//////                url: '/about',
//////                templateUrl: './views/about/about.html',
//////                controller: 'AboutController'
//////            });

//////        $urlRouterProvider.otherwise('/');
//////    }]);

//////MainApp.component('Manu', {
//////    templateUrl: './htmlpage.html',
//////    controller:'StudentController'

//////})