(function() {
    var totalsController = function() {
//        this.budgeted = this.totals.regulars;
//        this.income = this.totals.incomes;
//        this.irregular = this.totals.irregulars;
    };

    totalsController.prototype.grandTotal = function() {
        return this.totals;
    };

    angular.module('boojet').controller('TotalsController',  totalsController);
})();