angular.module('boojet')
    .directive('recurringExpenses',
        function() {
            return {
                restrict: 'E',
                templateUrl: '/Scripts/Templates/RecurringExpenses.html',
                controller: 'RecurringController',
                controllerAs: 'recurringCtrl',
                replace: true
            };
        });