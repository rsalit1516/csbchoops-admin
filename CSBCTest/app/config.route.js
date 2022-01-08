(function () {
    'use strict';

    angular
        .module('csbc')
        .config(['$stateProvider', '$urlRouterProvider', config]);

    // Configure the routes and route resolvers

    function config($stateProvider, $urlRouterProvider) {

        $urlRouterProvider.otherwise('/home');
        $stateProvider

        .state('home', {
            url: '/',
            templateUrl: 'app/dashboard/dashboard.html'

        })
        .state('webContent', {
            url: '/webcontent',
            templateUrl: '/app/webcontent/webcontentsummary.html'
        })
            .state('webContent.edit', {
                url: '/edit/:id',
                templateUrl: '/app/webcontent/webcontent.html'
            })
        .state('users', {
            url: '/users',
            templateUrl: 'app/users/users.html'
        })
    }
})();