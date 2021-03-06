# Hackathon Submission Entry form

## Team name
Expendables

## Category
The best enhancement to the Sitecore Admin (XP) for Content Editors & Marketers210.

## Description
Realtime Notifier uses SignalR to send push notifications to all active Sitecore "Content Editor" users to update them about the latest changes that other users might have done.  

  - What is SignalR: As per Wikipedia, SignalR is a free and open-source software library for Microsoft ASP.NET that allows server code to send asynchronous notifications to client-side web applications. The library includes server-side and client-side JavaScript components.
  - The purpose of this module to keep content author up to the date and informed about what is happening on the items.
  - Currently content author doesn't get any real time notification about what is going on to the items and if there are some items that need their attention to either approve or reject those changes without going into Workbox.
    - Content Author will get the real time notification in content editor itself where he spend most of the time and he can get all update on other items without moving aways from his its own content editor page. 

  - Here, as a part of this solution, we considered the following content author operations for processing the push notifications. The notification will be shown to the Notification center and if the parent root is expanded, the item that was updated by another user will also have an indication in its Gutter area.
    - Item Events 
		- Item Saved
		- Item Renamed
		- Item Deleted

    - Publishing Events
		- Publish End

    - Workflow Events
		- Item Submit
		- Item Approved
		- Item Rejected

## Video link

⟹ [Replace this Video link](#video-link)



## Pre-requisites and Dependencies

- Sitecore 10.1
- Microsoft .NET Framework 4.8
- SignalR 2.4.1



## Installation instructions

1. Open Visual Studio 2019 with Administrator rights`
2. Set `PublishUrl` in "PublishProfiles" to target your Sitecore instance
3. Publish all 4 projects to targetted Sitecore instance
4. Install provided Sitecore package to add required items


### Configuration
Set `PublishUrl` in "PublishProfiles" to target your Sitecore instance


## Usage instructions
1. Create some users that have "Content Author" rights. 
2. Log into Sitecore client application from these users in different browser 
3. Open Sitecore Content Editor in each user session
4. Try updating Sitecore items from Content Tree
5. All users should be able to get real time notifications

- Notification Areas
	- Content Tree Gutter
	- Bell Icon at the bottom
	- Notification Popup bottom right

![Realtime Notification](docs/images/gutter-notification.png?raw=true "Realtime Notification")

- Notification List
	- Bell Icon at the bottom

![Realtime Notification](docs/images/bell-notifications.png?raw=true "Realtime Notification")

## Further Enchancement
Due to 24hours time constraint we were not able to include many other intutive features but we would definitely like to keep on adding those features to make it a great asset to the Content Author. These are few, we can plan in short term goal.

- Message Content managment through Sitecore
- Persistent Notification
- Live Chat with 2 or more Authors

![Hackathon Logo](docs/images/hackathon.png?raw=true "Hackathon Logo")

