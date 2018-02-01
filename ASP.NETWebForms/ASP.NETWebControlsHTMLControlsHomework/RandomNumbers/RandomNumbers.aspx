<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RandomNumbers.aspx.cs" Inherits="RandomNumbers.RandomNumbers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Generate random Number</title>
    <link href="Styles.css" rel="stylesheet" />
</head>

<body>
    <div id="wrapper">
        <p>Enter interval borders to generate a number in the specified interval.</p>
        <form id="mainForm" runat="server">
            <label for="textFieldFirstNumber">First number:</label>
            <input id="textFieldFirstNumber" type="text" runat="server" />
            <label for="textFieldSecondNumber">Second number:</label>
            <input id="textFieldSecondNumber" type="text" runat="server" />
            <label for="textFieldGeneratedNumber">Generated number:</label>
            <input id="textFieldGeneratedNumber" type="text" runat="server" />
            <input id="generateNumberButton" type="button" runat="server" value="Generate Random Number"
                onserverclick="ButtonGenerate_Click"/>
        </form>
    </div>
</body>
</html>
