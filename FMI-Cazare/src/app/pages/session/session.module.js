(function () {
  'use strict';

  angular.module('FMI-Cazare.pages.session', [
    'FMI-Cazare.pages.session.dormModal'
  ])
    .config(routeConfig);

  function routeConfig($stateProvider) {
    $stateProvider
      .state('session', {
        url: '/session',
        templateUrl: 'app/pages/session/session.html',
        controller: 'SessionCtrl',
        controllerAs: 'vm', 
        title: 'Creează o sesiune',
        sidebarMeta: {
          icon: 'fa fa-plus-square',
          order: 10,
        },
      })
  }
})(); 