async function ViewModel() {
    this.activityUri = 'http://localhost:57313/api/activities';
    this.groupUri = 'http://localhost:57313/api/groups';
    this.activities = ko.observableArray();
    this.groups = ko.observableArray();
    this.error = ko.observable();
    await ajaxHelper(this.activityUri, 'GET', this.activities);
    await ajaxHelper(this.groupUri, 'GET', this.groups);
}

async function ajaxHelper(uri, method, obsarray, data) {
    this.err = null;
    await $.ajax({
        type: method,
        url: uri,
        dataType: 'json',
        contentType: 'application/json',
        data: data ? JSON.stringify(data) : null,
    }).done(function (data) {
        obsarray(data);
    }).fail(function (error) {
        this.err("Error! " + error.status);
    });

}
async function start() {
    var mModel = await ViewModel();
    ko.applyBindings(mModel);
}
start();

