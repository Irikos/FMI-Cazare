(function () {
  'use strict';

  angular.module('FMI-Cazare.pages.managementTable.studentFormModal')
    .controller('StudentFormModalCtrl', StudentFormModalCtrl);

  function StudentFormModalCtrl($scope, toastr, editableOptions, editableThemes, $uibModalInstance) {
    
    var vm = this;

    $scope.form = $scope.$resolve.items;
    var index = $scope.forms.indexOf($scope.form);
    $scope.validate = function (form) {
      form.status = "acceptată";
      form.class = "success";
      toastr.success("Ai validat cu succes cererea.");
      $uibModalInstance.close(form);
    };

    $scope.reject = function (form) {
      form.status = "respinsă";
      form.class = "danger";
      toastr.warning("Ai respins cu succes cererea.");
      $uibModalInstance.close(form);
    };

    $scope.cancel = function () {
      $uibModalInstance.close();
    };

  }
})();