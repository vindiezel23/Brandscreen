module App.Common {
    'use strict';

    export class DirectiveFactory {
        static getFactoryFor<T extends ng.IDirective>(classType: Function): ng.IDirectiveFactory {
            const factory = (...args): T => {
                return new (<any> classType)(...args);
            };
            factory.$inject = classType.$inject;
            return factory;
        }
    }
}