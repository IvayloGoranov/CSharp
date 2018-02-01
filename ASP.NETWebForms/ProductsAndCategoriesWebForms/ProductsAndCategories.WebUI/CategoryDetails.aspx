<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CategoryDetails.aspx.cs" Inherits="ProductsAndCategories.WebUI.CategoryDetails" %>

<asp:Content ID="categoryDetailsHeader" ContentPlaceHolderID="cphHead" runat="server">
      
    <script type="text/javascript">

        function confirmDelete() {
            return confirm("Are you sure you want to delete selected item?");
        }
    
    </script>
</asp:Content>

<asp:Content ID="categoryDetailsContent" ContentPlaceHolderID="cphMain" runat="server">

    <asp:UpdatePanel ID="upMain" runat="server">
        <ContentTemplate>
            
            <h5 class="red-color">Category Details</h5>
            
            <div class="green-background center-text">
                <asp:Label ID="lblActionStatus" runat="server" EnableViewState="False" CssClass="white-color" />
            </div>
            <div class="red-background center-text">
                <asp:Label ID="lblValidationStatus" runat="server" EnableViewState="False" CssClass="white-color" />
            </div>
            
            <hr>

            <asp:PlaceHolder runat="server" ID="phCategoryDetails">
                
                <div class="overflow-auto">
                    <div class="inline-block">
                        <div class="margin-left-10px margin-top-10px padding-left-37px">
                            <asp:Label ID="lblCategoryName" runat="server" Text="Name*" 
                                       CssClass="width-50percent"/>
                            <asp:TextBox ID="txtCategoryName" runat="server" 
                                                 ValidationGroup="vgCategory"
                                                 CssClass="margin-left-10px width-395px" />
                            <asp:RequiredFieldValidator ID="rfvCategoryName" runat="server" 
                                                                ControlToValidate="txtCategoryName"
                                                                ValidationGroup="vgCategory" 
                                                                ErrorMessage="Category name is required" 
                                                                Display="Dynamic"
                                                                ForeColor="Red"/>
                        </div>

                        <div class="margin-left-10px margin-top-10px">
                            <asp:Label ID="lblDescription" runat="server" Text="Description*" CssClass="float-left padding-top-25px"/>
                            <asp:TextBox ID="txtDescription" runat="server" 
                                         CssClass="margin-left-10px width-395px height-80px"
                                         TextMode="MultiLine"/>
                        </div>
                    </div>
                    <div class="inline-block float-right margin-right-10px margin-top-20px">
                        <div class="vertical-line">
                            <div class="box red-background pointer" onclick="document.getElementById('<%= btnSelectRedColor.ClientID %>').click()">
                                <asp:Button runat="server" id="btnSelectRedColor" style="display:none"
                                            CommandName="ChangeColor"
                                            CommandArgument="Red"
                                            OnCommand="btnChangeColor_Command" />
                            </div>
                            <div class="box green-background pointer" onclick="document.getElementById('<%= btnSelectGreenColor.ClientID %>').click()">
                                <asp:Button runat="server" id="btnSelectGreenColor" style="display:none"
                                            CommandName="ChangeColor"
                                            CommandArgument="Green"
                                            OnCommand="btnChangeColor_Command" />
                            </div>
                            <div class="box blue-background pointer" onclick="document.getElementById('<%= btnSelectBlueColor.ClientID %>').click()">
                                <asp:Button runat="server" id="btnSelectBlueColor" style="display:none"
                                            CommandName="ChangeColor"
                                            CommandArgument="Blue"
                                            OnCommand="btnChangeColor_Command" />
                            </div>
                        </div>
                    </div>

                    <div class="margin-left-10px margin-top-10px">
                        <div class="inline-block margin-top-10px float-left padding-top-5px">
                            <asp:Label ID="lblSelectedColor" runat="server" Text="Selected Color*" />
                        </div>
                        <div class="inline-block margin-left-10px margin-top-10px float-left">
                            <div ID="boxBackgroundColor" runat="server"></div>
                        </div>
                    </div>
                </div>

            </asp:PlaceHolder>

            <hr>
                
            <h5 class="red-color">Products</h5>
            
            <div runat="server" id="divProductsList" class="margin-top-10px">
                <asp:ListView ID="lvProducts" runat="server" 
                              OnItemCommand="lvProducts_ItemCommand">
                    <LayoutTemplate>
                        <table class="inner_data_table">
                            <tr>
                                <th runat="server" id="thProductName">
                                    <asp:Label ID="lblProductName" runat="server" Text="Product Name"/>
                                </th>
                                <th>
                                    <asp:Label ID="lblPrice" runat="server" Text="Price"/>
                                </th>
                                <th>
                                    <asp:Label ID="lblActions" runat="server" Text="Actions"/>
                                </th
                            </tr>
                            <tr id="itemPlaceholder" runat="server">
                            </tr>
                        </table>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr>
                            <td runat="server" id="tdName">
                                <asp:HiddenField runat="server" ID="hfID" Value='<%# Eval("Id") %>' />
                                <asp:TextBox ID="txtProductName" runat="server" 
                                     Text='<%# Eval("Name") %>'
                                     ValidationGroup="vgProduct" />
                                <asp:RequiredFieldValidator ID="rfvProductName" runat="server" 
                                                    ControlToValidate="txtProductName"
                                                    ValidationGroup="vgProduct" 
                                                    ErrorMessage="Product name is required" 
                                                    Display="Dynamic"
                                                    ForeColor="Red"/>
                            </td>
                            <td runat="server" id="tdPrice">
                                <asp:TextBox ID="txtPrice" runat="server" Text='<%# Eval("Price") %>' />
                                    <asp:CustomValidator ID="cvPrice" runat="server"  ErrorMessage='Invalid price' 
                                         ValidationGroup="vgProduct" 
                                         Display="Dynamic"
                                         ForeColor="Red"/>
                                    <asp:RegularExpressionValidator ID="revPrice" runat="server" 
                                        ControlToValidate="txtPrice"
                                        ValidationGroup="vgProduct"
                                        ErrorMessage="Invalid price" 
                                        ValidationExpression="^[0-9]+(,[0-9]{3})*(\.[0-9]{1,2})?$"
                                        ToolTip="Not a valid Price for {0}. Example:" Display="Dynamic"
                                        ForeColor="Red"/>
                            </td>
                            <td runat="server" id="tdActions">
                                <asp:LinkButton ID="lnkEditItem" runat="server" Text="Edit" 
                                                CommandName="EditItem" 
                                                CommandArgument='<%# Eval("Id") %>' 
                                                causesvalidation="true"
                                                validationgroup="vgProduct" 
                                                CssClass="button"/>
                                <asp:LinkButton ID="lnkDeleteItem" runat="server" Text="Delete" 
                                                CommandName="DeleteItem" 
                                                CommandArgument='<%# Eval("Id") %>' 
                                                CssClass="button"
                                                onclientclick="confirmDelete()" />
                            </td>
                        </tr>
                    </ItemTemplate>
                    <EmptyDataTemplate>
                        <table>
                            <tr>
                                <th>
                                    <asp:Label ID="lblTitle" runat="server" Text="Products List"/>
                                </th>
                            </tr>
                            <tr>
                                <th>
                                    <asp:Label ID="lblMessage" runat="server" Text="There are no products available."/>
                                </th>
                            </tr>
                        </table>
                    </EmptyDataTemplate>
                </asp:ListView>
            </div>

            <table class="inner_data_table">
                <tr>
                    <td runat="server" id="tdName">
                        <asp:TextBox ID="txtNewProductName" runat="server" 
                                     ValidationGroup="vgNewProduct" />
                        <asp:RequiredFieldValidator ID="rfvNewProductName" runat="server" 
                                                    ControlToValidate="txtNewProductName"
                                                    ValidationGroup="vgNewProduct" 
                                                    ErrorMessage="Product name is required" 
                                                    Display="Dynamic"
                                                    ForeColor="Red"/>
                    </td>
                    <td runat="server" id="tdPrice">
                        <asp:TextBox ID="txtNewPrice" runat="server" />
                        <asp:CustomValidator ID="cvNewPrice" runat="server"  Text="*" ErrorMessage='' 
                                         ValidationGroup="vgNewProduct" 
                                         Display="Dynamic"
                                         ForeColor="Red"/>
                        <asp:RegularExpressionValidator ID="revPrice" runat="server" 
                                        ControlToValidate="txtNewPrice"
                                        ValidationGroup="vgNewProduct"
                                        ErrorMessage="Invalid price" 
                                        ValidationExpression="^[0-9]+(,[0-9]{3})*(\.[0-9]{1,2})?$"
                                        ToolTip="Not a valid Price for {0}. Example:" Display="Dynamic"
                                        ForeColor="Red"/>
                    </td>
                    <td runat="server" id="tdActions" style="width: 155px">
                        <asp:LinkButton ID="lnkAddItem" runat="server" Text="Add" 
                                                OnClick="lnkAddItem_Click" 
                                                causesvalidation="true"
                                                validationgroup="vgNewProduct" 
                                                CssClass="button"/>
                    </td>
                </tr>
            </table>

            <hr>

            <asp:PlaceHolder runat="server" ID="phSaveDelete">
                <div class="cd-btnDelete inline-block">
                    <asp:LinkButton ID="btnDelete" runat="server" 
                                    Text="Delete"
                                    OnClick="btnDelete_Click"
                                    CssClass="button"/>
                </div>
                <div class="cd-btnSave float-right inline-block">
                    <asp:LinkButton ID="btnSave" runat="server" 
                                    Text="Save" 
                                    OnClick="btnSave_Click"
                                    causesvalidation="true"
                                    validationgroup="vgCategory" 
                                    CssClass="button"/>
                </div>
            </asp:PlaceHolder>
        
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
