(function ($, window) {
    $(function () {
        var notificationHub = $.connection.notificationHub;
        notificationHub.client.notify = function (notification) {
            console.log(notification);
            console.log('Window username: ' + window.scUser.UserName);
            if (notification.userName !== window.scUser.UserName) {
                $.notify(notification.userFullName + " " + notification.message, { className: 'info', position: 'bottom right' });
                $("#Gutter" + notification.itemID.toUpperCase()).html("<a class='scContentTreeNodeGutterButton' href='#' onclick='javascript:return scForm.postEvent(this,event,'item:setlayoutdetails(id={FCEEAEEA-5C2E-44C5-8B57-78A428F973B0})')'><img src='/temp/iconcache/applications/16x16/window_colors.png' class='scContentTreeNodeGutterIcon' alt='' title='Item recently edited.' border='0'></a>");
            }
            $.appendMessage(notification);
        };
        $.connection.hub.start().done(function () {
            
        });
    });
})($sc, window);