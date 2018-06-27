(function () {
    'use strict';

    angular.module('FMI-Cazare')
        .factory('Messages', Messages);

    function Messages($resource) {
        return $resource('/api/Messages/:id'); 
    }

})();