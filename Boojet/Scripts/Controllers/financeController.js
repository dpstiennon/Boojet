(function() {
    function FinanceController(){
        this.totalIncomes = 1000;
    };

    FinanceController.prototype.getTotals = function() {
        return {
            regulars: this.totalRegulars,
            irregulars: this.totalIrregulars,
            budgets: this.totalBudgets,
            incomes: this.totalIncomes
        };
    };


    angular.module('boojet').controller('FinanceController', FinanceController);
})();