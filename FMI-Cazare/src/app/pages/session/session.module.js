(function () {
  'use strict';

  angular.module('FMI-Cazare.pages.session', [])
    .config(routeConfig);

  function routeConfig($stateProvider) {
    $stateProvider
      .state('session', {
        url: '/session',
        templateUrl: 'app/pages/session/session.html',
        controller: 'SessionCtrl',
        controllerAs: 'vm', 
        title: 'Session',
        sidebarMeta: {
          icon: 'ion-android-home',
          order: 10,
        },
      })
  }
})(); 