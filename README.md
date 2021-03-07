# Hackathon Submission Entry form

## Team name
⟹ Expendables (Arvind Gehlot, Jatin Prajapati, Varun Shringarpure)

## Category
⟹ The best enhancement to the Sitecore Admin (XP) for Content Editors & Marketers.

## Description
⟹ The Realtime Notifier uses SignalR to send push notifications to all active Sitecore "Content Editor" users to update them about the latest changes that other users might have done. To achieve this, we have used SignalR. What is SignalR: As per Wikipedia, SignalR is a free and open-source software library for Microsoft ASP.NET that allows server code to send asynchronous notifications to client-side web applications. The library includes server-side and client-side JavaScript components.

  - The purpose of this module to keep content author up to the date and informed about what is happening on the items.
  - Currently content author doesn't get any real time notification about what is going on to the items and if there are some items that need their attention to either approve or reject those changes without going into Workbox.
    - Content Author will get the real time notification in content editor itself where he/she spend most of the time and he/she will now get all the updates. 
	- The notification will be shown in the Notification center - as a Bell icon besides the Workbox as well as a flyout on the bottom right of the screen. If the item's parent root is expanded, the item that was updated by another user will also have an indication in its Gutter area.
  - As a part of the current Module, we have considered the following content author operations for processing sending the notifications: 
    - Item Activities 
		- When an Item is Created
		- When an Item is Saved
		- When an Item is Renamed
		- When an Item is Deleted
		- When one or more Items are Published
    - User Activities 
		- When the Content Editor is being accessed
    - Workflow Activities
		- When an Item is Submitted to the Workflow
		- When an Item in Workflow is Approved
		- When an Item in Workflow is Rejected

## Video link

⟹ [Team Expendables Video Demo](https://youtu.be/ytZGMTAcZoQ)


## Installation instructions

1. Use the Sitecore Installation wizard to install package.
2. Login to Sitecore having an administrator role.
3. From Sitecore Launchpad open Desktop.
4. Navigate to Start Menu -> Development Tools -> Installation Wizard.
5. Download Sitecore Package [RealtimeNotifier](https://github.com/Sitecore-Hackathon/2021-Expendables/blob/main/blob/main/package/SCHackathon2021-Team-Expendables-1.0.zip)
6. Using upload package upload it to sitecore.
7. Once upload is complete click next.
8. Click on Install button of "Install a Package" dialog.

## Usage instructions

1. Create atleast one user in Sitecore that has "Content Author" rights. 
2. Log into Sitecore with atleast two different users in two different browsers - one as a normal Administrator account and another as the user that you created.
3. Open Sitecore Content Editor in each user session.
4. Try updating Sitecore items from Content Tree, in both the user sessions.
5. All users will get the real time notifications of the activity of other user who is logged into the system.

- Notification Areas
	- Content Tree Gutter
	- Bell Icon at the bottom
	- Notification Popup bottom right

![Realtime Notification](docs/images/gutter-notification.png?raw=true "Realtime Notification")

- Notification List
	- Bell Icon at the bottom

![Realtime Notification](docs/images/bell-notifications.png?raw=true "Realtime Notification")

## Further Enhancement
We did a lot of brainstorming during the initial hour and came up with a lot of ideas. We have implemented a number of functionalities but there are others which we are very much interested to add to the module, to make it even more useful.
Here are few which we can plan to add in near future.

- Content management of the Messages through Sitecore
- Notification settings - of enabling and disabling the notifications - through Sitecore
- Persistent Notifications
- Live Chat between Authors

![Hackathon Logo](docs/images/hackathon.png?raw=true "Hackathon Logo")