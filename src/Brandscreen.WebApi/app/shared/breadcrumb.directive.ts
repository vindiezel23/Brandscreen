module App.Shared {    
    'use strict';

    import DirectiveFactory = Common.DirectiveFactory;

    class BreadcrumbDirective implements ng.IDirective {
        templateUrl = '/shared/templates/breadcrumb.tmpl.cshtml';
        restrict = 'A';
        scope = {}; // ioslated scope
        controller = BreadcrumbController;
        controllerAs = 'vm';
        bindToController = true;
    }

    class BreadcrumbController {
        static $inject = ['breadcrumbService'];

        constructor(breadcrumbService: IBreadcrumbService) {
            this.breadcrumb = breadcrumbService;
        }

        breadcrumb: IBreadcrumbService;
    }

    angular
        .module('bsApp')
        .directive('breadcrumb', DirectiveFactory.getFactoryFor<BreadcrumbDirective>(BreadcrumbDirective));
}