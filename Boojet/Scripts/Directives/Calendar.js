(function() {
    angular.module("boojet").directive("calendar", function() {
        return {
            scope: { },
            restrict: 'E',
            templateUrl: '/Scripts/Templates/Calendar.html',
            controller: 'CalendarController',
            controllerAs: 'calendarCtrl',
            bindToController: true,
            replace: true
        }
        
    });
})();