(function () {
  'use strict';

  angular.module('FMI-Cazare.pages.studentForm')
    .controller('StudentFormCtrl', StudentFormCtrl);

  function StudentFormCtrl($scope, toastr, editableOptions, editableThemes, baConfig) {
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



    $scope.transparent = baConfig.theme.blur;
    var dashboardColors = baConfig.colors.dashboard;
    var colors = [];
    for (var key in dashboardColors) {
      colors.push(dashboardColors[key]);
    }

    function getRandomColor() {
      var i = Math.floor(Math.random() * (colors.length - 1));
      return colors[i];
    }

    $scope.todoList = [
      { text: 'Check me out' },
      { text: 'Lorem ipsum dolor sit amet, possit denique oportere at his, etiam corpora deseruisse te pro' },
      { text: 'Ex has semper alterum, expetenda dignissim' },
      { text: 'Vim an eius ocurreret abhorreant, id nam aeque persius ornatus.' },
      { text: 'Simul erroribus ad usu' },
      { text: 'Ei cum solet appareat, ex est graeci mediocritatem' },
      { text: 'Get in touch with akveo team' },
      { text: 'Write email to business cat' },
      { text: 'Have fun with blur admin' },
      { text: 'What do you think?' },
    ];

    $scope.todoList.forEach(function (item) {
      item.color = getRandomColor();
    });

    $scope.newTodoText = '';

    $scope.addToDoItem = function (event, clickPlus) {
      if (clickPlus || event.which === 13) {
        $scope.todoList.unshift({
          text: $scope.newTodoText,
          color: getRandomColor(),
        });
        $scope.newTodoText = '';
      }
    };

  }
})();