module App.Manage {
    'use strict';

    interface IManageViewModel {
        user: Shared.CurrentUser;
        passwordForm: any;

        updatePassword(): void;
    }

    class ManageController implements IManageViewModel {
        static $inject = ['$http', '$location', 'notificationService', 'securityService'];

        constructor(private $http: ng.IHttpService, private $location: ng.ILocationService, private notificationService: Shared.INotificationService, securityService: Shared.ISecurityService) {
            this.user = securityService.currentUser;
        }

        user: Shared.CurrentUser;
        passwordForm: any;

        updatePassword(): void {
            this.$http
                .put('/manage/password', this.passwordForm)
                .then(() => {
                    this.notificationService.pushForNextRoute({
                        type: 'success',
                        message: 'Updated password successfully.'
                    });
                    this.$location.path('/manage');
                }, (error) => {
                    this.notificationService.pushForCurrentRouteWithTimeout({
                        type: 'danger',
                        message: error.data.errorMessage
                    });
                });
        }
    }

    angular
        .module('bsApp')
        .controller('ManageController', ManageController);
}