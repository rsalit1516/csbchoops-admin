
(function () {
    'use strict';

    var controllerId = 'WebContentSummaryCtrl';
    angular
      .module('csbc')
      .controller(controllerId, WebContentSummaryCtrl);

    WebContentSummaryCtrl.$inject = ['common', 'datacontext', 'webContentResource', '$modal', '$location'];

    function WebContentSummaryCtrl(common, datacontext, webContentResource, $modal, $location) {
        /* jshint validthis:true */
        var vm = this;

        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);
        vm.content = [];
        vm.title = 'Web Content';
        vm.showCreateWebContentForm = showCreateWebContentForm;

        //webContentResource.query(function (data) {
        //    vm.content = data;
        //});

        activate();

        function activate() {
            common.activateController([getWebSummaryContent()], controllerId)
               .then(function () {
                   log('Activated Content Summary View');
               });
        }

        function getWebSummaryContent() {
            //    return datacontext.getWebContent().then(function (data) {
            //        return vm.content = data;


            //    });
            //}
            webContentResource.query(function (data) {
                vm.content = data;
            });
        }
        function showCreateWebContentForm() {
            //$location.path('/newEmployeeForm');

            $modal.open({
                templateUrl: 'app/webContent/webContent.html',
                controller: 'WebContentCtrl',
                controllerAs : 'vm'
            });

        };

    }
})();
