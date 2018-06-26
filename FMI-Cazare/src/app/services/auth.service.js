(function () {
  'use strict';

  angular.module('FMI-Cazare.services')
    .factory('AuthService', AuthService);

  function AuthService($http, $localStorage) {

    var service = {};

    service.Login = function (username, password, callback) {
      $http.post('/api/Auth', { username: username, password: password })
        .then(function (response) {
          if (response.data.token) {
            $localStorage.token = response.data.token;
            $http.defaults.headers.common.Authorization = 'Bearer ' + response.data.token;
            callback(true);
          } else {
            callback(false);
          }
        }, function () {
          callback(false);
        });
    };

    service.Logout = function () {
      delete $localStorage.token;
      $http.defaults.headers.common.Authorization = '';
    };

    service.Check = function (callback) {
      if (!$localStorage.token) {
        callback(false);
      }
      else {
        $http.defaults.headers.common.Authorization = 'Bearer ' + $localStorage.token;
        $http.get('/api/Auth')
          .then(function () {
            callback(true);
          }, function () {
            delete $localStorage.token;
            $http.defaults.headers.common.Authorization = '';
            callback(false);
          });
      }
    };

    return service;

  }

})();