(function() {
    angular.module('boojet').controller('RecurringController', recurringController);

    function recurringController() {
        this.items = recurrings;
    }

    recurringController.prototype.total = function () {
        this.sum = _.reduce(this.items, function (memo, item) {
            return memo + item.monthlyAmount();
        }, 0);
        return this.sum;
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

    recurringController.prototype.moveUp = function (index) {
        if (index <= 0) { return; }
        var temp = this.items[index];
        this.items[index] = this.items[index - 1];
        this.items[index - 1] = temp;
    }

    recurringController.prototype.add = function() {
        this.items.push(new RecurringItem("", 0.0, 3));

    };

    const recurrings = [
        new RecurringItem('Electric', 55.42, 3),
        new RecurringItem('Student Loans', 63.12, 3)
    ];
})();