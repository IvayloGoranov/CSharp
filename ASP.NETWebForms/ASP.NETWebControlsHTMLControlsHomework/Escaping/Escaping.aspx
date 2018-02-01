<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Escaping.aspx.cs" 
    Inherits="Escaping.Escaping" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Escaping</title>
    <link href="Styles.css" rel="stylesheet" />
</head>

<body>
    <div id="wrapper">
        <form id="mainForm" runat="server">
            <asp:TextBox ID="firstTextBox" CssClass="text-box" runat="server"/>
            <asp:Button ID="showTextButton" runat="server" Text="Show Text" OnClick="ShowTextButton_Click"/>
            <asp:Label ID="unescapedTextLabel" CssClass="label" runat="server">Unescaped text:</asp:Label>
            <asp:TextBox ID="unescapedTextBox"  CssClass="text-box" runat="server"/>
        </form>
    </div>
</body>

</html>
