
(function () {
    'use strict';

    var controllerId = 'WebContentCtrl';
    angular
      .module('csbc')
      .controller(controllerId, WebContentCtrl);

    WebContentCtrl.$inject = ['common', 'webContentResource'];

    function WebContentCtrl(common, webContentResource) {
        /* jshint validthis:true */
        var vm = this;
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        vm.title = 'Web Content';
        //vm.selectedContent = ShowsService.find($stateParams.id);
        vm.content = [];
        vm.contentTypes = [
            "Season Info",
            "Upcoming Events",
            "Meetings"
        ];
        webContentResource.query(function (data) {
            vm.content = data;
        });

        activate();

        function activate() {
            common.activateController([getWebContent()], controllerId)
               .then(function () {
                   log('Activated Content View');
               });
        }

        function getWebContent() {
            //return datacontext.getWebContent().then(function (data) {
            //    return vm.content = data;

            //});
        }

    }
})();
