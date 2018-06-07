(function () {
  'use strict';

  angular.module('FMI-Cazare.pages.session.addRoomsModal')
    .controller('addRoomsModalCtrl', addRoomsModalCtrl);

  function addRoomsModalCtrl($scope, $uibModalInstance, toastr) {
    $scope.dorm = $scope.$resolve.items;
    $scope.data;
    $scope.ok = function (data) {
      data.dormId = $scope.dorm.dormId;
      $uibModalInstance.close(data);
    };

    $scope.cancel = function () {
      $uibModalInstance.close();
    };
  }

})();