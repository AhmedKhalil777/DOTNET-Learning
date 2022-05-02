# DOTNET-Learning
This is for our dotnet study
# In the Name of Allah
---
## MVC
 - MVC is the abbreviation for Model-View-Controller.
 - Model-View-Controller (MVC) is a software architectural pattern for implementing graphical user interface (GUI) computer applications.
 - If an application does not have graphical user interfaces, there's no way to apply the concepts of MVC to it, since the View approximates the graphical user interface portion.
 ---
 ## MVC is a Pattern
> When discussing software development, a pattern is a combination of regular roles. In a pattern, each role has its responsibilities and interacts with other roles.
 - > Software is designed to process data. After a long observation, people found the data processing cycle of GUI applications were composed of these three steps:
    - The application shows data to users through the user interface
    - Users change the data and express the intentions by operating the user interface
    - The application (with its logic) process the data and responds to the user

  - How many roles are involved in this process?

      - he answer is three. They are __data__, __user interface__, and __logic__. What about the user? Why is the user not a role? Since the user is not a part of the application, it cannot be a role.

- We can summarize the roles and their relationships in the table below:


 | Role           | responsibilities    |
 | :-------------: | :-------------: |
 | Data      | Carries the information shown to or collected from the users     |
 | User interface     | Show data, collect data, pass operations to the logic     |
 | logic    | Process data, respond to user operations, choose proper user interface to show data    |
 - In the long evolutionary history, based on their responsibilities, the roles of **data**, **user interface**, and **logic** have had their names changed to __model__, __view__ and __controller__, which is more appropriate and suitable. So, we can redraw the table as:


 | Role           | responsibilities    |
 | :------------- | :------------- |
 | Model       |	Carries the information shown to or collected from the users     |
 | View      |	Show data, collect data, pass operations to the logic   |
 | Controller    |	Process data, respond to user operations, choose proper user interface to show data|

+  Controller:
  + Controller responds to the commands from user
  + Controller manipulates models
  + Controller picks proper views for models or picks proper models for views
  + Controller can ask the view to show the model

+ View:
  + View passes user's commands/operations to the controller
  + View __may or may not__ know the type of its model
  + View won't know its model instance (the actual view model) until the controller assigns one
  + View knows how to __render__ the model when the controller asks it to do so
  + View won't manipulate its model __directly__, only the __controller__ can manipulate models


-   Model:
  - Model can have business logic, such as persisting the data to a database
  - Model will be manipulated by the controller and be rendered by a view
  - Model won't actively interact with controller, which means the model cannot manipulate the controller
  - Model won't actively interact with a view, which means the model cannot manipulate a view

####   the Mode-View-Presenter (MVP) pattern
#### the Model-View-ViewModel (MVVM) pattern.
#### the Model-view-Template  (MVT) pattern .

- The view knows its model and can manipulate the model directly
- The view's model (view model) responds to the user operations directly
- The view's model (view model) can actively notify the view how to render it (the model)
- The controller's responsibilities are redistributed to view model
Because the controller can disappear completely from a well-designed, model-enhanced pattern, the name of MVC should change to MV. But the name of MV is too short, ambiguous, and doesn't highlight the enhanced view-model, hence the name Model-View-ViewModel (MVVM)was born.
