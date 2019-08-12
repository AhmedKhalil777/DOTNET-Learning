# In the name of ALLAH

---

## What is SignalR ??
 - ASP.NET Core SignalR is an open-source library that simplifies adding real-time web functionality to apps. 

 - Real-time web functionality enables server-side code to push content to clients instantly.

## Good candidates for SignalR:

- Apps that require high frequency updates from the server. 

  > Examples are gaming, social networks, voting, auction, maps, and GPS apps.

  > Dashboards and monitoring apps. Examples include company dashboards, instant sales updates, or travel alerts. Collaborative apps. Whiteboard apps and team meeting software are examples of collaborative apps.

   > Apps that require notifications. Social networks, email, chat, games, travel alerts, and many other apps use notifications.
 - SignalR provides an API for creating server-to-client remote procedure calls (RPC). The RPCs call JavaScript functions on clients from server-side .NET Core code.

 - Here are some features of SignalR for ASP.NET Core:
   - Handles connection management automatically.
   - Sends messages to all connected clients simultaneously. 
     > For example, a chat room.
   - Sends messages to specific clients or groups of clients.
   - Scales to handle increasing traffic.

 ## Transports
- SignalR supports several techniques for handling real-time communications:

   - WebSockets
   - Server-Sent Events
   - Long Polling
- SignalR automatically chooses the best transport method that is within the capabilities of the server and client.

## Hubs
- SignalR uses hubs to communicate between clients and servers.

- A hub is a high-level pipeline that allows a client and server to call methods on each other.
-  SignalR handles the dispatching across machine boundaries automatically, allowing clients to call methods on the server and vice versa. 
- You can pass strongly-typed parameters to methods, which enables model binding.
-  SignalR provides two built-in __hub protocols__:
   -  a __text protocol__ based on __JSON__ and a __binary protocol__ based on MessagePack.
   
   - __MessagePack__ generally creates smaller messages compared to JSON. 
   - Older browsers must support __XHR level 2__ to provide MessagePack protocol support.

- Hubs call client-side code by sending messages that contain the name and parameters of the client-side method.
-  Objects sent as method parameters are deserialized using the configured protocol. 
- The client tries to match the name to a method in the client-side code. When the client finds a match, it calls the method and passes to it the deserialized parameter data.

# Supported Platforms

 ## Server system requirements
 - SignalR for ASP.NET Core supports any server platform that ASP.NET Core supports.

 ## Java script Client 
 - The JavaScript client runs on __NodeJS 8__ and a latest browser versions 

 ## .NET client
 - The .NET client runs on any platform supported by ASP.NET Core. 
   > For example, Xamarin developers can use SignalR for building Android apps using Xamarin.Android 8.4.0.1 and later and iOS apps using Xamarin.iOS 11.14.0.4 and later.

  - If the server runs IIS, the WebSockets transport requires IIS 8.0 or later on Windows Server 2012 or later. Other transports are supported on all platforms.

  ## Java client
The Java client supports __Java 8__ and later versions.

  ## Unsupported clients
- The following clients are available but are experimental or unofficial. They aren't currently supported and may never be.

   - C++ client

   - Swift client

---