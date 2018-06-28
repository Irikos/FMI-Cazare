(function () {
  'use strict';

  angular.module('FMI-Cazare.pages.studentTimeline')
    .controller('StudentTimelineCtrl', StudentTimelineCtrl);

  function StudentTimelineCtrl($scope, $state, toastr, editableOptions, editableThemes, Forms, Users) {
    editableOptions.theme = 'bs3';
    editableThemes['bs3'].submitTpl = '<button type="submit" class="btn btn-primary btn-with-icon"><i class="ion-checkmark-round"></i></button>';
    editableThemes['bs3'].cancelTpl = '<button type="button" ng-click="$form.$cancel()" class="btn btn-default btn-with-icon"><i class="ion-close-round"></i></button>';

    var vm = this;
    $scope.test = "Hello, world!";

    $scope.form =


      $scope.form = Forms.get({ id: document.currentUser.userId }, function () {
        $scope.form.user = Users.get({ id: document.currentUser.userId }, function () {

        })
      });

    $scope.test = function () {
      debugger;
      alert($scope.form);
    }

    $scope.download = function (id) {
      document.location = "/api/Pdf/" + id;
    };

    $scope.session = {
      "name": "Toamnă 2018",
      "status": "deschisă",
      "deadline": new Date(2018, 8, 25, 23, 59, 59),
    };

    //$scope.form = {
    //  "name": "John Doe",
    //  "status": "4",
    //  "date": new Date(2018, 8, 15, 10, 30, 43),
    //}

    $scope.timelineItems = [
      {
        "sessionName": "Sesiunea toamnă 2018",
        "sessionStatus": "open",
        "formStatus": "3",
      },
    ];

    $scope.formatDate = function ($scope,myDate) {
      return moment(myDate).format("dddd, MMMM D, Y, h:mm:ss A");
    }

  }
})();