(function() {
    var BudgetsController = function() {
        this.items = [
            new RecurringItem('Travel', 250),
            new RecurringItem('Groceries', 700)
        ];
    };

    BudgetsController.prototype.total = function () {
    	this.sum = _.reduce(this.items,
            function (memo, item) { return memo + Number(item.amount) },
            0);
        return this.sum;
    }

    BudgetsController.prototype.delete = function (index) {
    	this.items.splice(index, 1);
    }

    BudgetsController.prototype.moveDown = function (index) {
    	if (index >= this.items.length - 1) { return; }
    	var temp = this.items[index];
    	this.items[index] = this.items[index + 1];
    	this.items[index + 1] = temp;
    }

    BudgetsController.prototype.moveUp = function (index) {
    	if (index <= 0) { return; }
    	var temp = this.items[index];
    	this.items[index] = this.items[index - 1];
    	this.items[index - 1] = temp;
    }


	angular.module('boojet')
        .controller('BudgetsController', BudgetsController);

})();