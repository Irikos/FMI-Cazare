(function () {
  'use strict';

  angular.module('FMI-Cazare.pages.managementTable')
    .controller('ManagementTableCtrl', ManagementTableCtrl);

  function ManagementTableCtrl($scope, toastr, editableOptions, editableThemes, $uibModal) {
    editableOptions.theme = 'bs3';
    editableThemes['bs3'].submitTpl = '<button type="submit" class="btn btn-primary btn-with-icon"><i class="ion-checkmark-round"></i></button>';
    editableThemes['bs3'].cancelTpl = '<button type="button" ng-click="$form.$cancel()" class="btn btn-default btn-with-icon"><i class="ion-close-round"></i></button>';

    var vm = this;

    $scope.safeCopyForms = $scope.forms;
    $scope.test = "Hello, world!";

    $scope.forms = [
      {
        "id": "1",
        "lastName": "Doe",
        "firstName": "John",
        "cnp": "1900234123959",
        "specialization": "Informatică",
        "message": "Menționez că voi aduce toate în original la secretariat.",
        "status": "acceptată",
        "class": "success"
      },
      {
        "id": "2",
        "lastName": "Moise",
        "firstName": "Roxana",
        "cnp": "2900234123959",
        "specialization": "CTI",
        "message": "Menționez că unele acte doveditoare nu s-au emis încă.",
        "status": "acceptată",
        "class": "success"
      },
      {
        "id": "3",
        "lastName": "Popescu",
        "firstName": "Vasile",
        "cnp": "189985365478",
        "specialization": "CTI",
        "message": "",
        "status": "neevaluată",
        "class": "primary"
      },
      {
        "id": "4",
        "lastName": "Iliescu",
        "firstName": "Ionel",
        "cnp": "189985365478",
        "specialization": "Matematică",
        "message": "",
        "status": "respinsă",
        "class": "danger"
      },
      {
        "id": "5",
        "lastName": "Popa",
        "firstName": "Raluca",
        "cnp": "289985365478",
        "specialization": "Matematică",
        "message": "",
        "status": "în așteptare",
        "class": "warning"
      }
    ];
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