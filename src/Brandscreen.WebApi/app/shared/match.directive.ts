module App.Shared {
    'use strict';

    import DirectiveFactory = Common.DirectiveFactory;

    class MatchDirective implements ng.IDirective {
        static $inject = ['$parse'];

        constructor(private $parse: ng.IParseService) {
        }

        require = '?ngModel';
        restrict = 'A';
        link = (scope: ng.IScope, elem: ng.IAugmentedJQuery, attrs: ng.IAttributes, ctrl: any): void => {
            if (!ctrl) {
                if (console && console.warn) {
                    console.warn('Match validation requires ngModel to be on the element');
                }
                return;
            }

            var matchGetter = this.$parse(attrs['match']);
            var caselessGetter = this.$parse(attrs['matchCaseless']);
            var noMatchGetter = this.$parse(attrs['notMatch']);
            var getMatchValue = () => {
                var match = matchGetter(scope);
                if (angular.isObject(match) && match.hasOwnProperty('$viewValue')) {
                    match = match.$viewValue;
                }
                return match;
            }

            scope.$watch(getMatchValue, () => {
                ctrl.$$parseAndValidate();
            });

            ctrl.$validators.match = () => {
                var match = getMatchValue();
                var notMatch = noMatchGetter(scope);
                var value;

                if (caselessGetter(scope)) {
                    value = angular.lowercase(ctrl.$viewValue) === angular.lowercase(match);
                } else {
                    value = ctrl.$viewValue === match;
                }
                value ^= notMatch;
                return !!value;
            };
        };
    }

    angular
        .module('bsApp')
        .directive('match', DirectiveFactory.getFactoryFor<MatchDirective>(MatchDirective));
}