# __In The Name OF ALLAH__
---
##  __Preconfiguration Lab - Build The Development Environment__
---
- __Lab Review__
The goal of this lab is to guide you through the steps necessary to build the development environment on your computer.

- __The tools we use to build the development environment include:__

 - 1- __.NET Core SDK 2.0__
 - 2- __Visual Studio Code__
 - 3 -__MySQL Server tools bundleLab Review__
- The goal of this lab is to guide you through the steps necessary to build the development environment on your computer.

- The tools we use to build the development environment include:

- `` - .NET Core SDK 2.0.
Visual Studio Code.
MySQL Server tools bundle``

>__Download and Install .NET Core SDK__
 - Search .net core sdk download or go to https://www.microsoft.com/net/download/core directly.
- Download the appropriate installer for your platform of choice.
-  In our case, using Windows, we will choose Windows (x64) Installer.
- You should get __dotnet-sdk-2.0.0-win-x64.exe__
- Double click the installer and follow the instruction until you finish the installation.
- Press Win+R to show the Run window.
- On Windows, open either a command prompt or powershell.
- Type dotnet --version and press Enter.
- If there are no errors, you should see 2.2.30 as the output.

> __Download and Install Visual Studio Code__
- Search visual studio code download or go to https://code.visualstudio.com/download directly.
- Download Visual Studio Code for your platform.
- Run the installer and follow the instructions.
- On the Select Additional Tasks page, the suggestion is check all options since this will give you a lot of conveniences in the future.
- Follow the rest of the instructions until you finish the installation.
- Run Visual Studio Code and verify that you see the “Welcome” page.
- Expand the Extensions panel (the shortcut is Ctrl+Shift+X). Search -   extensions for C#.
- In the search result, install the C# for Visual Studio Code (powered by OmniSharp).
Restart Visual Studio Code.

> __Download and Install MySQL Server__
> - NOTE: Because the requirements for each operating system are different and change frequently, follow the instructions for your operating system, provided on the MySQL installation page for your platform of choice. We do cover the Windows install here as a reference.

- To run on Windows, MySQL needs two dependencies:
Search visual c++ 2013 redistributable or go to https://www.microsoft.com/en-us/download/details.aspx?id=40784 directly.
- Download and run both the vcredist_x86.exe and vcredist_x64.exe installers.
Search visual c++ 2015 redistributable or go to https://www.microsoft.com/en-us/download/details.aspx?id=48145 directly.
-  Download and run both the vc_redist.x86.exe and vc_redist.x64.exe installers.
- Search mysql community download or go to https://dev.mysql.com/downloads/mysql/ directly.
- Click the Go to Download Page > picture. You should be taken to the download page for the latest MySQL build.
- Download the Windows (x86, 32-bit), MSI Installer.
- You should get the mysql-installer-community-5.7.19.0.msi installer.
 > Note: the installer itself is x86 but it contains both of the x86 build and x64 build. We will choose the x64 build to install.

- Run the installer. On the Choosing a Setup Type page, select Custom, then click the Next button.
- On the Select Products and Features page, pick and move MySQL Server 5.7.19 - X64, MySQL Workbench 6.3.9 - X64, and Samples and Examples 5.7.19 - X86 from the left panel to the right panel one by one. Then click the Next button.

- Follow the rest of the instructions to finish the installation. Use default values for all the configurations will be OK for you.
