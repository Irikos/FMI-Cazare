(function () {
  'use strict';

  angular.module('FMI-Cazare.resources')
    .factory('Messages', Messages);

  function Messages($resource) {
    return $resource('/api/Messages/:id');
  }

})();