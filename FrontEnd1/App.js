async function ViewModel() {
    this.activityUri = 'http://localhost:57313/api/activities';
    this.groupUri = 'http://localhost:57313/api/groups';
        /*this.tasksUri = '/api/tasks/';
        this.userStoryUri = '/api/userstories';
        this.tasks = ko.observableArray();
        this.userStories = ko.observableArray();*/
    this.activities = ko.observableArray();
    this.groups = ko.observableArray();
    this.error = ko.observable();
    await ajaxHelper(this.activityUri, 'GET', this.activities);
    await ajaxHelper(this.groupUri, 'GET', this.groups);
    console.log(this.activities());
    console.log(this.groups());
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
        console.log(obsarray());
    }).fail(function (error) {
        this.err("Error! " + error.status);
    });

}
async function start() {
    var mModel = await ViewModel();
    ko.applyBindings(mModel);
}
start();

