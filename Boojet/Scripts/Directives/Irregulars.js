(function() {
    angular.module('boojet')
        .directive("irregulars",
            function() {
                return {
                    restrict: 'E',
                    templateUrl: '/Scripts/Templates/Irregulars.html',
                    controller: 'IrregularsController',
                    controllerAs: 'irregularsCtrl',
                    replace: true
                };
            });
})();