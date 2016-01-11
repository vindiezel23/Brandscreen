module App.Shared {
    'use strict';

    export class CurrentUser {
        isAuthenticated: boolean;
        name: string;
        isAdmin: boolean;
        token: string;
    }

    export interface ISecurityService {
        currentUser: CurrentUser;
        register(data: any): ng.IPromise<CurrentUser>;
        login(data: any): ng.IPromise<CurrentUser>;
        logoff(): ng.IPromise<CurrentUser>;
        setCurrentUser(data: any): CurrentUser;
    }

    export class SecurityService implements ISecurityService {
        currentUser: CurrentUser;

        static $inject = ['$http', '$q'];

        constructor(private $http: ng.IHttpService, private $q: ng.IQService) {
            this.currentUser = new CurrentUser();
        }

        register(data: any): ng.IPromise<CurrentUser> {
            return this.$http
                .post('/account/register', data)
                .then(() => {
                    this.resetCurrentUser();
                    return this.requestCurrentUser();
                });
        }

        login(data: any): ng.IPromise<CurrentUser> {
            return this.$http
                .post('/account/login', data)
                .then(() => {
                    this.resetCurrentUser();
                    return this.requestCurrentUser();
                });
        }

        logoff(): ng.IPromise<CurrentUser> {
            return this.$http
                .post('/account/logoff', null)
                .then(() => {
                    this.resetCurrentUser();
                    return this.requestCurrentUser(); // renew token
                });
        }

        setCurrentUser(data: any): CurrentUser {
            angular.copy(data, this.currentUser);
            this.$http.defaults.headers.common['X-XSRF-Token'] = data.token; // set the anti forgery token for http request
            return this.currentUser;
        }

        private requestCurrentUser(): ng.IPromise<CurrentUser> {
            if (this.currentUser.isAuthenticated) {
                return this.$q.resolve(this.currentUser);
            }

            return this.$http
                .get('/account/currentUser')
                .then((response) => {
                    return this.setCurrentUser(response.data);
                });
        }

        private resetCurrentUser(): void {
            this.currentUser.isAuthenticated = false;
            this.currentUser.name = null;
            this.currentUser.isAdmin = false;
        }
    }

    angular
        .module('bsApp')
        .service('securityService', SecurityService);
}