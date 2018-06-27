(function () {
    'use strict';

    angular.module('FMI-Cazare')
        .factory('Documents', Documents);

    function Documents($resource) {
        return $resource('/api/Documents/:id'); 
    }

})();