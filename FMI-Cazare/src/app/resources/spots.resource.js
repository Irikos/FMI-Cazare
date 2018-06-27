(function () {
  'use strict';

  angular.module('FMI-Cazare.resources')
    .factory('Spots', Spots);

  function Spots($resource) {
    return $resource('/api/Spots/:id');
  }

})();