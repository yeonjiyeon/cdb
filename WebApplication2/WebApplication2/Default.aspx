﻿<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication2._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

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

         <div class="col-md-4">
            <h2>Web Hosting</h2>
            <p>
               asp .NET 시작합니다 잘부탁합니다</p>
             <p>
                 &nbsp;사용자명
                <asp:TextBox ID="tbUserName" runat="server" Width="128px"></asp:TextBox>&nbsp;
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" Width="65px"/>
&nbsp;&nbsp;&nbsp;&nbsp;
            </p>
             <p>
               &nbsp;&nbsp; 암호&nbsp;
                 <asp:TextBox ID="tbPassword" runat="server" TextMode="Password" Width="138px"></asp:TextBox>
            </p>
             <p>
                 <asp:Label ID="lblCong" runat="server"></asp:Label>
            </p>
            <p>
                <a class="btn btn-default" href="Customer.aspx">회원가입 &raquo;</a>
            </p>
        </div>
    </div>

</asp:Content>
