(function ($, window) {
    $(function () {
        var notificationHub = $.connection.notificationHub;
        notificationHub.client.notify = function (notification) {
            console.log('User activity');
            console.log(notification);
            console.log('Window username: ' + window.scUser.UserName);
            if (notification.notificationType === 4 && notification.userName !== window.scUser.UserName && notification.userFullName !== null) {
                $.notify(notification.userFullName + " " + notification.message, { className: 'info', position: 'bottom right' });
                $.appendMessage(notification);
            }
        };
        $.connection.hub.start().done(function () {
            notificationHub.server.send({
                'userName': window.scUser.UserName,
                'userDisplayName': window.scUser.DisplayName,
                'userEmail': window.scUser.Email,
                'userFullName': window.scUser.FullName,
                'message': 'Just opened content editor',
                'notificationType': 'ContentEditorOpened'
            });
        });
    });
})($sc, window);