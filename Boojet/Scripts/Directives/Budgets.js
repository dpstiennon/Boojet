(function() {
    angular.module('boojet').directive('budgets', function() {
    	return {
    		restrict: 'E',
            templateUrl: '/Scripts/Templates/budgets.html',
    		controller: 'BudgetsController',
    		controllerAs: 'budgetsCtrl',
            scope: {
                sum: '='
            },
            bindToController: true,
            replace: true
        };
    });
})();