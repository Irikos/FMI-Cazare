(function () {
  'use strict';

  angular.module('FMI-Cazare.resources')
    .factory('RoomatePreferences', RoomatePreferences);

  function RoomatePreferences($resource) {
    return $resource('/api/RoomatePreferences/:id');
  }

})();