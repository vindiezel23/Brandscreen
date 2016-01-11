module App.Shared {
    'use strict';

    import DirectiveFactory = Common.DirectiveFactory;

    class PagerDirective implements ng.IDirective {
        templateUrl = '/shared/templates/pager.tmpl.cshtml';
        restrict = 'A';
        scope = {
            pagedList: '=data'
        };
        controller = PagerController;
        controllerAs = 'vm';
        bindToController = true;
    }

    interface IPagerViewModel {
        pagedList: any;
        previousLink: string;
        nextLink: string;
    }

    class PagerController implements IPagerViewModel {
        static $inject = ['$location', '$httpParamSerializer'];

        constructor($location: ng.ILocationService, $httpParamSerializer: any) {
            var nameValues = $location.search();
            var currentPageNumber = nameValues.pageNumber ? parseInt(nameValues.pageNumber) : 1;
            if (!currentPageNumber) currentPageNumber = 1;

            var maxPageNumber = Math.floor((this.pagedList.totalItemCount - 1) / this.pagedList.pageSize) + 1;
            if (currentPageNumber > maxPageNumber) {
                currentPageNumber = maxPageNumber + 1;
            }

            if (this.pagedList.hasPreviousPage) {
                nameValues.pageNumber = currentPageNumber - 1;
                var previousLinkQueryString = $httpParamSerializer(nameValues);
                this.previousLink = $location.path() + '?' + previousLinkQueryString;
            }

            if (this.pagedList.hasNextPage) {
                nameValues.pageNumber = currentPageNumber + 1;
                var nextLinkQueryString = $httpParamSerializer(nameValues);
                this.nextLink = $location.path() + '?' + nextLinkQueryString;
            }
        }

        pagedList: any;
        previousLink: string;
        nextLink: string;
    }

    angular
        .module('bsApp')
        .directive('pager', DirectiveFactory.getFactoryFor<PagerDirective>(PagerDirective));
}