# In The Name Of Allah
---
# Authentication
> Authentication is the process of determining a user's identity.

> Authorization is the process of determining whether a user has access to a resource

> In ASP.NET Core, authentication is handled by the __IAuthenticationService__, which is used by authentication middleware.

> The authentication service uses registered authentication handlers to complete authentication-related actions. 

> Examples of authentication-related actions include:

- Authenticating a user.
  - Responding when an unauthenticated user tries to access a restricted resource.
  - The registered authentication handlers and their configuration options are called "schemes".

  - Authentication schemes are specified by registering authentication services in Startup.ConfigureServices:

  - By calling a scheme-specific extension method after a call to services.AddAuthentication (such as AddJwtBearer or AddCookie, for example).
  - These extension methods use AuthenticationBuilder.AddScheme to register schemes with appropriate settings.
Less commonly, by calling AuthenticationBuilder.AddScheme directly.

For example, the following code registers authentication services and handlers for cookie and JWT bearer authentication schemes:
```
services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options => Configuration.Bind("JwtSettings", options))
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options => Configuration.Bind("CookieSettings", options));
```

