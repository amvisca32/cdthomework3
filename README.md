# cdthomework3
Created a Windows Service with the intent to add screen manipulation functionality. Code as of know only creates a service
that is able to be started and stopped. Service also recalls every 5 seconds and keep a log of all starts, stops, and recalls
in a log file located in the \bin\Debug folder.

# Installing
1. Open an Administrator Command Line
2. Change Directories to the Microsoft.NET Framework directory: "cd C:\Windows\Microsoft.NET\Framework\v4.0.30319"
3. Type Command: InstallUtil.exe + Path to .exe file in \bin\Debug + \WindowsService1.exe

# Usage
 - To Start the Service from the Command Line: "net start Service1"
 - To Stop the Service from the Command Line: "net stop Service1"
 - To Restart the Service from the Command Line: "net stop Service1" followed by "net start Service1"

# Uninstalling
1. Open an Administrator Command Line
2. Change Directories to the Microsoft.NET Framework directory: "cd C:\Windows\Microsoft.NET\Framework\v4.0.30319"
3. Type Command: InstallUtil.exe /u + Path to .exe file in \bin\Debug + \WindowsService1.exe

# Services Desktop Application
Within the Services Desktop Application, the service will show up as "Windows Screen" with the description "Maintains the screen's
orientation and presentation". This was so the service would not stick out among the other Windows services.
