# IN The Name OF ALLAH
---
## Lab intro
---
- In ASP.NET Core, we use views to render data.

- The result of the view rendering is the HTML content.
- The data rendered by a view is called the __view model__.
- In this lesson, we will learn about __strongly-typed view models__ and two kinds of the __loosely-typed view models.__
---
## __Strongly-Typed View Model__
- If not explicitly stated, when mentioning view model, the view model is strongly-typed.

- When we design a view, we can set the view model type for this view.
- The view, actually a generic class, has a property named Model.
- The type of the Model property is just the view model type.
- In the runtime, the Model property's value is an instance of the view model type, which is the actual view model.

- In the code below, we set a view's view model type to be the Actor class we created in the last lesson, and we also render the view model in an HTML table.
- The view engine of ASP.NET Core is known as Razor, and Razor has its own syntax which we will discuss in Module 04.
```
@model HelloMVC.Models.Actor
<html>
<head>
    <title>Actor Detail</title>
</head>
<body>
    <h2>Actor Detail</h2>
    <table border="1">
        <tr>
            <td>ID</td>
            <td>@Model.ActorID</td>
        </tr>
        <tr>
            <td>Name</td>
            <td>@($"{Model.FirstName} {Model.LastName}")</td>
        </tr>
    </table>
</body>
</html>
```
- The code __@model HelloMVC.Models.Actor__ tells the view that the type of its Model property is the Actor class in the HelloMVC.Models namespace.
- The skeleton of the view is created with HTML tags which can be copied from a designer polished static HTML page.

- The code __\<td>@Model.ActorID\</td>__ and __\<td>@($"{Model.FirstName} {Model.LastName}")\</td>__ is where the data is rendered.
- After the rendering, you will see code like __\<td>101\</td>__ and __\<td>Matt Damon\</td>__ which means the data is shown in table cells.

- Since the view class has __only one Model property__, each view has at most one strongly-typed view model.
- Therefore if you want to show more than one object on the page, you have to create a __composite view model__.
- For example, if you want to show the information for a director with all the films directed by him or her, you may want to design the view model class like this example:
```
public class DirectorFilmsViewModel {
    public Director Director { get; set; }
    public IList<Film> Films { get; set; }
}
```
- Let's wrap it up:

- We can use the domain model class as the view model class if the view just renders a domain model object
- We have to create the composite view model class for specific views if the view renders more than one object
---
## __Loosely-Typed View Model__
- For some miscellaneous information, it is usually not worth the effort to create a strongly-typed view model class for them.
-  For example, the page title shows in the __\<title>\</title> element__, it's not worth the effort required, to create a class just for one property, like this:
```
public class HomePageViewModel{
    public string Title {get; set;}
}
```
- Or if you create an extra property in the existing view model class like:
```
public class DirectorFilmsViewModel {
    public Director Director { get; set; }
    public IList<Film> Films { get; set; }
    public string Title {get; set;}
}
```
- It looks weird because the Director and Films are domain models and the Title is just a miscellaneous piece of information.

-  We're not saying you can't do this, but ASP.NET Core has another way to deal with this kind of data - the loosely-typed view model.

- For some historical reasons, there are two kinds of loosely-typed view models we can use:

-  __ViewData property__:
> a dictionary class that implements the IDictionary<string, object> interfaces

- __ViewBag property__:
> a dynamic object

- If we do the assignment ViewData["title"] = "Film Details" or ViewBag.title = "Film Details" in the logic code, we can render the data in the view like this:

 > __\<title>@ViewData["title"]\</title>__

- or

 > __\<title>@ViewBag.title\</title>.__

- These two loosely-typed view models can also carry __complex objects__.
-  For example, if we do the assignment ViewData["film"] = new Film{Name = "Transformer", Year = 2017}, we should render the data in the view using code like this:

 > __\<span>@((ViewData["film"] as File).Name)\</span>.__

- In this case, we have to covert the object type value back to the Film type value.

- Another example is if we do the assignment ViewBag.film = new Film{Name = "Transformer", Year = 2017}, we should render the data in the view using code like this:

 > __\<span>@ViewBag.film.Name\</span>__

- This time the code is shorter, but due to no intellisense prompts for the dynamic object, there could be a chance for typos in your code such as:

__@ViewBag.file.Name__

 - and

__@ViewBag.Film.Name.__

- Therefore we should limit the use of loosely-typed view models as much as possible and not use them to carry complex objects - that's the job of strongly-typed view models.
