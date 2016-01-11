module App.Account {
    'use strict';

    config.$inject = ['$routeProvider'];

    function config($routeProvider: ng.route.IRouteProvider): void {
        $routeProvider
            .when('/account/register', {
                caseInsensitiveMatch: true,
                templateUrl: '/account/templates/account-register.tmpl.cshtml',
                controller: 'AccountController',
                controllerAs: 'vm'
            })
            .when('/account/login', {
                caseInsensitiveMatch: true,
                templateUrl: '/account/templates/account-login.tmpl.cshtml',
                controller: 'AccountController',
                controllerAs: 'vm'
            });
    }

    angular
        .module('bsApp')
        .config(config);
}