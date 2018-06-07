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
  ])
      .config(routeConfig);

  /** @ngInject */
  function routeConfig($urlRouterProvider, baSidebarServiceProvider) {
    $urlRouterProvider.otherwise('/dashboard');
  }

})();
