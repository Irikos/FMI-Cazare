/**
 * @author v.lugovksy
 * created on 16.12.2015
 */
(function () {
  'use strict';

  angular.module('FMI-Cazare.theme.components')
    .controller('BaSidebarCtrl', BaSidebarCtrl);

  /** @ngInject */
  function BaSidebarCtrl($scope, baSidebarService, Auth) {

    $scope.menuItems = baSidebarService.getMenuItems();
    if (document.currentUser.role == 1) {
      $scope.menuItems = $scope.menuItems.slice(0, 2);
    }
    else if (document.currentUser.role == 2) {
      $scope.menuItems.splice(1, 3);
    }
    else if (document.currentUser.role == 3) {
      $scope.menuItems.splice(1, 1);
      $scope.menuItems.splice(3, 1);
    }

    $scope.defaultSidebarState = $scope.menuItems[0].stateRef;

    $scope.hoverItem = function ($event) {
      $scope.showHoverElem = true;
      $scope.hoverElemHeight =  $event.currentTarget.clientHeight;
      var menuTopValue = 66;
      $scope.hoverElemTop = $event.currentTarget.getBoundingClientRect().top - menuTopValue;
    };

    $scope.$on('$stateChangeSuccess', function () {
      if (baSidebarService.canSidebarBeHidden()) {
        baSidebarService.setMenuCollapsed(true);
      }
    });
  }
})();