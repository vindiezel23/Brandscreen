module App.Shared {
    'use strict';

    import DirectiveFactory = Common.DirectiveFactory;

    class NotificationDirective implements ng.IDirective {
        templateUrl = '/shared/templates/notification.tmpl.cshtml';
        restrict = 'A';
        scope = {}; // ioslated scope
        controller = NotificationController;
        controllerAs = 'vm';
        bindToController = true;
    }

    class NotificationController {
        static $inject = ['notificationService'];

        constructor(notificationService: any) {
            this.notifications = notificationService;
        }

        notifications: any;
    }

    angular
        .module('bsApp')
        .directive('notification', DirectiveFactory.getFactoryFor<NotificationDirective>(NotificationDirective));
}