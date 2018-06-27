(function () {
  'use strict';

  angular.module('FMI-Cazare.resources')
    .factory('Documents', Documents);

  function Documents($resource) {
    return $resource('api/Documents/:documentId');
  }

})();