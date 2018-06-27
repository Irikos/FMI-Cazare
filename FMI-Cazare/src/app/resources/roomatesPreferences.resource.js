(function () {
    'use strict';

    angular.module('FMI-Cazare')
        .factory('RoomatePreferences', RoomatePreferences);

    function RoomatePreferences($resource) {
        return $resource('/api/RoomatePreferences/:id'); 
    }

})();