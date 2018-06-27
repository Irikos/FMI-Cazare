(function () {
  'use strict';

  angular.module('FMI-Cazare.resources')
    .factory('Sessions', Sessions);

  function Sessions($resource) {
    return $resource('/api/Sessions/:id');
  }

})();