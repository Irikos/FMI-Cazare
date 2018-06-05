(function () {
  'use strict';

  angular.module('FMI-Cazare.pages.session')
    .controller('SessionCtrl', SessionCtrl);

  function SessionCtrl($scope) {
    var vm = this;
    $scope.dates;
    $scope.session = {};

    $scope.session.dateStartOpen = openStart;
    $scope.session.dateStartOpened = false;
    function openStart() {
      $scope.session.dateStartOpened = true;
    }


    $scope.options = {
      showWeeks: false
    };

    $scope.format = 'dd.MM.yyyy';
    $scope.options = {
      showWeeks: false
    };

    $scope.dt = new Date();
    $scope.options = {
      showWeeks: false
    };
    $scope.open = open;
    $scope.opened = false;
    $scope.format = 'dd.MM.yyyy';
    $scope.options = {
      showWeeks: false
    };

    function open() {
      $scope.opened = true;
    }

  };


})();