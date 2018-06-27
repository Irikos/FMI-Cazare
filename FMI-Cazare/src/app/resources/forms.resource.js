(function () {
    'use strict';

    angular.module('FMI-Cazare')
        .factory('Forms', Forms);

    function Forms($resource) {
        return $resource('/api/Forms/:id'); 
    }

})();