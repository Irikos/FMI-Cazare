(function () {
  'use strict';

  angular.module('FMI-Cazare.pages.studentForm', [])
    .config(routeConfig);

  function routeConfig($stateProvider) {
    $stateProvider
      .state('studentForm', {
        url: '/studentForm',
        templateUrl: 'app/pages/studentForm/studentForm.html',
        controller: 'StudentFormCtrl',
        controllerAs: 'vm',
        title: 'Formularul de cazare',
        sidebarMeta: {
          icon: 'fa fa-plus-square',
          order: 20,
        },
      })
  }
})(); 