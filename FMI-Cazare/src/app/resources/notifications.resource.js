(function () {
  'use strict';

  angular.module('FMI-Cazare.resources')
    .factory('Notifications', Notifications);

  function Notifications($resource) {
    return $resource('/api/Notifications/:id');
  }

})();