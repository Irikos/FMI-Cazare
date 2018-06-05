(function () {
  'use strict';

  angular.module('FMI-Cazare.pages.session')
    .controller('SessionCtrl', SessionCtrl);

  function SessionCtrl($scope) {
    var vm = this;
    $scope.dates;
    $scope.session = {};
    $scope.session.startDate = null;

  };


})();