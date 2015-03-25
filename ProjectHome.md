MessagingToolkit SmartGateway is an application built on top of the [MessagingToolkit](http://twit88.com/platform/projects/show/messagingtoolkit) library which can be used to send and receive SMS.

Download for the current beta is available **[here](http://messagingtoolkit-smartgateway.googlecode.com/files/SmartGateway-beta.msi)**.




**Note: If you have any problem running the application in x64 environment (**"Could not load file or assembly 'System.Data.SQLite'**), please do the followings**

1. Please download **[SQLite library for x64](http://messagingtoolkit-smartgateway.googlecode.com/files/System.Data.SQLite_x64_net40.zip)**.

2. Unzip the file, and overwrite System.Data.SQLite.dll and System.Data.SQLite.Linq.dll under the **<Installation Folder>** and **<Installation Folder>\Portal\bin**.

3. Modify web.config under Portal folder, for the following section

`<add name="SQLite Data Provider" invariant="System.Data.SQLite" description=".Net Framework Data Provider for SQLite" type="System.Data.SQLite.SQLiteFactory, System.Data.SQLite, Version=1.0.66.0, Culture=neutral, PublicKeyToken=db937bc2d44ff139" />`

to

`<add name="SQLite Data Provider" invariant="System.Data.SQLite" description=".Net Framework Data Provider for SQLite" type="System.Data.SQLite.SQLiteFactory, System.Data.SQLite" />`





You can also preview some of the screenshots at [ScreenShots](ScreenShots.md) and download the latest source code from the Subversion repository

![http://messagingtoolkit-smartgateway.googlecode.com/files/main_screen.png](http://messagingtoolkit-smartgateway.googlecode.com/files/main_screen.png)