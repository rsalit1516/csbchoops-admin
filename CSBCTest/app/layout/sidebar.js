(function () { 
    'use strict';
    
    var controllerId = 'sidebar';
    angular
        .module('csbc')
        .controller(controllerId,
        ['$route', 'config', 'routes', sidebar]);

    function sidebar($route, config, routes) {
        var vm = this;

        vm.isCurrent = isCurrent;

        activate();

        function activate() {
            logSuccess('Hot Towel Angular loaded!', null, true);
            common.activateController([], controllerId);
        }

        function toggleSpinner(on) { vm.isBusy = on; }

        $rootScope.$on('$routeChangeStart',
            function (event, next, current) { toggleSpinner(true); }
        );

        $rootScope.$on(events.controllerActivateSuccess,
            function (data) { toggleSpinner(false); }
        );

        $rootScope.$on(events.spinnerToggle,
            function (data) { toggleSpinner(data.show); }
        );
    };
})();
