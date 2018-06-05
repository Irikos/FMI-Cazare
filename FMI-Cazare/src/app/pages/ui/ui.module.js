/**
 * @author k.danovsky
 * created on 12.01.2016
 */
(function () {
  'use strict';

  angular.module('FMI-Cazare.pages.ui', [
    'FMI-Cazare.pages.ui.typography',
    'FMI-Cazare.pages.ui.buttons',
    'FMI-Cazare.pages.ui.icons',
    'FMI-Cazare.pages.ui.modals',
    'FMI-Cazare.pages.ui.grid',
    'FMI-Cazare.pages.ui.alerts',
    'FMI-Cazare.pages.ui.progressBars',
    'FMI-Cazare.pages.ui.notifications',
    'FMI-Cazare.pages.ui.tabs',
    'FMI-Cazare.pages.ui.slider',
    'FMI-Cazare.pages.ui.panels',
  ])
      .config(routeConfig);

  /** @ngInject */
  function routeConfig($stateProvider) {
    $stateProvider
        .state('ui', {
          url: '/ui',
          template : '<ui-view  autoscroll="true" autoscroll-body-top></ui-view>',
          abstract: true,
          title: 'UI Features',
          sidebarMeta: {
            icon: 'ion-android-laptop',
            order: 200,
          },
        });
  }

})();
