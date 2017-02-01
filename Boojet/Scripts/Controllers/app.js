(function() {
    var app = angular.module("boojet", []);

    var controller = function() {
        this.sources = incomes;
        this.frequencies = frequencies;
    };

    controller.prototype.total = function() {
        return _.reduce(this.sources, function(memo, src) {
            return memo + src.monthlyAmount();
        }, 0);
    };


    app.controller("IncomeController", controller);




    const incomes = [
        new RecurringItem("Amy Paycheck", 1549.88, 3),
        new RecurringItem( "David Paycheck", 1125.00, 1)
    ];

    let frequencies = [
        { name: "One-Time", id: 0 },
        { name: "Monthly", id: 1 },
        { name: "Bi-Weekly", id: 2 },
        { name: "Weekly", id: 3 }
    ];
})();