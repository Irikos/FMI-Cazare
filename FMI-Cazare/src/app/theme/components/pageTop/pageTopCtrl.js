/**
 * @author v.lugovksy
 * created on 12.10.2017
 */
(function () {
  'use strict';

  angular.module('FMI-Cazare.theme.components')
    .controller('PageTopCtrl', PageTopCtrl);

  /** @ngInject */
  function PageTopCtrl($scope, $http, Auth) {
    $scope.Auth = Auth;
  }

})();