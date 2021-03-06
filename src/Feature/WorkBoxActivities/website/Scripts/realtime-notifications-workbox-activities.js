(function ($, window) {
    $(function () {
        var notificationHub = $.connection.notificationHub;
        notificationHub.client.workboxnotify = function (notification) {
            console.log('Workbox activity');
            console.log(notification);
            console.log('Window username: ' + window.scUser.UserName);
            if (notification.notificationType === 5 && notification.userName !== window.scUser.UserName) {
                $.notify(notification.userFullName + ": " + notification.message, { className: 'info', position: 'bottom right' });
                $.appendMessage(notification);
            }
            if (notification.notificationType === 6 && notification.userName !== window.scUser.UserName) {
                $.notify(notification.userFullName + ": " + notification.message, { className: 'info', position: 'bottom right' });
                $.appendMessage(notification);
            }
            if (notification.notificationType === 7 && notification.userName !== window.scUser.UserName) {
                $.notify(notification.userFullName + ": " + notification.message, { className: 'info', position: 'bottom right' });
                $.appendMessage(notification);
            }
        };
        $.connection.hub.start().done(function () {
            
        });
    });
})($sc, window);