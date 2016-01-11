module App.User {
    'use strict';

    config.$inject = ['$routeProvider'];

    function config($routeProvider: ng.route.IRouteProvider): void {
        $routeProvider
            .when('/user', {
                caseInsensitiveMatch: true,
                templateUrl: '/user/templates/user-list.tmpl.cshtml',
                controller: 'UserListController',
                controllerAs: 'vm',
                resolve: {
                    users: [
                        '$route', 'userService', '$window',
                        ($route, userService, $window) => userService.getUsers($window.location.search)
                    ]
                }
            })
            .when('/user/edit/:userId', {
                caseInsensitiveMatch: true,
                templateUrl: '/user/templates/user-edit.tmpl.cshtml',
                controller: 'UserController',
                controllerAs: 'vm',
                resolve: {
                    user: [
                        '$route', 'userService',
                        ($route, userService) => userService.getUser($route.current.params.userId)
                    ]
                }
            });
    }

    angular
        .module('bsApp')
        .config(config);
}