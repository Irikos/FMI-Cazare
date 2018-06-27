(function () {
    'use strict';

    angular.module('FMI-Cazare')
        .factory('DormPreferences', DormPreferences);

    function DormPreferences($resource) {
        return $resource('/api/DormPreferences/:id'); 
    }

})();