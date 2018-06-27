(function () {
  'use strict';

  angular.module('FMI-Cazare.pages.studentForm')
    .controller('StudentFormCtrl', StudentFormCtrl);

  function StudentFormCtrl($scope, toastr, editableOptions, editableThemes, baConfig, $filter, $state, Dorms) {
    editableOptions.theme = 'bs3';
    editableThemes['bs3'].submitTpl = '<button type="submit" class="btn btn-primary btn-with-icon"><i class="ion-checkmark-round"></i></button>';
    editableThemes['bs3'].cancelTpl = '<button type="button" ng-click="$form.$cancel()" class="btn btn-default btn-with-icon"><i class="ion-close-round"></i></button>';

    var vm = this;
    $scope.test = "Hello, world!";

    $scope.student = {
      "lastName": "Doe",
      "firstName": "John",
      "cnp": "1900121765292",
      "icSerie": "TM",
      "icNumber": "050949",
      "birthPlace": "Cluj-Napoca",
      "address": "Magheru 4",
      "fatherFirstName": "Vasile",
      "motherFirstName": "Lenuta",
      "email": "john.doe@fmi.unibuc.ro",
      "specialization": "Informatică",
      "year": "2",
      "gender": "masculin",
      "role": "student",
      "social": false,
      "socialincome": "",
      "continuity": false,
      "lastDorm": ""
    };

    $scope.transparent = baConfig.theme.blur;
      var entries = Dorms.query(function (a) {
          console.log(a);
      });

    $scope.dorms = [
      {
        "name": "Kogalniceanu"
      },
      {
        "name": "Grozavesti"
      }
    ];

    $scope.colleagueOptions = [];
    
    $scope.dormOptions = [];

    $scope.newOption = '';

    $scope.addDormOption = function (event, clickPlus) {
      if (vm.newOption == undefined) {
        toastr.error("Nu ati selectat niciun camin");
      }
      else {
        if (clickPlus || event.which === 13) {
          var obj = $filter('filter')($scope.dorms, { name: vm.newOption }, true)[0];
          var index = $scope.dorms.indexOf(obj);
          if (index == -1) {
            toastr.error("Nu ati selectat niciun camin");
          }
          else {
            $scope.dormOptions.unshift({
              name: vm.newOption,
            });
            $scope.dorms.splice(index, 1);
            $scope.newOption = '';
          }
        }
      }
    };


    $scope.deleteOption = function (option) {
      var index = $scope.dormOptions.indexOf(option);
      $scope.dormOptions.splice(index, 1);
      $scope.dorms.push(option);
    };

    $scope.addColleague = function (event, clickPlus) {
      if (clickPlus || event.which === 13) {
        $scope.colleagueOptions.push({
          name: vm.newColleague,
        });
        $scope.newColleague = '';
      }
    };

    $scope.deleteColleague = function (option) {
      var index = $scope.colleagueOptions.indexOf(option);
      $scope.colleagueOptions.splice(index, 1);
    };

    $scope.test = function () {
      debugger;
      alert($scope.dorms);
      alert($scope.dormOptions);
    } 

    $scope.saveForm = function () {
      toastr.info("Cererea a fost salvată.");
      $state.go("studentTimeline");
    };

    $scope.sendForm = function () {
      toastr.success("Cererea a fost trimisă către secretariat.");
      $state.go("studentTimeline");
    };

  }
})();