(function () {
  'use strict';

  angular.module('FMI-Cazare.resources')
    .factory('Forms', Forms);

  function Forms($resource) {
    return $resource('/api/Forms/:id');
  }

})();