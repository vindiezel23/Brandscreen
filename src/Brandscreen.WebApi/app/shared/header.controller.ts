module App.Shared {
    'use strict';

    interface IHeaderModel {
        user: CurrentUser;
        logoff(): void;
    }

    class HeaderController implements IHeaderModel {
        static $inject = ['$location', 'securityService'];

        constructor(private $location: ng.ILocationService, private securityService: ISecurityService) {
            this.user = securityService.currentUser;
        }

        user: CurrentUser;

        logoff(): void {
            this.securityService
                .logoff()
                .then(() => {
                    this.$location.url('/account/login');
                });
        }
    }

    angular
        .module('bsApp')
        .controller('HeaderController', HeaderController);
}