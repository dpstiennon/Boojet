(function() {
    let irregularsController = function() {
        this.items = [
            new RecurringItem("Huge car repair", 496.11, 1),
            new RecurringItem("PS4", 299.99)
        ];
    };

    irregularsController.prototype.total = function () {
        return _.reduce(this.items,
            function (memo, item) { return memo + Number(item.amount) },
            0);
    }

    irregularsController.prototype.delete = function(index) {
        this.items.splice(index, 1);
    }

    irregularsController.prototype.moveDown = function(index) {
        if (index >= this.items.length - 1) { return; }
        var temp = this.items[index];
        this.items[index] = this.items[index + 1];
        this.items[index + 1] = temp;
    }

    irregularsController.prototype.moveUp= function (index) {
        if (index <= 0) { return; }
        var temp = this.items[index];
        this.items[index] = this.items[index - 1];
        this.items[index - 1] = temp;
    }

    angular.module('boojet')
        .controller('IrregularsController', irregularsController);
})();