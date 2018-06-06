(function () {
  'use strict';

  angular.module('FMI-Cazare.pages.session.dormModal')
    .controller('DormModalCtrl', DormModalCtrl);

  function DormModalCtrl($scope, $uibModalInstance, toastr) {
    $scope.dorm = $scope.$resolve.items;
    $scope.ok = function () {

      toastr.success('C&#259;minul a fost salvat cu succes!', "", {
        "allowHtml": true,
      });
      $uibModalInstance.close();
    };

    $scope.cancel = function () {
      $uibModalInstance.close();
    };
  }

})();