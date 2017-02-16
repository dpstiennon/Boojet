(function() {
    angular.module('boojet').service('urlParams', function($location) {
        var splitUrl = $location.absUrl().split('/');
        var userIdIdx = splitUrl.length - 3;
        var yearIdx = splitUrl.length - 2;
        var monthIdx = splitUrl.length - 1;

        this.getUserId = function() {
            return splitUrl[userIdIdx];
        };

        this.getYear = function() {
            return Number(splitUrl[yearIdx]);
        };

        this.getMonth = function() {
            return Number(splitUrl[monthIdx]);
        };

    });
})();