## Overview of ASP.NET Core Security
 > ASP.NET Core enables developers to easily configure and manage security for their apps.
 
 >  ASP.NET Core contains features for managing authentication, authorization, data protection, HTTPS enforcement, app secrets, anti-request forgery protection, and CORS management. 
 
 > These security features allow you to build robust yet secure ASP.NET Core apps.

## ASP.NET Core security features
 - ASP.NET Core provides many tools and libraries to secure your apps including built-in Identity providers but you can use 3rd party identity services such as Facebook, Twitter, or LinkedIn.

 - With ASP.NET Core, you can easily manage app secrets, which are a way to store and use confidential information without having to expose it in the code.

## Authentication vs. Authorization
- __Authentication__ is a process in which a user provides credentials that are then compared to those stored in an operating system, database, app or resource.
  -  If they match, users authenticate successfully, and can then perform actions that they're authorized for, during an authorization process. 
- __The Authorization__ refers to the process that determines what a user is allowed to do.

- Another way to think of __authentication__ is to consider it as a way to enter a space, such as a __server, database, app or resource__, while __authorization__ is which actions the user can perform to which objects inside that space __(server, database, or app).__

## Common Vulnerabilities in software
- ASP.NET Core and EF contain features that help you secure your apps and prevent security breaches.
-  The following list of links takes you to documentation detailing techniques to avoid the most common security vulnerabilities in web apps:

   - [Cross-site scripting attacks](https://docs.microsoft.com/en-us/aspnet/core/security/cross-site-scripting?view=aspnetcore-2.2)
   - [SQL injection attacks](https://docs.microsoft.com/en-us/ef/core/querying/raw-sql)
   - [Cross-Site Request Forgery (CSRF)](https://docs.microsoft.com/en-us/aspnet/core/security/anti-request-forgery?view=aspnetcore-2.2)
   - [Open redirect attacks](https://docs.microsoft.com/en-us/aspnet/core/security/preventing-open-redirects?view=aspnetcore-2.2)
 > There are more vulnerabilities that you should be aware of.
 -  For more information, see the other articles in the Security and Identity section of the table of contents.