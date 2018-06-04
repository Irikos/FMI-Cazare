/**
 * @author k.danovsky
 * created on 12.01.2016
 */
(function () {
  'use strict';

  angular.module('Fmi-Cazare.pages.ui', [
    'Fmi-Cazare.pages.ui.typography',
    'Fmi-Cazare.pages.ui.buttons',
    'Fmi-Cazare.pages.ui.icons',
    'Fmi-Cazare.pages.ui.modals',
    'Fmi-Cazare.pages.ui.grid',
    'Fmi-Cazare.pages.ui.alerts',
    'Fmi-Cazare.pages.ui.progressBars',
    'Fmi-Cazare.pages.ui.notifications',
    'Fmi-Cazare.pages.ui.tabs',
    'Fmi-Cazare.pages.ui.slider',
    'Fmi-Cazare.pages.ui.panels',
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
