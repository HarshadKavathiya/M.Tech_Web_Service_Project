<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #form1 {
            text-align: center;
            background-color: #CC6600;
        }
    </style>
</head>
<body style="background-color: #CC6600">
    <form id="form1" runat="server">
        <h1>
        <asp:TextBox ID="TextBox1" runat="server" Font-Size="35px" Height="72px" Width="473px"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Validate Website" Font-Size="30px" Height="78px" Width="259px" />
        <br />
            <br />
            Alexa Rank :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <br />
            Google PageRank:
            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            Equivalent AlexaRank Value :&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
            <br />
            Equivalent PageRank Value :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
            <br />
            Value Calculated By Algorithm: <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
        <br />
        <br />
        </h1>
    </form>
</body>
</html>
