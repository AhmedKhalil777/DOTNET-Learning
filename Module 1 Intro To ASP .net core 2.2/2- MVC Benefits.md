# __In The Name of ALLAH__
---
##### GUI applications are event-driven. For a GUI application, whether it is a web application, a mobile application, or a desktop application, we find that we can actually can put all its logic in the event handler methods.
 - For example, in a button event handler method, we can validate the text in text boxes, extract the value from the selected item in a dropdown list, examine if checkboxes are checked, and then talk to the local file system, database or web services to persist the data. We call this methodology rapid-application-development (RAD).
 > RAD is just fine for small applications, but when applications grow larger and larger, the relationships between the UI instances start getting messy. Especially when multiple developers are working on code for the same group of UIs, trying to understand the logic from other developers starts to get harder and harder. The cost of maintaining the code, resolving code conflict, and fixing bugs go up.

 - To avoid these problems, we can do two things:
  - Separate the data and logic from event handlers and centralize them somewhere in order to maximize code reuse
  - For the centralized data and logic, separate them into different roles and responsibilities

- After decades of experiments and polishing the processes, the software industry found that MVC (and its variants) to always be a good and stable solution. It can efficiently eliminate the problems raised by large-scale RAD. The benefits of applying the MVC pattern in large-scale GUI projects include:

 - Robust: developers are restricted to writing code in the correct place. They can easily understand and reuse the code from others.
 - Testable: UI is hard to test, but the models and controller separated from the UI are easy to test with unit test cases. This makes a big improvement in the software quality and development performance.
 - Extensible: for RAD development, the more UI elements that were added, the more complicated the net formed by the UIs. But MVC splits the functionalities of an application into small vertical pillars. Each pillar formed by a suite of controller, views, and models. To expand the feature of the application we just keep adding small pillars and cover the code by unit test cases.
