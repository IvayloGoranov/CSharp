<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CategoriesList.aspx.cs" Inherits="ProductsAndCategories.WebUI.CategoriesList" %>

<asp:Content ID="categoriesListContent" ContentPlaceHolderID="cphMain" runat="server">

    <asp:UpdatePanel ID="upMain" runat="server">
        <ContentTemplate>
            <%--<asp:ObjectDataSource ID="odsCategoriesList" runat="server" TypeName="ProductsAndCategories.BusinessObject.Categories"
                                  SelectMethod="GetFilteredCategories" SelectCountMethod="GetCount" DeleteMethod="Delete">
                <SelectParameters>
                    <asp:Parameter Name="itemsCount" Type="Int32" DefaultValue="0" />
                    <asp:Parameter Name="nameFilter" Type="String" ConvertEmptyStringToNull="True" />
                </SelectParameters>
            </asp:ObjectDataSource>--%>

            <h5 class="red-color">Category List</h5>
            
            <div class="green-background center-text">
                <asp:Label ID="lblActionStatus" runat="server" EnableViewState="False" CssClass="white-color" />
            </div>
            
            <hr>

            <asp:PlaceHolder runat="server" ID="phFilter">
                <div class="cl-divFilterPanel">
                    <asp:Panel ID="pnlFilterBy" runat="server" DefaultButton="lnkSearch">
                        <asp:Label ID="lblNameFilter" Text="Filter by:" runat="server" CssClass="margin-left-10px"/>
                        <asp:TextBox ID="txtNameFilter" runat="server" CssClass="margin-left-10px"/>
                        <asp:LinkButton ID="lnkSearch" runat="server" 
                                        Text="Search" 
                                        OnClick="lnkSearch_Click" 
                                        CssClass="margin-left-10px button"/>
                        <asp:LinkButton ID="lnkReset" runat="server" 
                                        Text="Reset" 
                                        OnClick="lnkReset_Click" 
                                        CssClass="margin-left-10px button"/>
                    </asp:Panel>
               </div>
            </asp:PlaceHolder>

            <hr>
            
            <asp:PlaceHolder runat="server" ID="phAddDelete">
                <div class="cl-btnDeleteSelected inline-block">
                    <asp:LinkButton ID="btnDeleteSelected" runat="server" 
                                    Text="Delete"
                                    OnClick="btnDeleteSelected_Click"
                                    CssClass="button"/>
                </div>
                <div class="cl-btnAdd float-right inline-block">
                    <asp:LinkButton ID="btnAdd" runat="server" 
                                    Text="Add New" 
                                    OnClick="btnAdd_Click" 
                                    CssClass="button"/>
                </div>
            </asp:PlaceHolder>

            <hr>

            <div runat="server" id="divCategoriesList" class="margin-top-10px">
                <asp:ListView ID="lvCategories" runat="server" 
                              OnItemCommand="lvCategories_ItemCommand"
                              OnDataBound ="lvCategories_DataBound">
                    <LayoutTemplate>
                        <table class="inner_data_table">
                            <tr>
                                <th runat="server" id="thSelected">
                                    <asp:CheckBox runat="server" ID="chkSelectAll" oncheckedchanged="chkSelectAll_CheckedChanged" AutoPostBack="true"/>
                                </th>
                                <th runat="server" id="thOrdering">Order</th>
                                <th>
                                    <asp:Label ID="lblCategoryName" runat="server" Text="Category Name"/>
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
                        <tr class="<%# GetColorAsClass(Eval("Color")) %>">
                            <td>
                                <asp:CheckBox runat="server" ID="chkSelected" />
                                <asp:HiddenField runat="server" ID="hfID" Value='<%# Eval("Id") %>' />
                            </td>
                            <td>                                
                                <asp:ImageButton ID="btnMoveUp" runat="server" 
                                                 ImageUrl='<%# UpButtonImage(Container.DataItem) %>'
                                                 CommandName="MoveUp" 
                                                 CommandArgument='<%# Eval("OrderNo") %>' 
                                                 Height="16px" Width="16px"
                                                 ToolTip="Move up" AlternateText="Move up"
                                                 Visible='<%# Container.DataItemIndex != 0 %>'/>
                                &nbsp;
                                <asp:ImageButton ID="btnMoveDown" runat="server" 
                                    ImageUrl='<%# DownButtonImage(Container.DataItem) %>'
                                    CommandName="MoveDown" 
                                    CommandArgument='<%# Eval("OrderNo") %>' 
                                    Height="16px" Width="16px"
                                    ToolTip="Move down" AlternateText="Move down" />
                            </td>
                            <td runat="server" id="tdName">
                                <%# Eval("Name") %>
                            </td>
                            <td runat="server" id="tdPrice">
                                <%# Eval("ProductsTotalPrice") %>
                            </td>
                            <td runat="server" id="tdActions">
                                <asp:LinkButton ID="lnkEdit" runat="server" Text="Edit" 
                                                CommandName="EditItem" 
                                                CommandArgument='<%# Eval("Id") %>' 
                                                CssClass="button"/>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <EmptyDataTemplate>
                        <table>
                            <tr>
                                <th>
                                    <asp:Label ID="lblTitle" runat="server" Text="Categories List"/>
                                </th>
                            </tr>
                            <tr>
                                <th>
                                    <asp:Label ID="lblMessage" runat="server" Text="There are no categories available."/>
                                </th>
                            </tr>
                        </table>
                    </EmptyDataTemplate>
                </asp:ListView>
            </div>

            <div class="cl-view-more" id="items-count-info" onclick="document.getElementById('<%= btnViewMore.ClientID %>').click()">
                <span>Showing 
                    <asp:Literal ID="ltItemsToShowCount" runat="server"/>
                    of 
                    <asp:Literal ID="ltAllItemsCount" runat="server"/> 
                    items
                </span>
                <asp:Button runat="server" id="btnViewMore" style="display:none" onclick="btnViewMore_Click" />
            </div>
        
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
