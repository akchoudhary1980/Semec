var myApp = angular.module('myModule', ['angularUtils.directives.dirPagination']);
myApp.controller('myController', function ($scope, $http) {
    // default value 
    $scope.query = 'default';
    $scope.dataList = []; // list data
    $http.get('/Home/JsonValue', { params: { "q": $scope.query } }).success(function (response) {
        if (response != null || response != "undefined") {
            $scope.dataList = response;
        }
    })
    // click function    
    $scope.getdetails = function ($qq) {
        $scope.query = $qq; 
        //$http.get('/Home/JsonValue').success(function (response) {
        $http.get('/Home/JsonValue', { params: { "q": $scope.query } }).success(function (response) {
            if (response != null || response != "undefined") {
                $scope.dataList = response;
            }
        })   
    }   
     //
    // getlist by maincategory    
    $scope.listbymaincategory = function ($ids) {
        $scope.query = $ids;
        $http.get('/Home/ListingByMainCategory', { params: { "id": $scope.query } }).success(function (response) {
            if (response != null || response != "undefined") {
                $scope.dataList = response;
            }
        })
    }
     //
    // getlist by subcategory    
    $scope.listbysubcategory = function ($ids) {
        $scope.query = $ids;       
        $http.get('/Home/ListingBySubCategory', { params: { "id": $scope.query } }).success(function (response) {
            if (response != null || response != "undefined") {
                $scope.dataList = response;
            }
        })
    }
     //

    // getlist by subcategory    
    $scope.searchengine = function ($smode,$stext) {
        $scope.searchmode = $smode;
        $scope.searchtext = $stext;

        $http.get('/Home/SearchEngine', { params: { "mode": $scope.searchmode, "text": $scope.searchtext } }).success(function (response) {
            if (response != null || response != "undefined") {
                $scope.dataList = response;
            }
        })
    }
});   