(function () {
  'use strict';

  angular.module('FMI-Cazare.pages.session')
    .controller('SessionCtrl', SessionCtrl);

  function SessionCtrl($scope, editableOptions, editableThemes) {
    editableOptions.theme = 'bs3';
    editableThemes['bs3'].submitTpl = '<button type="submit" class="btn btn-primary btn-with-icon"><i class="ion-checkmark-round"></i></button>';
    editableThemes['bs3'].cancelTpl = '<button type="button" ng-click="$form.$cancel()" class="btn btn-default btn-with-icon"><i class="ion-close-round"></i></button>';

    var vm = this;
    $scope.dates;
    $scope.session = {};
    $scope.session.startDate = null;

    $scope.dormCategories = [
      {
        "name": "Kogalniceanu",
        "value": 2,
        "description": "In curtea facultatii de drept"
      },
      {
        "name": "Grozavesti A2",
        "value": 2,
        "description": "Langa Carefour"
      },
    ];

    $scope.addDormCategory = function () {
      $scope.newCategory = {
        "name": null,
        "value": null,
        "description": null
      };
      $scope.dormCategories.push($scope.newCategory);
    }

    $scope.removeDormCategory = function (index) {
      $scope.dormCategories.splice(index, 1);
    }
  };


})();