
(function () {
    'use strict';

    var controllerId = 'WebContentSummaryCtrl';
    angular
      .module('csbc')
      .controller(controllerId, WebContentSummaryCtrl);

    WebContentSummaryCtrl.$inject = ['common', 'datacontext'];

    function WebContentSummaryCtrl(common, datacontext) {
        /* jshint validthis:true */
        var vm = this;

        vm.title = 'Web Content';

        vm.content = [];

        activate();

        function activate() {
            common.activateController([getWebSummaryContent()], controllerId)
               .then(function () {
                   log('Activated Content Summary View');
               });
        }

        function getWebSummaryContent() {
            return datacontext.getWebContent().then(function (data) {
                return vm.content = data;

            });
        }
    }
})();
