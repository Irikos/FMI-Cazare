(function () {
  'use strict';

  angular.module('FMI-Cazare.pages.managementTable')
    .controller('ManagementTableCtrl', ManagementTableCtrl);

  function ManagementTableCtrl($scope, toastr, editableOptions, editableThemes) {
    editableOptions.theme = 'bs3';
    editableThemes['bs3'].submitTpl = '<button type="submit" class="btn btn-primary btn-with-icon"><i class="ion-checkmark-round"></i></button>';
    editableThemes['bs3'].cancelTpl = '<button type="button" ng-click="$form.$cancel()" class="btn btn-default btn-with-icon"><i class="ion-close-round"></i></button>';

    var vm = this;

    $scope.safeCopyForms = $scope.forms;
    $scope.test = "Hello, world!";

    $scope.forms = [
      {
        "last_name": "Doe",
        "first_name": "John",
        "cnp": "1900234123959",
        "specialization": "Informatică",
        "message": "Menționez că voi aduce toate în original la secretariat.",
        "status": "acceptată",
        "class": "success"
      },
      {
        "last_name": "Moise",
        "first_name": "Roxana",
        "cnp": "2900234123959",
        "specialization": "CTI",
        "message": "Menționez că unele acte doveditoare nu s-au emis încă.",
        "status": "acceptată",
        "class": "success"
      },
      {
        "last_name": "Popescu",
        "first_name": "Vasile",
        "cnp": "189985365478",
        "specialization": "CTI",
        "message": "",
        "status": "neevaluată",
        "class": "primary"
      },
      {
        "last_name": "Iliescu",
        "first_name": "Ionel",
        "cnp": "189985365478",
        "specialization": "Matematică",
        "message": "",
        "status": "respinsă",
        "class": "danger"
      },
      {
        "last_name": "Popa",
        "first_name": "Raluca",
        "cnp": "289985365478",
        "specialization": "Matematică",
        "message": "",
        "status": "în așteptare",
        "class": "warning"
      }
    ];


  }
})();