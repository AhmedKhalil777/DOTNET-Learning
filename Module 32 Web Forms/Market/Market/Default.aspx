<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <br />
<button type="button" id="SayHello">Say Hello</button>

<br /><br /><br />
<button type="button" id="GetMobileList">Get Mobile List</button>

<br /><br /><br />
    <button type="button" id="UpdateMobilePrice">Update Mobile Price</button>

<br /><br /><br />
<table class="tblMobileList table">
    <thead>
        <tr>
            <th>
                <b>Name</b>
            </th>
            <th>
                <b>Price</b>
            </th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td><span class="name"></span></td>
            <td><span class="price"></span></td>
        </tr>
    </tbody>
</table>


<script type="text/javascript">

    $("#SayHello").click(function () {
        $.ajax({
            type: "POST", //POST
            url: "Default.aspx/SayHello",
            data: "{name: 'Mark'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (msg) {
                alert(msg.d);
            },
            failure: function (response) {
                alert(response.d);
            },
            error: function (response) {
                alert(response.d);
            }
        });
    });

    $("#GetMobileList").click(function () {
        $.ajax({
            type: "GET", //GET
            url: "Default.aspx/GetMobileList",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (msg) {
                DrawTable(msg.d);
            },
            failure: function (response) {
                alert(response.d);
            },
            error: function (response) {
                alert(response.d);
            }
        });
    });

    function DrawTable(mobiles) {
        $.each(mobiles, function (i, item) {
            var $tr = $('<tr>').append(

                $('<td>').text(item.ModelName),
                $('<td>').text(item.Price),
            ).appendTo('.tblMobileList')
        });
    }
</script>

    <div class="jumbotron">
        <h1>ASP.NET</h1>
        <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.</p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Getting started</h2>
            <p>
                ASP.NET Web Forms lets you build dynamic websites using a familiar drag-and-drop, event-driven model.
            A design surface and hundreds of controls and components let you rapidly build sophisticated, powerful UI-driven sites with data access.
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301948">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Get more libraries</h2>
            <p>
                NuGet is a free Visual Studio extension that makes it easy to add, remove, and update libraries and tools in Visual Studio projects.
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301949">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Web Hosting</h2>
            <p>
                You can easily find a web hosting company that offers the right mix of features and price for your applications.
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301950">Learn more &raquo;</a>
            </p>
        </div>
    </div>
</asp:Content>
