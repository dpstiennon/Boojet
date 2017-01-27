(function() {
    var calendarController = function() {
        this.year = Number(this.year);
        this.month = Number(this.month);
        this.currentDate = new Date(this.year, this.month - 1);
        this.monthsToShow = 12;
        this.dates = this.buildDateList();
    };

    calendarController.prototype.buildDateList = function() {
        var months = [this.currentDate];
        var now = new Date();
        var next = this.nextMonth(this.currentDate);
        while (next < now && months.length < 6) {
            months.push(next);
            next = this.nextMonth(next);
        }
        var previous = this.previousMonth(this.currentDate);
        while (months.length < 12) {
            months.unshift(previous);
            previous = this.previousMonth(previous);
        }
        return months;
    };

    calendarController.prototype.scrollRight = function() {
        var lastDate = this.dates.slice(-1).pop();
        this.dates.push(this.nextMonth(lastDate));
        this.dates.shift();
    };

    calendarController.prototype.scrollLeft = function() {
        var firstDate = this.dates[0];
        this.dates.unshift(this.previousMonth(firstDate));
        this.dates.pop();

    };

    calendarController.prototype.nextMonth = function(startDate) {
        var next = new Date(startDate);
        next.setMonth(next.getMonth() + 1);
        return next;
    };

    calendarController.prototype.previousMonth = function(startDate) {
        var next = new Date(startDate);
        next.setMonth(next.getMonth() - 1);
        return next;
    };

    calendarController.prototype.monthString = function(myDate) {
        return myDate.toLocaleString('en-us', { month: "short" });
    }

    angular.module('boojet')
        .controller('CalendarController', calendarController);
})();