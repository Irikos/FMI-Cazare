(function () {
  'use strict';

  angular.module('FMI-Cazare.resources')
    .factory('Dorms', Dorms);

  function Dorms($resource) {
    return $resource('/api/Dorms/:id');
  }

})();