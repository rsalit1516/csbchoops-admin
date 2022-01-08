(function () {
    'use strict';
    var controllerId = 'people';
    angular.module('app').controller(controllerId, ['common', people]);

    function admin(common) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        var vm = this;
        vm.title = 'People';

        activate();

        function activate() {
            common.activateController([], controllerId)
                .then(function () { log('Activated People View'); });
        }
    }
})();