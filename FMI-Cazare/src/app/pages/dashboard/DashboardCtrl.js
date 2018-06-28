(function () {
  'use strict';

  angular.module('FMI-Cazare.pages.dashboard')
    .controller('DashboardCtrl', DashboardCtrl);

  function DashboardCtrl($scope, toastr, editableOptions, editableThemes, $uibModal, Forms, $state) {
    editableOptions.theme = 'bs3';
    editableThemes['bs3'].submitTpl = '<button type="submit" class="btn btn-primary btn-with-icon"><i class="ion-checkmark-round"></i></button>';
    editableThemes['bs3'].cancelTpl = '<button type="button" ng-click="$form.$cancel()" class="btn btn-default btn-with-icon"><i class="ion-close-round"></i></button>';

    var vm = this;
    if (document.currentUser.role == 1) {
      setTimeout(function () { $state.go('session'); }, 500);
    }
    else if (document.currentUser.role == 3) {
      setTimeout(function () { $state.go('studentTimeline'); }, 500);
    }
    else if (document.currentUser.role == 2) {
      setTimeout(function () { $state.go('managementTable'); }, 500);
    }
  }
})();