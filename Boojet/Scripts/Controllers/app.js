(function() {
    const app = angular.module("boojet", []);
    app.controller("RecurringController",
        function() {
            this.items = recurrings;
            this.total = function() {
                return _.reduce(this.items,
                    function (memo, item) { return memo + Number(item.amount) },
                    0);
            };
        });

    app.controller("IncomeController",
        function() {
            this.sources = incomes;
            this.frequencies = frequencies;
        });

    const incomes = [
        {
            name: "Amy Paycheck",
            Recurring: 1,
            amount: 1549.88
        },
        {
            name: "David Paycheck",
            Recurring: 3,
            amount: 1125.00
        }
    ];

    const recurrings = [
        {
            name: "Electric",
            amount: 53.56
        },
        {
            name: "Student Loan",
            amount: 75.05
        }
    ];

    let frequencies = [
        { name: "One-Time", id: 0 },
        { name: "Monthly", id: 1 },
        { name: "Bi-Weekly", id: 2 },
        { name: "Weekly", id: 3 }
    ];
})();