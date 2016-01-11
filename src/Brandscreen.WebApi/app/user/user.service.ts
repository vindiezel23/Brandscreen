module App.User {
    'use strict';

    export interface IUserService {
        getUser(userId: string): ng.IHttpPromise<any>;
        getUsers(queryString: string): ng.IHttpPromise<any>;
        updateUser(user: any): ng.IHttpPromise<any>;
    }

    export class UserService implements IUserService {
        static $inject = ['$http'];

        constructor(private $http: ng.IHttpService) {
        }

        getUser(userId: string): ng.IHttpPromise<any> {
            return this.$http.get('/user/edit/' + userId);
        }

        getUsers(queryString: string): ng.IHttpPromise<any> {
            return this.$http.get('/user' + queryString);
        }

        updateUser(user: any): ng.IHttpPromise<any> {
            return this.$http.put('/user/update', user);
        }
    }

    angular
        .module('bsApp')
        .service('userService', UserService);
}