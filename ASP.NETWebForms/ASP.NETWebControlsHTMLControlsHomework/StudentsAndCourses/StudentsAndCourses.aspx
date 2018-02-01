<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentsAndCourses.aspx.cs" 
    Inherits="StudentsAndCourses.StudentsAndCourses" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>Students And Courses</title>
    <link href="Styles.css" rel="stylesheet" />
</head>

<body>
    <div id="wrapper">
        <form id="mainForm" runat="server">
            <div class="form-pair">
                <asp:Label ID="firstNameLabel" CssClass="label" runat="server">First name:</asp:Label>
                <asp:TextBox ID="firstNameTextBox"  CssClass="text-box" runat="server"/>
            </div>
            <div class="form-pair">
                <asp:Label ID="lastNameLabel" CssClass="label" runat="server">Last name:</asp:Label>
                <asp:TextBox ID="lastNameTextBox"  CssClass="text-box" runat="server"/>
            </div>
            <div class="form-pair">
                <asp:Label ID="facultyNumberLabel" CssClass="label" runat="server">Faculty number:</asp:Label>
                <asp:TextBox ID="facultyNumberTextBox"  CssClass="text-box" runat="server"/>
            </div>
            <asp:DropDownList ID="specialtyDropDownList" CssClass="drop-down-list" runat="server">
                <asp:ListItem Value="Computer Science">Computer Science</asp:ListItem>
                <asp:ListItem Value="Finance">Finance</asp:ListItem>
                <asp:ListItem Value="Business Administartion">Business Administartion</asp:ListItem>
            </asp:DropDownList>
             <asp:ListBox ID="coursesListBox" CssClass="list-box" runat="server" 
                    SelectionMode="Multiple">
                <asp:ListItem Value="ASP.Net">ASP.Net</asp:ListItem>
                <asp:ListItem Value="Mathematical Statistics">Mathematical Statistics</asp:ListItem>
                <asp:ListItem Value="SME Administration">SME Administration</asp:ListItem>
            </asp:ListBox>
            <asp:Button ID="submitButton" runat="server" Text="Submit" OnClick="ButtonSubmit_Click"/>
            <h2>Data submitted:</h2>
            <asp:Literal ID="resultsLiteral" runat="server" Mode="Transform"/>
        </form>
    </div>
</body>

</html>
