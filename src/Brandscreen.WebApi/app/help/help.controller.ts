module App.Help {
    'use strict';

    interface IHelpViewModel {
        html: any;
    }

    class HelpController implements IHelpViewModel {
        static $inject = ['$sce', '$routeParams', 'breadcrumbService', 'html'];

        constructor($sce: ng.ISCEService, $routeParams: ng.route.IRouteParamsService, breadcrumbService: Shared.IBreadcrumbService, html: any) {
            this.html = $sce.trustAsHtml(html); // to be explicitly trusted

            // set label
            if ($routeParams['apiId']) {
                var index = $routeParams['apiId'].indexOf('_');
                if (index !== -1) {
                    var label = $routeParams['apiId'].substring(0, index);
                    breadcrumbService.setLabel(label);
                } else {
                    breadcrumbService.setLabel($routeParams['apiId']);
                }
            } else if ($routeParams['modelName']) {
                breadcrumbService.setLabel($routeParams['modelName']);
            }
        }

        html: any;
    }

    angular
        .module('bsApp')
        .controller('HelpController', HelpController);
}