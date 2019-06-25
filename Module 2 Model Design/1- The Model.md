# In The Name OF ALLAH
---
## The Model
---
> The goal of this module is to guide your understanding of what the model is, in the MVC pattern, and how many kinds of models in a real-world project might exist, and how to design them.

- In this lesson, we will learn about:

- What is the model in an MVC pattern
- What does the model look like
- A classification of models
---
> __What is a  Model ??__

- We start our learning of MVC with the model, since it does not depend on any specific ASP.NET Core technology.

-  In the MVC pattern, a model is an __abstract data structure__ (usually a __class__).

- A model __reflects__ the status and behaviors of the __real-world objects__ with its properties and methods.

- In an ASP.NET Core system, models are __Plain Old CLR Objects (POCO) classes__.

-  That means, a model class does not need to implement interfaces.
- As a contrast, some other technology may require the model class to implement certain interfaces.
- For example, Windows Presentation Foundation (WPF) requests its view model to implement the INotifyPropertyChanged interface for enabling the capability of notifying the view when changes have occurred.

- Here is a simple Student model class:

```

public class Student {
    public int ID { get; set; }
    public string Name { get; set; }
    public DateTime Birthday { get; set; }

    public bool RegisterCourse(int courseID) {
        // school business logic ...
        return true;
    }
}
```
- The properties of the Student class are used to present the status of a student such as who he/she is, how old, etc.

-  While the methods of the Student class indicate what are the things a student can do, or the behaviors of a student.

- As you may notice, the meanings of the word a model are different when we use it at the different phases of development:

- At design-time: a model usually means a model class.
  - For example, if we say “please create models for the customers and orders,” the meaning is that we want to create a Customer class and an Order class to reflect the customers and orders in the real world.


- At runtime: a model usually means an instance of the model class.
  - For example, if we say “the model of this page is a customer,” we mean the model of a web page is an instance of the Customer class.
---
> ### __The Classification of Models__

- Based on the usage of models, we can classify models into three categories. They are:

 - __Domain models__: domain model classes represent and reflect the real-world objects that participate in the business logic.
   - For example, Student and Teacher objects in a school system, Order and Product objects in a sales management system.

 - __View models__: view model classes are designed for specific views.
      - For example, if we want to show a customer and all his/her orders on the page, we can create a class called CustomerOrdersViewModel and let this class have a Customer type property and an IList<Order> type property.

  - __Data transfer model__: usually, we call them Data Transfer Objects (DTO).
   - Sometimes we have to transfer some temporary combination of data fields from views to controllers, especially when submitting a form or invoking an AJAX call. In these cases, using DTO is a good solution.
---
