<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Customer.aspx.cs" Inherits="WebApplication2.Customer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
        .form1 {
            
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            사용자 ID<asp:TextBox ID="TextBox1" runat="server" style="margin-left: 10px" Width="210px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="등록" Width="131px" />
            &nbsp;&nbsp;
            <asp:Label ID="lblConfirm" runat="server" Text="Label" ForeColor="Red"></asp:Label>
            <br />
            <br />
            이&nbsp;&nbsp;&nbsp; 름<asp:TextBox ID="TextBox2" runat="server" style="margin-left: 17px" Width="207px"></asp:TextBox>
            <br />
            <br />
            전화번호<asp:TextBox ID="TextBox3" runat="server" style="margin-left: 17px" Width="218px"></asp:TextBox>

            &nbsp;&nbsp;&nbsp;<asp:Button ID="Button2" runat="server" Text="돌아가기" Visible="False" Width="139px" onClientClick="window.open('Default.aspx')"/>
            <br />
            <br />
            암&nbsp;&nbsp;&nbsp; 호 <asp:TextBox ID="TextBox4" runat="server" style="margin-left: 17px" Width="207px" TextMode="Password"></asp:TextBox>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <br />
            <br />
            <br />
            <br />
        </div>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
