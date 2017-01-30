﻿(function() {
    angular.module('boojet').controller('RecurringController', recurringController);

    function recurringController() {
        this.items = recurrings;
    }

    recurringController.prototype.total = function () {
        return _.reduce(this.items,
            function (memo, item) { return memo + Number(item.amount) },
            0);
    }

    recurringController.prototype.delete = function(index) {
        this.items.splice(index, 1);
    }

    recurringController.prototype.moveDown = function(index) {
        if (index >= this.items.length - 1) { return; }
        var temp = this.items[index];
        this.items[index] = this.items[index + 1];
        this.items[index + 1] = temp;
    }

    recurringController.prototype.moveUp= function (index) {
        if (index <= 0) { return; }
        var temp = this.items[index];
        this.items[index] = this.items[index - 1];
        this.items[index - 1] = temp;
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
})();