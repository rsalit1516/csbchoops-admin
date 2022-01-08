(function () {
    "use strict";

    angular
        .module("common.services")
        .factory(webContentResource, ["$resource", "appSettings", webContentResource])

    function webContentResource($resource, appSettings) {
        return $resource(appSettings.serverPath + "/api/webContent/:id");
    }

}());