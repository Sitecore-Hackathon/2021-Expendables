(function ($, window) {
    $(function () {
        //content-editor is not in iframe
        //const sideBarDOM = '<div id="notificationsBar" class="signar-sidenav"><div class="header"><span>Notifications</span><a href="javascript:void(0);" class="closebtn">&times;</a></div>';
        //$('body').prepend(sideBarDOM);
        var totalNotifications = 0;
        var notificationDropdownOpen = false;
        //var notificationBellIconContainer = $('#SearchPanel .scSearchButton').parents('td');
        var notificationBellIconContainer = $('.scPager.scDockBottom');
        $('#SearchPanel .scSearchButton').parent().parent().css('display', 'inline-block');
        var notificationDOM = '<div class="scEditorTabControls" style="display: inline-block;"><div class="dropdown signalr-dropdown">';
        notificationDOM += '<a href="#" onclick="return false;" role="button" data-toggle="dropdown" id="dropdownMenu1" data-target="#" style="float: left" aria-expanded="true"><i class="fa fa-bell-o" style="font-size: 20px; float: left; color: white"></i></a>';
        notificationDOM += '<span class="badge badge-danger hide"></span>';
        notificationDOM += '<ul id="notification-area" class="dropdown-menu dropdown-menu-left pull-right" role="menu" aria-labelledby="dropdownMenu1">';
        notificationDOM += '<li role="presentation"><a href="#" class="dropdown-menu-header">Notifications</a></li>';
        notificationDOM += '<ul id="timeline-list" class="timeline timeline-icons timeline-sm">';
        notificationDOM += '</ul>';
        notificationDOM += '</ul>';
        notificationDOM += '</div></div>';
        notificationBellIconContainer.append(notificationDOM);


        notificationBellIconContainer.find('#dropdownMenu1').click(function () {
            if (!notificationDropdownOpen) {
                notificationBellIconContainer.find('#notification-area').show(100);
                notificationDropdownOpen = true;
                console.log('Opening dropdown');
                $('.signalr-dropdown .badge').html('');
                $('.signalr-dropdown .badge').addClass('hide');
                totalNotifications = 0;
            }
            else {
                notificationBellIconContainer.find('#notification-area').hide(100);
                notificationDropdownOpen = false;
                console.log('closing dropdown');
            }

        });
        $(document).on('click', '#notificationsBar .closebtn', function () {
            $('#notificationsBar').css('width', '0');
            $('#ContentEditorForm').css('marginLeft', '0');
        });
        $(document).click(function (e) {
            e.stopPropagation();
            var container = notificationBellIconContainer.find('.signalr-dropdown');
            if (container.has(e.target).length === 0 && notificationDropdownOpen) {
                notificationBellIconContainer.find('#notification-area').hide(100);
                notificationDropdownOpen = false;
            }
        });
        $.appendMessage = function (notification) {
            //var notificationBellIconContainer = $('#Editors #EditorTabs div.scEditorTabControlsHolder');
            //if (notificationBellIconContainer.find('.signalr-dropdown').length === 0) {
            //    $.initNotificationIcon();
            //}
            notificationBellIconContainer.find('#timeline-list').append('<li><div class= "message-div" > <div class="username">' + notification.userName + '<span class="time">(' + notification.time + ')</span></div>' + '<span class= "message">' + notification.message + '</span> ' + '</div></li>');
            totalNotifications = totalNotifications + 1;
            notificationBellIconContainer.find('.signalr-dropdown .badge').html(totalNotifications);
            notificationBellIconContainer.find('.signalr-dropdown .badge').removeClass('hide');
        }      
    });
})($sc, window);