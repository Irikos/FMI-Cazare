(function () {
  'use strict';

  angular.module('FMI-Cazare.pages.session')
    .controller('SessionCtrl', SessionCtrl);

  function SessionCtrl($scope, $uibModal, $filter, $timeout, toastr, editableOptions, editableThemes) {
    editableOptions.theme = 'bs3';
    editableThemes['bs3'].submitTpl = '<button type="submit" class="btn btn-primary btn-with-icon"><i class="ion-checkmark-round"></i></button>';
    editableThemes['bs3'].cancelTpl = '<button type="button" ng-click="$form.$cancel()" class="btn btn-default btn-with-icon"><i class="ion-close-round"></i></button>';

    var vm = this;
    $scope.safeCopyDorms = $scope.dorms;
    $scope.safeCopyRooms = $scope.rooms;
    $scope.dates;
    $scope.session = {
      "status": "începută",
    };
    $scope.session.startDate = null;
    $scope.filteredByCategory = [];


    var newId = 0;
    $scope.ignoreChanges = false;
    $scope.newNode = {};
    $scope.basicConfig = {
      core: {
        multiple: false,
        check_callback: true,
        worker: true
      },
      'types': {
        'folder': {
          'icon': 'ion-ios-folder'
        },
        'default': {
          'icon': 'ion-document-text'
        }
      },
      'plugins': ['types'],
      'version': 1
    };

    $scope.refresh = function () {
      $scope.ignoreChanges = true;
      newId = 0;
      $scope.treeData = getDefaultData();
      $scope.basicConfig.version++;
    };

    $scope.expand = function () {
      $scope.ignoreChanges = true;
      $scope.treeData.forEach(function (n) {
        n.state.opened = true;
      });
      $scope.basicConfig.version++;
    };

    $scope.collapse = function () {
      $scope.ignoreChanges = true;
      $scope.treeData.forEach(function (n) {
        n.state.opened = false;
      });
      $scope.basicConfig.version++;
    };

    $scope.readyCB = function () {
      $timeout(function () {
        $scope.ignoreChanges = false;
      });
    };

    $scope.applyModelChanges = function () {
      return !$scope.ignoreChanges;
    };
    $scope.filterByCategory = function () {
      var data = [];

      angular.forEach($scope.dormCategories, function (category, key) {
        var categoryes = [];
        categoryes.push({
          "id": "cat" + category.categoryId,
          "parent": "#",
          "text": category.name,
          "icon": "fa fa-cubes",
          "state": {
            "opened": true
          }
        });
        angular.forEach($scope.dorms, function (dorm, key) {
          if (dorm.dormCategoryId == category.categoryId) {
            categoryes.push({
              "id": "dorm" + dorm.dormId,
              "parent": "cat" + dorm.dormCategoryId,
              "text": dorm.name,
              "icon": "fa fa-building",
              "state": {
                "opened": true,
              }
            });
            angular.forEach($scope.rooms, function (value, key) {
              if (value.dormId == dorm.dormId)
                categoryes.push({
                  "id": "room" + value.roomId,
                  "parent": "dorm" + value.dormId,
                  "text": value.roomNumber,
                  "icon": "fa fa-map-marker",
                  "state": {
                    "opened": true,
                  }
                })
            });
          }
        });


        data.push(categoryes);
      });
      $scope.filteredByCategory = data;
    }


    function getDefaultData() {

      $scope.data = [];

      angular.forEach($scope.dormCategories, function (value, key) {
        $scope.data.push({
          "id": "cat" + value.categoryId,
          "parent": "#",
          "text": value.name,
          "icon": "fa fa-cubes",
          "state": {
            "opened": true
          }
        })
      });

      angular.forEach($scope.dorms, function (value, key) {
        $scope.data.push({
          "id": "dorm" + value.dormId,
          "parent": "cat" + value.dormCategoryId,
          "text": value.name,
          "icon": "fa fa-building",
          "state": {
            "opened": true,
          }
        })
      });

      angular.forEach($scope.rooms, function (value, key) {
        $scope.data.push({
          "id": "room" + value.roomId,
          "parent": "dorm" + value.dormId,
          "text": value.roomNumber,
          "icon": "fa fa-map-marker",
          "state": {
            "opened": true,
          }
        })
      });

      $scope.filterByCategory();

      return $scope.data;
    };
    // end treeview

    $scope.dormCategories = [
      {
        "categoryId": 1,
        "name": "A",
        "value": 2,
        "description": "In curtea facultatii de drept"
      },
      {
        "categoryId": 2,
        "name": "B",
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

    $scope.treeData = getDefaultData();

    $scope.addDormCategory = function () {
      var categoryId = $scope.dormCategories.length ? $scope.dormCategories[$scope.dormCategories.length - 1].categoryId + 1 : 1;
      $scope.newCategory = {
        "categoryId": categoryId,
        "name": null,
        "value": null,
        "description": null
      };
      $scope.dormCategories.push($scope.newCategory);
    }

    $scope.removeDormCategory = function (dormCategory) {
      var index = $scope.dormCategories.indexOf(dormCategory);
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
      var dormId = $scope.dorms.length ? $scope.dorms[$scope.dorms.length - 1].dormId + 1 : 1;
      $scope.newDorm = {
        "dormId": dormId,
        "name": null,
        "dormCategoryId": null
      }
      $scope.dorms.push($scope.newDorm);
    }

    $scope.removeDorm = function (dorm) {
      var index = $scope.dorms.indexOf(dorm)
      $scope.dorms.splice(index, 1);
    }

    $scope.getRoomsByDorm = function (dorm) {
      var selected = $filter('filter')($scope.rooms, { dormId: dorm.dormId });
      return selected.length ? selected : [];
    }

    $scope.addRoom = function (dorm) {
      var roomId = $scope.rooms.length ? $scope.rooms[$scope.rooms.length - 1].roomId + 1 : 1;
      $scope.newRoom = {
        "roomId": roomId,
        "roomNumber": null,
        "size": null,
        "dormId": dorm.dormId,
        "sex": null,
      }
      $scope.rooms.push($scope.newRoom);
      $scope.refresh();
    }

    /*  check if:
     *  - room exists
     *  - dorm exists
     *  - start < end
     *  - size > 0
     * */
    $scope.bulkAddRooms = function (startNumber, endNumber, sex, size, dormId) {
      for (var i = startNumber; i <= endNumber; i++) {
        var roomId = $scope.rooms.length ? $scope.rooms[$scope.rooms.length - 1].roomId + 1 : 1;
        var newRoom = {
          "roomId": roomId,
          "roomNumber": i,
          "size": size,
          "dormId": dormId,
          "sex": sex,
        }
        $scope.rooms.push(newRoom);
        $scope.refresh();
      }
    }

    $scope.removeRoom = function (room) {
      var index = $scope.rooms.indexOf(room);
      $scope.rooms.splice(index, 1);
    }

    $scope.addRoomsModal = function (dorm) {
      var modalInstance = $uibModal.open({
        animation: true,
        scope: $scope,
        templateUrl: 'app/pages/session/widgets/addRoomsModal/addRoomsModal.html',
        controller: 'addRoomsModalCtrl',
        size: 'md',
        resolve: {
          items: function () {
            return dorm;
          }
        }
      }).result.then(function (data) {
        $scope.bulkAddRooms(data.startNumber, data.endNumber, data.sex, data.size, data.dormId);
      });
    };

    $scope.submitSession = function () {
      $scope.session.status = "salvată";
      toastr.success("Sesiunea a fost salvată.")
    }
  };


})();