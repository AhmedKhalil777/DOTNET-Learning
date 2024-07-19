using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;



public class Mobile
{
    public string ModelName { get; set; }
    public decimal Price { get; set; }
}
public partial class _Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    [WebMethod] // POST
    public static string SayHello(string name)
    {
        return "Hello " + name;
    }

    [WebMethod]
    [ScriptMethod(UseHttpGet = true)]
    public static List<Mobile> GetMobileList()
    {
        return new List<Mobile> { new Mobile { ModelName = "IPhone" , Price = 21313 } };
    }
}