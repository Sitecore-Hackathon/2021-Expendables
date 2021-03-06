(function ($, window) {
    $(function () {
        var notificationHub = $.connection.notificationHub;
        notificationHub.client.notify = function (notification) {
            console.log(notification);
            console.log('Window username: ' + window.scUser.UserName);
            if (notification.notificationType === 4 && notification.userName !== window.scUser.UserName) {
                $.notify(notification.userFullName + " " + notification.message, { className: 'info', position: 'bottom right' });
                appendMessage(notification);
            }
        };
        const sideBarDOM = '<div id="notificationsBar" class="signar-sidenav"><div class="header"><span>Notifications</span><a href="javascript:void(0);" class="closebtn">&times;</a></div>';
        $('body').prepend(sideBarDOM);
        $('.sc-globalHeader .sc-accountInformation').click(function () {
            $('#notificationsBar').css('width', '350px');
            $('#ContentEditorForm').css('marginLeft', '350px');
            //$('#ContentEditorForm').css('padding', '16px');
        });
        $(document).on('click', '#notificationsBar .closebtn', function () {
            $('#notificationsBar').css('width', '0');
            $('#ContentEditorForm').css('marginLeft', '0');
            //$('#ContentEditorForm').css('padding', '0');
        });
        $.connection.hub.start().done(function () {
            console.log('SignalR connection done');
            notificationHub.server.send({
                'userName': window.scUser.UserName,
                'userDisplayName': window.scUser.DisplayName,
                'userEmail': window.scUser.Email,
                'userFullName': window.scUser.FullName,
                'message': 'Just opened content editor',
                'notificationType': 'ContentEditorOpened'
            });
        });
        var appendMessage = function (notification) {
            $('#notificationsBar').append('<div class="message-div"><div class="username">' + notification.userName + '<span class="time">(' + notification.time + ')</span></div>' + '<span class="message">' + notification.message + '</span>' + '</div>');
        }
    });
})($sc, window);