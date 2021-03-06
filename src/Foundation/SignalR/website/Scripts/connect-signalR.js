(function ($, window) {
    $(function () {
        var notificationHub = $.connection.notificationHub;
        notificationHub.client.notify = function (notification) {
            console.log(notification);
        };
        $sc.connection.hub.start().done(function () {
            console.log('SignalR connection done');
        });
    });
})($sc, window);