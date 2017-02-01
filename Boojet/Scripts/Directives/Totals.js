(function() {
    angular.module('boojet').directive('totals', function() {
        return {
            restrict: 'E',
            templateUrl: '/Scripts/Templates/totals.html',
            controller: 'TotalsController',
            controllerAs: 'totalsCtrl',
            scope: {
                totals: '@'
            }
        };
    });

})();