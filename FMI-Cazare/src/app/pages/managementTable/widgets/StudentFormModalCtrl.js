(function () {
  'use strict';

  angular.module('FMI-Cazare.pages.managementTable.studentFormModal')
    .controller('StudentFormModalCtrl', StudentFormModalCtrl);

  function StudentFormModalCtrl($scope, toastr, editableOptions, editableThemes, $uibModalInstance) {
    
    var vm = this;

    $scope.dormOptions = [
      {
        "name": "Kogalniceanu"
      },
      {
        "name": "Grozavesti"
      }
    ];
    $scope.form = $scope.$resolve.items;
    var index = $scope.forms.indexOf($scope.form);
    $scope.validate = function (form) {
      form.status = "acceptată";
      form.class = "success";
      toastr.success("Ai validat cererea cu succes.");
      $uibModalInstance.close(form);
    };

    $scope.reject = function (form) {
      form.status = "respinsă";
      form.class = "danger";
      toastr.info("Ai respins cererea cu succes.");
      $uibModalInstance.close(form);
    };

    $scope.cancel = function () {
      $uibModalInstance.close();
    };

  }
})();