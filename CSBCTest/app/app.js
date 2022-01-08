(function () {
    'use strict';
    
    var csbc = angular.module('csbc', [
        // Angular modules 
        'ngAnimate',        // animations
        'ui.router',          // routing
        'ngSanitize',       // sanitizes html bindings (ex: sidebar.js)

        // Custom modules 
        'common',           // common functions, logger, spinner
        'common.bootstrap', // bootstrap dialog wrapper functions

        // 3rd Party Modules
        'ui.bootstrap',      // ui-bootstrap (ex: carousel, pagination, dialog)

        "common.service"
    ]);
    
    // Handle routing errors and success events
    //csbc.run(['$route', '$routeScope', '$q', 'datacontext',
    //    function ($route, $routeScope, $q, datacontext) {
    //    // Include $route to kick start the router.
    //        //breeze.core.extendQ($routeScope, $q);
    //        datacontext.prime();
    //    }]);        
})();