module App.Shared {
    'use strict';

    export class BreadcrumbStep {
        constructor(public name: string, public path: string, public parent: string, public allowAnonymous: boolean = false) {
        }
    }

    export class BreadcrumbLable {
        text: string;
        oldText: string;
    }

    export interface IBreadcrumbService {
        allSteps: BreadcrumbStep[];
        steps: BreadcrumbStep[];
        label: BreadcrumbLable;

        setLabel(text: string): void;
    }

    export class BreadcrumbService implements IBreadcrumbService {
        static $inject = ['$rootScope', '$location', '$timeout', 'securityService'];

        constructor(private $rootScope: ng.IScope,
            private $location: ng.ILocationService,
            private $timeout: ng.ITimeoutService,
            private securityService: ISecurityService) {

            this.allSteps = [
                new BreadcrumbStep('Home', '/home', null, true),
                new BreadcrumbStep('Register', '/account/register', 'Home', true),
                new BreadcrumbStep('Login', '/account/login', 'Home', true),
                new BreadcrumbStep('Manage', '/manage', 'Home'),
                new BreadcrumbStep('Password', '/manage/password', 'Manage'),
                new BreadcrumbStep('User List', '/user', 'Manage'),
                new BreadcrumbStep('User Detail', '/user/edit/:userId', 'User List'),
                new BreadcrumbStep('API Help', '/help', 'Home', true),
                new BreadcrumbStep('API', '/help/api/:apiId', 'API Help', true),
                new BreadcrumbStep('Resouce Model', '/help/resourceModel', 'API Help', true),
                new BreadcrumbStep('Error', '/error', 'Home', true),
                new BreadcrumbStep('Not Found', '/error/404', 'Home', true)
            ];
            this.steps = [];
            this.label = new BreadcrumbLable();

            this.initEvents();
        }

        allSteps: BreadcrumbStep[];
        steps: BreadcrumbStep[];
        label: BreadcrumbLable;

        setLabel(text: string): void {
            this.label.text = text;
        }

        private initEvents(): void {
            this.$rootScope.$on('$routeChangeStart', (event, next, current) => {
                // reset label
                this.label.oldText = this.label.text;
                this.label.text = null;

                // passthrough authenticated user
                if (this.securityService.currentUser.isAuthenticated) return;

                // check if required authorization
                if (!next.$$route) return;
                var nextPath = next.$$route.originalPath;
                var nextStep = this.getByPath(nextPath);
                if (nextStep && !nextStep.allowAnonymous) {
                    event.preventDefault();

                    // redirect to login page with return url
                    this.$location.url('/account/login?returnUrl=' + this.$location.path());
                }
            });

            this.$rootScope.$on('$routeChangeSuccess', (event, current, previous) => {
                if (!current.$$route) return;
                var currentPath = current.$$route.originalPath;
                var currentStep = this.getByPath(currentPath);

                if (this.steps[this.steps.length - 1] !== currentStep) {
                    // update current steps
                    this.steps.length = 0;
                    var nextStepName = currentStep.name;
                    while (nextStepName) {
                        const nextStep = this.getByName(nextStepName);
                        this.steps.splice(0, 0, nextStep);
                        nextStepName = nextStep.parent;
                    }
                } else {
                    // note: if old steps are the same with new steps, breadcrumb ui won't get refresh
                    // but label of current step may be changed which requires ui fresh, so:
                    if (this.label.oldText !== this.label.text) {
                        var lastStep = this.steps.pop();
                        this.$timeout(() => {
                            this.steps.push(lastStep);
                        });
                    }
                }
            });
        }

        private getByName(name: string): BreadcrumbStep {
            if (!name) return null;
            const index = this.allSteps.map(step => step.name).indexOf(name);
            return this.allSteps[index];
        }

        private getByPath(path: string): BreadcrumbStep {
            if (!path) return null;
            var index = this.allSteps.map(step => step.path).indexOf(path);
            return this.allSteps[index];
        }
    }

    angular
        .module('bsApp')
        .service('breadcrumbService', BreadcrumbService);
}