module App.Manage {
    'use strict';

    config.$inject = ['$routeProvider'];

    function config($routeProvider: ng.route.IRouteProvider): void {
        $routeProvider
            .when('/manage', {
                caseInsensitiveMatch: true,
                templateUrl: '/manage/templates/manage.tmpl.cshtml',
                controller: 'ManageController',
                controllerAs: 'vm'
            })
            .when('/manage/password', {
                caseInsensitiveMatch: true,
                templateUrl: '/manage/templates/manage-password.tmpl.cshtml',
                controller: 'ManageController',
                controllerAs: 'vm'
            });
    }

    angular
        .module('bsApp')
        .config(config);
}