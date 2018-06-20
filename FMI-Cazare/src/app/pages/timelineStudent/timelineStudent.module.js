(function () {
  'use strict';

  angular.module('FMI-Cazare.pages.timelineStudent', [])
    .config(routeConfig);

  function routeConfig($stateProvider) {
    $stateProvider
      .state('timelineStudent', {
        url: '/timelineStudent',
        templateUrl: 'app/pages/timelineStudent/timelineStudent.html',
        controller: 'TimelineStudentCtrl',
        controllerAs: 'vm',
        title: 'Timeline',
        sidebarMeta: {
          icon: 'fa fa-calendar',
          order: 10,
        },
      })
  }
})(); 