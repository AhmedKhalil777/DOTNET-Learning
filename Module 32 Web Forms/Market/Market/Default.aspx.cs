using Newtonsoft.Json.Linq;
using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Drawing;
using System.EnterpriseServices.CompensatingResourceManager;
using System.IdentityModel.Protocols.WSTrust;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime;
using System.Security.Cryptography;
using System.Web;
using System.Web.Providers.Entities;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;



public class Mobile
{
    public string ModelName { get; set; }
    public decimal Price { get; set; }
}
public partial class _Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var culture = UICulture;
        if (!IsPostBack)
        {
            Validate();
        }
    }
    protected override void OnPreInit(EventArgs e)
    {
        //Check the IsPostBack property to determine whether this is the first time the page is being processed. The IsCallback and IsCrossPagePostBack properties have also been set at this time.

        //Create or re-create dynamic controls.

        //Set a master page dynamically.

        //Set the Theme property dynamically.

        //Read or set profile property values.
        base.OnPreInit(e);
    }
    protected override void OnInit(EventArgs e)
    {
        //    Raised after all controls have been initialized and any skin
        //    settings have been applied. The Init event of individual controls
        //    occurs before the Init event of the page.
        //Use this event to read or initialize control properties.
        base.OnInit(e);
    }


    protected override void OnInitComplete(EventArgs e)
    {
        //   Raised at the end of the page's initialization stage.
        //   Only one operation takes place between the Init and InitComplete events:
        //      tracking of view state changes is turned on. 4
        //      View state tracking enables controls to persist any values that are programmatically added to the ViewState collection. Until view state tracking is turned on, any values added to view state are lost across postbacks. Controls typically turn on view state tracking immediately after they raise their Init event.

        //Use this event to make changes to view state that you want to make sure are persisted after the next postback.
        //

        // ViewState
        base.OnInitComplete(e);
    }


    protected override void OnPreLoad(EventArgs e)
    {
        // Raised after the page loads view state for itself and all controls,
        // and after it processes postback data that is included with the Request instance.
        base.OnPreLoad(e);
    }
    protected override void OnLoad(EventArgs e)
    {

        //The Page object calls the OnLoad method on the Page object,
        //and then recursively does the same for each child control until the page and all
        //controls are loaded.
        //The Load event of individual controls occurs after the Load event of the page.

        //Use the OnLoad event method to set properties in controls and to establish database connections.
        base.OnLoad(e);
    }

    protected override void OnLoadComplete(EventArgs e)
    {

        //Raised at the end of the event-handling stage.

        //Use this event for tasks that require that all other controls on the page be loaded.
        base.OnLoadComplete(e);
    }


    protected override void OnPreRender(EventArgs e)
    {
        // All controls are loaded
        // Settng the Data binding objectived after that 
        base.OnPreRender(e);
    }

    protected override void OnPreRenderComplete(EventArgs e)
    {
        // All Data binding set -- DataSourceId
        base.OnPreRenderComplete(e);
    }
    protected override void OnSaveStateComplete(EventArgs e)
    {
        //Raised after view state and control state have been saved for the page
        //and for all controls. Any changes to the page or controls at this point
        //affect rendering, but the changes will not be retrieved on the next postback


        base.OnSaveStateComplete(e);
    }

    protected override void OnUnload(EventArgs e)
    {

        //Raised for each control and then for the page.


        //In controls, use this event to do final cleanup for specific controls,
        //such as closing control-specific database connections.

        //For the page itself, use this event to do final cleanup work,
        //such as closing open files and database connections,
        //or finishing up logging or other request-specific tasks.
        base.OnUnload(e);
    }



    protected override void OnDataBinding(EventArgs e)
    {
        base.OnDataBinding(e);
    }


    protected override void OnError(EventArgs e)
    {
        base.OnError(e);
    }


    protected override void OnCommitTransaction(EventArgs e)
    {
        base.OnCommitTransaction(e);
    }

    protected override void OnAbortTransaction(EventArgs e)
    {
        base.OnAbortTransaction(e);
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
        return new List<Mobile> { new Mobile { ModelName = "IPhone", Price = 21313 } };
    }
}