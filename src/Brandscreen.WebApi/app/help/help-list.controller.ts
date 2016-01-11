module App.Help {
    'use strict';

    class HelpListController {
        static $inject = ['$scope'];

        constructor($scope: ng.IScope) {
            // set bootstrap affix and scrollspy
            $scope.$on('$viewContentLoaded', () => {
                $('#navbar-side').affix({ offset: { top: 100, bottom: 200 } });
                $('body').scrollspy({ target: '#navbar-side' });
            });
        }
    }

    angular
        .module('bsApp')
        .controller('HelpListController', HelpListController);
}