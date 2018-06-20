(function () {
  'use strict';

  angular.module('FMI-Cazare.pages.studentForm')
    .controller('StudentFormCtrl', StudentFormCtrl);

  function StudentFormCtrl($scope, toastr, editableOptions, editableThemes) {
    editableOptions.theme = 'bs3';
    editableThemes['bs3'].submitTpl = '<button type="submit" class="btn btn-primary btn-with-icon"><i class="ion-checkmark-round"></i></button>';
    editableThemes['bs3'].cancelTpl = '<button type="button" ng-click="$form.$cancel()" class="btn btn-default btn-with-icon"><i class="ion-close-round"></i></button>';

    var vm = this;
    $scope.test = "Hello, world!";

    $scope.student = {
      "last_name": "Doe",
      "first_name": "John",
      "cnp": "1900121765292",
      "ic_serie": "TM",
      "ic_number": "050949",
      "birth_place": "Cluj-Napoca",
      "address": "Magheru 4",
      "father_first_name": "Vasile",
      "mother_first_name": "Lenuta",
      "email": "john.doe@fmi.unibuc.ro",
      "specialization": "Informatică",
      "year": "2",
      "gender": "masculin",
      "role": "student",

    };


  }
})();