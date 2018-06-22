(function () {
  'use strict';

  angular.module('FMI-Cazare.pages.studentTimeline')
    .controller('StudentTimelineCtrl', StudentTimelineCtrl);

  function StudentTimelineCtrl($scope, $state, toastr, editableOptions, editableThemes) {
    editableOptions.theme = 'bs3';
    editableThemes['bs3'].submitTpl = '<button type="submit" class="btn btn-primary btn-with-icon"><i class="ion-checkmark-round"></i></button>';
    editableThemes['bs3'].cancelTpl = '<button type="button" ng-click="$form.$cancel()" class="btn btn-default btn-with-icon"><i class="ion-close-round"></i></button>';

    var vm = this;
    $scope.test = "Hello, world!";

    $scope.goToForm = function () {
      $state.go("studentForm");
    }

    $scope.session = {
      "name": "Toamnă 2018",
      "status": "deschisă",
      "deadline": new Date(2018, 8, 25, 23, 59, 59),
    };

    $scope.form = {
      "name": "John Doe",
      "status": "netrimis",
      "date": new Date(2018, 8, 15, 10, 30, 43),
    }

    $scope.formApproved = {
      "name": "John Doe",
      "status": "aprobată",
      "date": new Date(2018, 8, 16, 10, 30, 43),
    }

    $scope.formRejected = {
      "name": "John Doe",
      "status": "respinsă",
      "date": new Date(2018, 8, 16, 10, 30, 43),
      "message": "Nu ai uploadat fișierele ce dovedesc situația socială.",
    }


    $scope.timelineItems = [
      {
        "sessionName": "Sesiunea toamnă 2018",
        "sessionStatus": "open",
        "formStatus": "not sent",
      },
    ];

    $scope.formatDate = function (myDate) {
      return moment(myDate).format("dddd, MMMM D, Y, h:mm:ss A");
    }

  }
})();