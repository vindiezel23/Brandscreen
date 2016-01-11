module App.Account {
    'use strict';

    interface IAccountViewModel {
        registerForm: any;
        loginForm: any;

        register(): void;
        login(): void;
    }

    class AccountController implements IAccountViewModel {
        static $inject = ['$location', 'securityService', 'notificationService'];

        constructor(private $location: ng.ILocationService, private securityService: Shared.ISecurityService, private notificationService: Shared.INotificationService) {
        }

        registerForm: any;
        loginForm: any;

        register(): void {
            this.securityService
                .register(this.registerForm)
                .then(() => {
                    this.$location.url('/manage');
                }, error => {
                    this.notificationService.pushForCurrentRouteWithTimeout({
                        type: 'danger',
                        message: error.data.errorMessage
                    });
                });
        }

        login(): void {
            this.securityService.login(this.loginForm)
                .then(() => {
                    var returnUrl = this.$location.search()['returnUrl'];
                    this.$location.url(returnUrl || '/manage');
                }, error => {
                    this.notificationService.pushForCurrentRouteWithTimeout({
                        type: 'danger',
                        message: error.data.errorMessage
                    });
                });
        }
    }

    angular
        .module('bsApp')
        .controller('AccountController', AccountController);
}