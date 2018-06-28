(function () {
  'use strict';

  angular.module('FMI-Cazare.pages.managementTable')
    .controller('ManagementTableCtrl', ManagementTableCtrl);

  function ManagementTableCtrl($scope, toastr, editableOptions, editableThemes, $uibModal,Forms) {
    editableOptions.theme = 'bs3';
    editableThemes['bs3'].submitTpl = '<button type="submit" class="btn btn-primary btn-with-icon"><i class="ion-checkmark-round"></i></button>';
    editableThemes['bs3'].cancelTpl = '<button type="button" ng-click="$form.$cancel()" class="btn btn-default btn-with-icon"><i class="ion-close-round"></i></button>';

    var vm = this;

  
    $scope.test = "Hello, world!";

    $scope.forms = Forms.query(function (a) {
      $scope.forms = $scope.forms.filter(f => f.state >= 2);
      $scope.safeCopyForms = $scope.forms;
    });

    $scope.getFormClass = function (form) {
      switch (form.state) {
        case 2:
          return 'primary';
          break;
        case 3:
          return 'success';
          break;
        case 4:
          return 'danger';
          break;
        default:
          return 'warning';
          break;
      }
    }

    $scope.viewStudentModal = function (page, size, form) {
      var modalInstance = $uibModal.open({
        animation: true,
        scope: $scope,
        templateUrl: page,
        controller: 'StudentFormModalCtrl',
        size: size,
        resolve: {
          items: function () {
            return form;
          }
        }
      });

      modalInstance.result.then(function (form) {
        var index = $scope.forms.indexOf(form);
        $scope[index] = form;
      }, function () {
      });

    };

  }
})();