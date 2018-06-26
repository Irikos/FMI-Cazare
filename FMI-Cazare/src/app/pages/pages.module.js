/**
 * @author v.lugovsky
 * created on 16.12.2015
 */
(function () {
  'use strict';

  angular.module('FMI-Cazare.pages', [
    'ui.router',

    'FMI-Cazare.pages.dashboard',
    'FMI-Cazare.pages.session',
    'FMI-Cazare.pages.profile',
    'FMI-Cazare.pages.studentTimeline',
    'FMI-Cazare.pages.studentForm',
    'FMI-Cazare.pages.managementTable',
  ])
      .config(routeConfig);

  /** @ngInject */
  function routeConfig($urlRouterProvider, $locationProvider, baSidebarServiceProvider) {
    $locationProvider.html5Mode(true);
    $urlRouterProvider.otherwise('/dashboard');
    $httpProvider.interceptors.push(httpInterceptor);
  }

  /** @ngInject */
  function httpInterceptor($q, $localStorage, $location) {
    return {
      'responseError': function (rejection) {
        if (rejection.status === 401 && $location.path() != '/login') {
          delete $localStorage.token;
          $location.path('/login');
        }
        return $q.reject(rejection);
      }
    };
  }

})();
