(function () {
  'use strict';

  angular.module('FMI-Cazare.pages.managementTable.studentFormModal')
    .controller('StudentFormModalCtrl', StudentFormModalCtrl);

  function StudentFormModalCtrl($scope, toastr, editableOptions, editableThemes, $uibModalInstance, Forms) {
    
    var vm = this;

    $scope.dormOptions = [
      {
        "name": "Kogalniceanu"
      },
      {
        "name": "Grozavesti"
      }
    ];
    $scope.student = $scope.$resolve.items;
    var index = $scope.forms.indexOf($scope.form);
    $scope.validate = function (form) {
      $scope.student.state = 3;
      Forms.save($scope.student, function () {
        toastr.success("Ai validat cererea cu succes.");
        $uibModalInstance.close(form);
      });
    };

    $scope.reject = function (form) {
      $scope.student.state = 4;
      Forms.save($scope.student, function () {
        toastr.info("Ai respins cererea cu succes.");
        $uibModalInstance.close(form);
      });

    };

    $scope.cancel = function () {
      $uibModalInstance.close();
    };

  }
})();