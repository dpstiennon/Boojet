(function() {
    var budgetingController = function() {
        this.totalRegulars = 3;
        this.totalIrregulars = 4;
        this.totalBudgets = 5;
        this.totalIncomes = 6;
        this.totals = {
            regulars: this.totalRegulars,
            irregulars: this.totalIrregulars,
            budgets: this.totalBudgets,
            incomes: this.totalIncomes
        }
    };

    angular.module('boojet').controller('BudgetingController', budgetingController);
})();