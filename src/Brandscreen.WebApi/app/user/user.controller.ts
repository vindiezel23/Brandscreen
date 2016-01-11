module App.User {
    'use strict';

    interface IUserViewModel {
        roleList: any[];
        claimList: any[];
        user: any;
        newRole: string;
        newClaim: any;

        addRole(newRole: string): void;
        removeRole(role: string): void;
        addClaim(newClaim: any): void;
        removeClaim(claim: any): void;
        save(): void;
        cancel(): void;
    }

    class UserController implements IUserViewModel {
        static $inject = ['$scope', '$http', '$location', 'notificationService', 'userService', 'breadcrumbService', 'user'];

        constructor(private $scope: ng.IScope,
            private $http: ng.IHttpService,
            private $location: ng.ILocationService,
            private notificationService: Shared.INotificationService,
            private userService: IUserService,
            breadcrumbService: Shared.IBreadcrumbService,
            user: any) {
            // data
            this.roleList = user.data.roleList;
            this.claimList = user.data.claimList;
            this.user = user.data.model;

            // set breadcrumb label
            breadcrumbService.setLabel(this.user.email);
        }

        roleList: any[];
        claimList: any[];
        user: any;
        newRole: string;
        newClaim: any;

        addRole(newRole: string): void {
            if (!newRole) return;
            var index = this.user.roles.indexOf(newRole);

            if (index === -1) {
                // add
                this.user.roles.push(newRole);
                this.newRole = null;
                // reset
                this.resetForm(this.$scope['roleForm']);
            } else {
                this.notificationService.pushForCurrentRouteWithTimeout({
                    type: 'warning',
                    message: 'Role [' + newRole + '] exists already.'
                });
            }
        }

        removeRole(role: string): void {
            var index = this.user.roles.indexOf(role);
            this.user.roles.splice(index, 1);
        }

        addClaim(newClaim: any): void {
            if (!angular.isObject(newClaim)) return;
            if (newClaim.type && newClaim.value) {
                var found = false;
                var newClaimStr = JSON.stringify(newClaim);
                this.user.claims.forEach(claim => {
                    // search if there is the same claim
                    if (JSON.stringify({ type: claim.type, value: claim.value }) === newClaimStr) found = true;
                });

                if (!found) {
                    // add
                    this.user.claims.push(newClaim);
                    this.newClaim = {};
                    // reset
                    this.resetForm(this.$scope['claimForm']);
                } else {
                    this.notificationService.pushForCurrentRouteWithTimeout({
                        type: 'warning',
                        message: 'Same claim exists already.'
                    });
                }
            }
        }

        removeClaim(claim: any): void {
            var index = this.user.claims.indexOf(claim);
            this.user.claims.splice(index, 1);
        }

        save(): void {
            this.userService
                .updateUser(this.user)
                .then(() => {
                    this.notificationService.pushForNextRoute({
                        type: 'success',
                        message: 'Saved ' + this.user.email + ' successfully.'
                    });
                    this.$location.path('/user');
                }, error => {
                    this.notificationService.pushForCurrentRouteWithTimeout({
                        type: 'danger',
                        message: error.data.errorMessage
                    });
                });
        }

        cancel(): void {
            window.history.back();
        }

        resetForm(form: any): void {
            form.$setPristine();
            form.$setUntouched();
        }
    }

    angular
        .module('bsApp')
        .controller('UserController', UserController);
}