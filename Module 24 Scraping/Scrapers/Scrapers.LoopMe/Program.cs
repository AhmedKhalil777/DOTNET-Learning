// This sample is how to create a Denial of Service on a service 
// The logic behind the call is to increase the number of visits on a github profile page

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
var reauests = 
    Enumerable.Range(1, 10).Select(x=> (x,  new ChromeDriver("..\\..\\..\\..\\chromedriver_win32")))
        .ToList();

int visitors = 0;

Parallel.ForEach(reauests, new ParallelOptions{ MaxDegreeOfParallelism = 10},driver =>
{
    while (visitors < 15000)
    {
        try
        {
            driver.Item2.Navigate().GoToUrl("https://camo.githubusercontent.com/ea54f67f92f5e64b338c28bbdbcc2054f3bfeac674d49c6e5f4856cec9fb76ea/687474703a2f2f657374727579662d6769746875622e617a75726577656273697465732e6e65742f6170692f56697369746f724869743f757365723d41686d65644b68616c696c373737267265706f3d4126636f756e74436f6c6f723d253233374231453741");
            var element = driver.Item2.FindElement(By.TagName("title"));
            visitors = int.Parse(element.Text.Replace("visitors: ", ""));
            Console.WriteLine($">>Thread {Thread.CurrentThread.ManagedThreadId} , Driver {driver.x} =>  Visitors : {visitors}");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

    }
});

