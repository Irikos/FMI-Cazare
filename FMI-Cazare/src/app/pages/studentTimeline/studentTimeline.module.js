(function () {
  'use strict';

  angular.module('FMI-Cazare.pages.studentTimeline', [])
    .config(routeConfig);

  function routeConfig($stateProvider) {
    $stateProvider
      .state('studentTimeline', {
        url: '/studentTimeline',
        templateUrl: 'app/pages/studentTimeline/studentTimeline.html',
        controller: 'StudentTimelineCtrl',
        controllerAs: 'vm',
        title: 'Timeline',
        sidebarMeta: {
          icon: 'fa fa-calendar',
          order: 10,
        },
      })
  }
})(); 