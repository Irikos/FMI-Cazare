(function () {
    'use strict';

    angular.module('FMI-Cazare')
        .factory('Sessions', Sessions);

    function Sessions($resource) {
        return $resource('/api/Sessions/:id'); 
    }

})();