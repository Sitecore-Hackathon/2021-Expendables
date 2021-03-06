(function ($, window) {
    $(function () {
        var notificationHub = $.connection.notificationHub;
        notificationHub.client.itemActivityNotify = function (notification) {
            console.log('Item activity');
            console.log(notification);
            console.log('Window username: ' + window.scUser.UserName);
            if (notification.userName !== window.scUser.UserName) {
                $.notify(notification.userFullName + ": " + notification.message, { className: 'info', position: 'bottom right' });
                $("#Gutter" + notification.itemID.toUpperCase()).html("<a class='scContentTreeNodeGutterButton' href='#'><img src='/~/icon/office/32x32/lightbulb_on.png' class='scContentTreeNodeGutterIcon' alt='' title='Item recently edited.' border='0'></a>");
                setTimeout(function () { $("#Gutter" + notification.itemID.toUpperCase()).html(""); }, 5000);
                $.appendMessage(notification);
            }
        };
        $.connection.hub.start().done(function () {

        });
    });
})($sc, window);