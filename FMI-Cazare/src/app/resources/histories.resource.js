(function () {
    'use strict';

    angular.module('FMI-Cazare')
        .factory('Histories', Histories);

    function Histories($resource) {
        return $resource('/api/Histories/:id'); 
    }

})();