(function() {
    var totalsController = function() {
    };

    totalsController.prototype.budgeted = function() {
    	var t = this.totals;
        return t.budgets + t.regulars;

    };

    totalsController.prototype.grandTotal = function() {
    	var t = this.totals;
        return t.incomes - t.budgets - t.regulars - t.irregulars;

    };

    angular.module('boojet').controller('TotalsController',  totalsController);
})();