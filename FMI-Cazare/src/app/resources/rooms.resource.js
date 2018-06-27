(function () {
  'use strict';

  angular.module('FMI-Cazare.resources')
    .factory('Rooms', Rooms);

  function Rooms($resource) {
    return $resource('/api/Rooms/:id');
  }

})();