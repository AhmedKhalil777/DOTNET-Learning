# In The Name of ALLAH
---

- In real life, there are three approaches to using MVC and its variants:

> RAD + MVC pattern: for example, Windows Forms is a plain RAD framework for Windows, when writing a Windows Forms program, instead of putting all code in the event handlers, you can create models, views, and controllers to enjoy the benefits of the MVC pattern

 > RAD + MVC framework: to avoid reinventing the wheel, developers created many reusable MVC frameworks for those plain RAD frameworks. For example, Windows Presentation Foundation (WPF) is a plain RAD framework for Windows, and PRISM is a framework which contains base classes and implemented basic infrastructures of the MVVM pattern. When using the PRISM framework, you can easily create views, models, and view-models by deriving the base classes and don't need to build them from scratch.

> Another example is the Angular framework. HTML+JavaScript
 is the traditional web client RAD framework;
 it's hard to create an enterprise level web application
 using just pure HTML+JavaScript.
  -  Angular is an MVC framework for HTML web client development. Once you use HTML and the Angular framework together, your web application becomes an MVC application.

> MVC application framework: there are many MVC application frameworks, such as ASP.NET MVC, ASP.NET Core, and Spring MVC. The difference between using an MVC application framework and using a RAD + MVC framework is, once you build an application on the MVC application framework, the application is constrained to be an MVC application naturally
and you have no chance to make it non-MVC.
- For example, when you create a web application using ASP.NET MVC, ASP.NET Core or Spring MVC, the project scaffolding will prepare the application architecture which applies the MVC pattern for you. Your job is just to keep adding models, views, and controllers to implement the requirements from customers.

> In short, knowledge of the MVC pattern (and its variants), is almost mandatory for every modern developer.
