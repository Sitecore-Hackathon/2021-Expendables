(function ($, window) {
    $(function () {
        const sideBarDOM = '<div id="notificationsBar" class="signar-sidenav"><div class="header"><span>Notifications</span><a href="javascript:void(0);" class="closebtn">&times;</a></div>';
        $('body').prepend(sideBarDOM);
        $('.sc-globalHeader .sc-accountInformation').click(function () {
            $('#notificationsBar').css('width', '350px');
            $('#ContentEditorForm').css('marginLeft', '350px');
        });
        $(document).on('click', '#notificationsBar .closebtn', function () {
            $('#notificationsBar').css('width', '0');
            $('#ContentEditorForm').css('marginLeft', '0');
        });
        $.appendMessage = function (notification) {
            $('#notificationsBar').append('<div class="message-div"><div class="username">' + notification.userName + '<span class="time">(' + notification.time + ')</span></div>' + '<span class="message">' + notification.message + '</span>' + '</div>');
        }
    });
})($sc, window);