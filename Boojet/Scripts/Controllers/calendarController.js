(function() {
    var calendarController = function() {
        this.currentDate = new CalDate(this.month, this.year);
        this.monthsToShow = 12;
        this.dates = this.buildMonths();
    };

    calendarController.prototype.buildMonths = function buildMonths(month, year) {
        var today = new CalDate(new Date().getFullYear(), new Date().getMonth());
        var months = [this.currentDate];
        var next = this.currentDate.next();
        while (!today.equals(next) && months.length <= 6 ) {
            next = next.next();
            months.push(next);
        }
        var previous = this.currentDate.previous();
        while (months.length <= 12) {
            months.unshift(previous);
            previous = previous.previous();
        }
        return months;
    }

    angular.module('boojet')
        .controller('CalendarController', calendarController);
})();