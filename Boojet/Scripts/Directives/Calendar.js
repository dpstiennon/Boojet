(function() {
    angular.module("boojet", []).directive("calendar", function() {
        return {
            restrict: 'E',
            templateUrl: '/Scripts/Templates/Calendar.html',
            controller: 'CalendarController',
            controllerAs: 'calendarCtrl'
        }
        
    });
})();