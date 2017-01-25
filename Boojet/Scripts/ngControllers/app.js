(function() {
    const app = angular.module("boojet", []);
    app.controller("RecurringController",
        function() {
            this.items = recurrings;
        });

    let recurrings = [
        {
            Name: "Electric",
            Amount: 53.56
        },
        {
            Name: "Student Loan",
            Amount: 75.05
        }
    ];
})();