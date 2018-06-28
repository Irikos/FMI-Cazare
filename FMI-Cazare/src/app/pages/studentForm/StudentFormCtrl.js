(function () {
  'use strict';

  angular.module('FMI-Cazare.pages.studentForm')
    .controller('StudentFormCtrl', StudentFormCtrl);

  function StudentFormCtrl($scope, toastr, editableOptions, editableThemes, baConfig, $filter, $state, Dorms, Forms, Users) {
    editableOptions.theme = 'bs3';
    editableThemes['bs3'].submitTpl = '<button type="submit" class="btn btn-primary btn-with-icon"><i class="ion-checkmark-round"></i></button>';
    editableThemes['bs3'].cancelTpl = '<button type="button" ng-click="$form.$cancel()" class="btn btn-default btn-with-icon"><i class="ion-close-round"></i></button>';

    var vm = this;
    $scope.test = "Hello, world!";

    $scope.student = {};
    $scope.student = Forms.get({ id: document.currentUser.userId }, function () {
      if ($scope.student.user == undefined)
        $scope.student.user = Users.get({ id: document.currentUser.userId }, function () {
          $scope.student.userId = $scope.student.user.userId;
          if ($scope.student.dormPreferences)
            $scope.student.dormPreferences.sort(function (a, b) { return a.priority > b.priority });
          $scope.dorms = Dorms.query(function (a) {
            if ($scope.student.dormPreferences)
              $scope.dorms = $scope.dorms.filter(d => $scope.student.dormPreferences.find(dormP => dormP.dormId == d.dormId) == null)
          });
        });
      else {
        if ($scope.student.dormPreferences)
          $scope.student.dormPreferences.sort(function (a, b) { return a.priority > b.priority });
        $scope.dorms = Dorms.query(function (a) {
          if ($scope.student.dormPreferences)
            $scope.dorms = $scope.dorms.filter(d => $scope.student.dormPreferences.find(dormP => dormP.dormId == d.dormId) == null)
        });
      }
    });

    $scope.transparent = baConfig.theme.blur;




    $scope.colleagueOptions = [];

    $scope.dormOptions = [];

    $scope.newOption = '';

    $scope.addDormOption = function (event, clickPlus) {
      if (vm.newOption == undefined) {
        toastr.error("Nu ati selectat niciun camin");
      }
      else {
        if (clickPlus || event.which === 13) {
          var parsedDorm = JSON.parse(vm.newOption);
          var obj = $filter('filter')($scope.dorms, { name: parsedDorm.name }, true)[0];
          var index = $scope.dorms.indexOf(obj);
          if (index == -1) {
            toastr.error("Nu ati selectat niciun camin");
          }
          else {
            if ($scope.student.dormPreferences == undefined)
              $scope.student.dormPreferences = [];
            $scope.student.dormPreferences.unshift({
              dorm: parsedDorm,
              dormId: parsedDorm.dormId
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
      $scope.student.state = 1;
      Forms.save($scope.student, function () {
        toastr.info("Cererea a fost salvată.");
        $state.go("studentTimeline");
      });
    };

    $scope.sendForm = function () {
      $scope.student.state = 2;
      Forms.save($scope.student, function () {
        toastr.success("Cererea a fost trimisă către secretariat.");
        $state.go("studentTimeline");
      });

    };

  }
})();