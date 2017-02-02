(function() {
    angular.module('boojet').directive('incomes', function() {
        return {
            restrict: 'E',
            templateUrl: '/Scripts/Templates/incomes.html',
            controller: 'IncomesController',
            controllerAs: 'incomesCtrl',
            replace: true,
            scope: {
                sum: '='
            },
            bindToController: true

        };
    });
})();