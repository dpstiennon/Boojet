(function() {
    function recurringController() {
        this.items = recurrings;
    }

    recurringController.prototype.total = function () {
        return _.reduce(this.items,
            function (memo, item) { return memo + Number(item.amount) },
            0);
    }


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
    angular.module('boojet', []).controller('RecurringController', function(){});
})();