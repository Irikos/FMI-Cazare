(function () {
    'use strict';

    angular.module('FMI-Cazare')
        .factory('Notifications', Notifications);

    function Notifications($resource) {
        return $resource('/api/Notifications/:id'); 
    }

})();