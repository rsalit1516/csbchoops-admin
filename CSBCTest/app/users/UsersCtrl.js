
(function () {
    'use strict';

    angular
      .module('csbc')
      .controller('UserCtrl', UserCtrl);

    UserCtrl.$inject = ['$scope'];

    function UserCtrl($scope) {
        /* jshint validthis:true */
        var vm = this;

        vm.title = 'Users';

        activate();

        function activate() { }
    }
})();
