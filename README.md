# MessagingToolkit SmartGateway
###### SMS and MMS gateway

MessagingToolkit SmartGateway is an application built on top of the [MessagingToolkit](http://www.twit88.com/) library which can be used to send and receive SMS.

Download for the current beta is available [here](/Downloads).

**Note: If you have any problem running the application in x64 environment ("Could not load file or assembly 'System.Data.SQLite'), please do the followings**

1. Please download [SQLite library for x64](/Downloads).

2. Unzip the file, and overwrite System.Data.SQLite.dll and System.Data.SQLite.Linq.dll under the and **\Portal\bin**.

3. Modify web.config under Portal folder, for the following section

```
<add name="SQLite Data Provider" invariant="System.Data.SQLite" description=".Net Framework Data Provider for SQLite" type="System.Data.SQLite.SQLiteFactory, System.Data.SQLite, Version=1.0.66.0, Culture=neutral, PublicKeyToken=db937bc2d44ff139" />
```

```
<add name="SQLite Data Provider" invariant="System.Data.SQLite" description=".Net Framework Data Provider for SQLite" type="System.Data.SQLite.SQLiteFactory, System.Data.SQLite" />
```

You can also preview some of the screenshots at ScreenShots and download the latest source code from the GitHub repository

![Main Screen](/Downloads/main_screen.png?raw=true "Main Screen View")
