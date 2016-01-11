module App.Help {
    'use strict';

    config.$inject = ['$routeProvider'];

    function config($routeProvider: ng.route.IRouteProvider): void {
        // to retrieve page html for current url
        const html = [
            '$http', '$location', '$q', ($http: ng.IHttpService, $location: ng.ILocationService, $q: ng.IQService) => $http
            .get($location.url())
            .then(response => $q.resolve(response.data))
        ];

        $routeProvider
            .when('/help', {
                caseInsensitiveMatch: true,
                reloadOnSearch: false, // enabled bootstrap scrollspy
                templateUrl: '/help',
                controller: 'HelpListController',
                controllerAs: 'vm'
            })
            .when('/help/api/:apiId', {
                caseInsensitiveMatch: true,
                templateUrl: '/help/templates/help.tmpl.cshtml',
                controller: 'HelpController',
                controllerAs: 'vm',
                resolve: { html: html }
            })
            .when('/help/resourceModel', {
                caseInsensitiveMatch: true,
                templateUrl: '/help/templates/help.tmpl.cshtml',
                controller: 'HelpController',
                controllerAs: 'vm',
                resolve: { html: html }
            });
    }

    angular
        .module('bsApp')
        .config(config);
}