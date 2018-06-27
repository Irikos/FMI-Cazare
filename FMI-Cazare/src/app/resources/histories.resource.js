(function () {
  'use strict';

  angular.module('FMI-Cazare.resources')
    .factory('Histories', Histories);

  function Histories($resource) {
    return $resource('/api/Histories/:id');
  }

})();