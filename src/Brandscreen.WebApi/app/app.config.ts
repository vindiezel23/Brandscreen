module App {
    'use strict';

    config.$inject = ['$httpProvider', '$locationProvider', '$routeProvider'];

    function config($httpProvider: ng.IHttpProvider, $locationProvider: ng.ILocationProvider, $routeProvider: ng.route.IRouteProvider): void {
        // enable xhr detection in mvc for all http requests from angular
        $httpProvider.defaults.headers.common['X-Requested-With'] = 'XMLHttpRequest';

        // enable html5 route
        $locationProvider.html5Mode(true);

        // force browser to refresh page if any route isn't angular route
        $routeProvider
            .when('/error', {
                templateUrl: '/shared/templates/error-general.tmpl.cshtml'
            })
            .when('/error/404', {
                templateUrl: '/shared/templates/error-404.tmpl.cshtml'
            })
            .otherwise({
                redirectTo: (): string => {
                    console.log('navigating to ' + document.location.pathname);
                    window.location.reload();
                    return document.location.pathname;
                }
            });
    }

    // to make sure all events captured properly by having service dependencies in run
    run.$inject = ['$rootScope', '$location', '$timeout', '$http', 'securityService', 'breadcrumbService', 'notificationService'];

    function run($rootScope: ng.IScope, $location: ng.ILocationService, $timeout: ng.ITimeoutService, $http: ng.IHttpService, securityService): void {
        // route change count
        var isRouteChanging = false;
        $rootScope.$on('$routeChangeStart', (event, next, current) => {
            // note: breadcrumbService might call event.preventDefault to stop route from changing
            if (!event.defaultPrevented) isRouteChanging = true;
        });
        $rootScope.$on('$routeChangeSuccess', () => {
            $timeout(() => { isRouteChanging = false; }, 200);
        });
        $rootScope.$on('$routeChangeError', () => {
            isRouteChanging = false;
        });

        // loading indicator
        $rootScope['isViewLoading'] = () => (isRouteChanging || $http.pendingRequests.length > 0);

        // error redirection
        $rootScope.$on('$routeChangeError', (event, current, previous, rejection) => {
            switch (rejection.status) {
            case 401: // unauthorized
                $location.url('/account/login?returnUrl=' + $location.path());
                break;
            case 404: // not found
                $location.url('/error/404');
                break;
            default:
                $location.url('/error');
                break;
            }
        });
    }

    angular
        .module('bsApp')
        .config(config)
        .run(run);
}