(function () {
    'use strict';

    angular.module('FMI-Cazare')
        .factory('DormCategories', DormCategories);

    function DormCategories($resource) {
        return $resource('/api/DormCategories/:id'); 
    }

})();