module App.Shared {
    'use strict';

    export class Notification {
        type: string;
        message: string;
    }

    export interface INotificationService {
        getCurrent(): Notification[];
        pushSticky(notification: Notification): void;
        pushForCurrentRoute(notification: Notification): void;
        pushForCurrentRouteWithTimeout(notification: Notification, timeout?: number): void;
        pushForNextRoute(notification: Notification): void;
        remove(notification: Notification): void;
        removeAll(): void;
    }

    class NotificationService implements INotificationService {
        private notifications = {
            'STICKY': new Array<Notification>(),
            'ROUTE_CURRENT': new Array<Notification>(),
            'ROUTE_NEXT': new Array<Notification>()
        };

        static $inject = ['$rootScope', '$timeout'];

        constructor($rootScope: ng.IScope, private $timeout: ng.ITimeoutService) {
            $rootScope.$on('$routeChangeSuccess', () => {
                this.notifications.ROUTE_CURRENT.length = 0;
                this.notifications.ROUTE_CURRENT = angular.copy(this.notifications.ROUTE_NEXT);
                this.notifications.ROUTE_NEXT.length = 0;
            });
        }

        getCurrent = () => this.notifications.STICKY.concat(this.notifications.ROUTE_CURRENT);

        pushSticky = (notification: Notification) => this.addNotification(this.notifications.STICKY, notification);

        pushForCurrentRoute = (notification: Notification) => this.addNotification(this.notifications.ROUTE_CURRENT, notification);

        pushForCurrentRouteWithTimeout = (notification: Notification, timeout: number = 3000) => {
            var retVal = this.addNotification(this.notifications.ROUTE_CURRENT, notification);
            this.$timeout(() => {
                var index = this.notifications.ROUTE_CURRENT.indexOf(notification);
                if (index !== -1) {
                    this.notifications.ROUTE_CURRENT.splice(index, 1);
                }
            }, timeout);
            return retVal;
        };

        pushForNextRoute = (notification: Notification) => this.addNotification(this.notifications.ROUTE_NEXT, notification);

        remove = (notification: Notification) => {
            angular.forEach(this.notifications, notificationsByType => {
                var idx = notificationsByType.indexOf(notification);
                if (idx > -1) {
                    notificationsByType.splice(idx, 1);
                }
            });
        };

        removeAll = () => {
            angular.forEach(this.notifications, notificationsByType => {
                notificationsByType.length = 0;
            });
        };

        private addNotification = (notificationsArray, notificationObj: Notification) => {
            if (!angular.isObject(notificationObj)) {
                throw new Error("Only object can be added to the notification service");
            }
            notificationsArray.push(notificationObj);
            return notificationObj;
        };
    }

    angular
        .module('bsApp')
        .service('notificationService', NotificationService);
}