var ViewModel = function () {
    var self = this;
    self.sports = ko.observableArray();
    self.error = ko.observable();

    var sportsUri = 'api/Sports/';

    function ajaxHelper(uri, method, data) {
        self.error(''); // Clear error message
        return $.ajax({
            type: method,
            url: uri,
            dataType: 'json',
            contentType: 'application/json',
            data: data ? JSON.stringify(data) : null
        }).fail(function (jqXHR, textStatus, errorThrown) {
            self.error(errorThrown);
        });
    }

    function getAllSports() {
        ajaxHelper(sportsUri, 'GET').done(function (data) {
            self.sports(data);
        });
    }

    // Fetch the initial data.
    getAllSports();
};

ko.applyBindings(new ViewModel());