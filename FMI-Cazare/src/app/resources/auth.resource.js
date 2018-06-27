(function () {
  'use strict';

  angular.module('FMI-Cazare.resources')
    .factory('Auth', Auth);

  /** @ngInject */
  function Auth($resource) {
    function resourceErrorHandler(response) {
      document.location = '/login.html';
    }

    return $resource('api/Auth/:command', {}, {
      'me': {
        method: 'GET',
        transformResponse: function (data) {
          data = angular.fromJson(data);
          document.currentUser = data;
          return data;
        },
        interceptor: { responseError: resourceErrorHandler }
      },
      'logout': {
        method: 'GET',
        interceptor: { response: resourceErrorHandler, responseError: resourceErrorHandler }
      }
    });
  }

})();
