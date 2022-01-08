(function () {
    'use strict';

    var controllerId = 'registrations';

    // TODO: replace app with your module name
    angular.module('csbc').controller(controllerId,
        ['common', 'datacontext', registrations]);

    function registrations(common, datacontext) {
        var vm = this;
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);
        vm.activate = activate;
        vm.registrations = [];
        vm.title = 'Registrations';

        function activate() {
            common.activateController( [getRegistrations()], controllerId)
                .then(function () { log('Activated Registrations View'); });
        }
        function getRegistrations() {
            return datacontext.getRegistrationPartials().then(function (data) {
                return vm.Registrations = data;

            });
        }
    }
})();
