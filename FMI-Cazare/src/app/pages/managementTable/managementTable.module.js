(function () {
  'use strict';

  angular.module('FMI-Cazare.pages.managementTable', [])
    .config(routeConfig);

  function routeConfig($stateProvider) {
    $stateProvider
      .state('managementTable', {
        url: '/managementTable',
        templateUrl: 'app/pages/managementTable/managementTable.html',
        controller: 'ManagementTableCtrl',
        controllerAs: 'vm',
        title: 'Lista cererilor de cazare',
        sidebarMeta: {
          icon: 'fa fa-list-ol',
          order: 30,
        },
      })
  }
})(); 