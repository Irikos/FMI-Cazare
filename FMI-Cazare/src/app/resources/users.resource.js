(function () {
  'use strict';

  angular.module('FMI-Cazare.resources')
    .factory('Users', Users);

  function Users($resource) {
    return $resource('/api/Users/:id');
  }

})();