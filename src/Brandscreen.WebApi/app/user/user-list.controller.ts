module App.User {
    'use strict';

    interface IUserListViewModel {
        userList: any[];
        searchText: string;
        search(): void;
        reset(): void;
    }

    class UserListController implements IUserListViewModel {
        static $inject = ['$location', 'users'];

        constructor(private $location: ng.ILocationService, users: any) {
            this.userList = users.data;
            this.searchText = $location.search().text;
        }

        userList: any[];
        searchText: string;

        search(): void {
            if (this.searchText) {
                this.$location.search({ text: this.searchText });
            }
        }

        reset(): void {
            this.$location.search({});
        }
    }

    angular
        .module('bsApp')
        .controller('UserListController', UserListController);
}