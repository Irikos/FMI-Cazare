(function () {
  'use strict';

  angular.module('FMI-Cazare.pages.session')
    .controller('SessionCtrl', SessionCtrl);

  function SessionCtrl($scope, $uibModal, $filter, toastr, editableOptions, editableThemes) {
    editableOptions.theme = 'bs3';
    editableThemes['bs3'].submitTpl = '<button type="submit" class="btn btn-primary btn-with-icon"><i class="ion-checkmark-round"></i></button>';
    editableThemes['bs3'].cancelTpl = '<button type="button" ng-click="$form.$cancel()" class="btn btn-default btn-with-icon"><i class="ion-close-round"></i></button>';

    var vm = this;
    $scope.safeCopyDorms = $scope.dorms;
    $scope.safeCopyRooms = $scope.rooms;
    $scope.dates;
    $scope.session = {};
    $scope.session.startDate = null;

    $scope.dormCategories = [
      {
        "categoryId": 1,
        "name": "Kogalniceanu",
        "value": 2,
        "description": "In curtea facultatii de drept"
      },
      {
        "categoryId": 2,
        "name": "Grozavesti A2",
        "value": 2,
        "description": "Langa Carefour"
      },
    ];

    $scope.dorms = [
      {
        "dormId": 1,
        "name": "Grozavesti A1",
        "dormCategoryId": 1,
      },
      {
        "dormId": 2,
        "name": "Grozavesti A2",
        "dormCategoryId": 2,
      }
    ];

    $scope.rooms = [
      {
        "roomId": 1,
        "roomNumber": "120",
        "size": 3,
        "dormId": 1,
        "sex": "M",
      },
      {
        "roomId": 2,
        "roomNumber": "121",
        "size": 4,
        "dormId": 1,
        "sex": "F",
      },
      {
        "roomId": 3,
        "roomNumber": "220",
        "size": 4,
        "dormId": 2,
        "sex": "F",
      },
      {
        "roomId": 4,
        "roomNumber": "221",
        "size": 4,
        "dormId": 2,
        "sex": "M",
      },
    ];

    $scope.sexTypes = [
      {
        "id": 1,
        "name": "Masculin",
        "type": "M",
      },
      {
        "id": 2,
        "name": "Feminim",
        "type": "F"
      }];
    

    $scope.addDormCategory = function () {
      var categoryId = $scope.dormCategories[$scope.dormCategories.length - 1].categoryId + 1;
      var newCategory = {
        "categoryId": categoryId,
        "name": null,
        "value": null,
        "description": null
      };
      $scope.dormCategories.push(newCategory);
    }

    $scope.removeDormCategory = function (index) {
      $scope.dormCategories.splice(index, 1);
    }

    $scope.getDormCategory = function (dormCategoryId) {
      var selected = $filter('filter')($scope.dormCategories, { categoryId: dormCategoryId });
      return selected.length ? selected[0].name : '';
    }

    $scope.getRoomDorm = function (dormId) {
      var selected = $filter('filter')($scope.dorms, { dormId: dormId });
      return selected.length ? selected[0].name : '';
    }

    $scope.addDorm = function () {
      var dormId = $scope.dorms[$scope.dorms.length - 1].dormId + 1;
      var newDorm = {
        "dormId": dormId,
        "name": null,
        "dormCategoryId": null
      }
      $scope.dorms.push(newDorm);
    }

    $scope.removeDorm = function (index) {
      $scope.dorms.splice(index, 1);
    }

    $scope.getRoomsByDorm = function (dorm) {
      var selected = $filter('filter')($scope.rooms, { dormId: dorm.dormId });
      return selected.length ? selected : [];
    }

    $scope.addRoom = function (room) {
      $scope.push(room);
    }

    $scope.removeRoom = function (room) {
      var index = $scope.rooms.indexOf(rooms);
      $scope.rooms.splice(index, 1);
    }

    $scope.dormModal = function (dorm) {
      var modalInstance = $uibModal.open({
        animation: true,
        scope: $scope,
        templateUrl: 'app/pages/session/widgets/dormModal/dormModal.html',
        controller: 'DormModalCtrl',
        size: 'lg',
        resolve: {
          items: function () {
            return dorm;
          }
        }
      }).closed.then(function () {

      });
    };

  };


})();