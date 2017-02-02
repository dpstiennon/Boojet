(function() {
	var incomes = [
        new RecurringItem("Amy Paycheck", 1549.88, 3),
        new RecurringItem("David Paycheck", 1125.00, 1)
	];

	var controller = function () {
		this.sources = incomes;
	};

	controller.prototype.total = function () {
		this.sum = _.reduce(this.sources, function (memo, src) {
			return memo + src.monthlyAmount();
		}, 0);
	    return this.sum;
	};


	angular.module('boojet').controller("IncomesController", controller);

})();