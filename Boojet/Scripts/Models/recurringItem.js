RecurringItem = function(name, amount, freqId) {
    this.name = name;
    this.amount = amount;
    this.freqId = freqId;
};

RecurringItem.prototype.monthlyAmount = function() {
    return this.amount * this.getFreq().timesPerMonth;
};
RecurringItem.prototype.getFreq = function() {
    var freqId = this.freqId;
    var x = _.find(this.frequencies, function(freq) { return freq.id === freqId; });
    return x;
};

Frequency = function (name, id, timesPerMonth) {
    this.name = name;
    this.id = id;
    this.timesPerMonth = timesPerMonth;
};;

RecurringItem.prototype.frequencies = [
    { name: "One-Time", id: 0, timesPerMonth: 1 },
    { name: "Weekly", id: 1, timesPerMonth: 4.34 },
    { name: "Bi-Weekly", id: 2, timesPerMonth: 2.17 },
    { name: "Monthly", id: 3, timesPerMonth: 1 },
    { name: "Bi-Monthly", id: 4, timesPerMonth: 0.5 },
    { name: "Semi-Annually", id: 5, timesPerMonth: 0.167 },
    { name: "Annually", id: 6, timesPerMonth: .0833 }
];

