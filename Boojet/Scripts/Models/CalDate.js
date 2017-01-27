CalDate = function(month, year) {
    this.month = Number(month);
    this.year = Number(year);
}

CalDate.prototype.next = function() {
    let month = this.month + 1;
    let year = this.year;
    if (month > 12) {
        year += 1;
        month = 0;
    }
    return new CalDate(month, year);
};

CalDate.prototype.previous = function () {
    let month = this.month - 1;
    let year = this.year;
    if (month < 1) {
        year -= 1;
        month = 12;
    }
    return new CalDate(month, year);

};

CalDate.prototype.equals = function(compDate) {
    return this.month === compDate.month && this.year === compDate.year;
};