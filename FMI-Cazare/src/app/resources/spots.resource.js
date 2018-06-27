(function () {
    'use strict';

    angular.module('FMI-Cazare')
        .factory('Spots', Spots);

    function Spots($resource) {
        return $resource('/api/Spots/:id'); 
    }

})();