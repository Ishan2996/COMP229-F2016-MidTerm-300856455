<%@ Page Title="Todo List" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TodoList.aspx.cs" Inherits="COMP229_F2016_MidTerm_300856455.TodoList" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-offset-2 col-md-8">
                <h1 class="h6"><b>Todo List</b></h1>

            <asp:GridView ID="TodoGridView" runat="server" AutoGenerateColumns="false"
                CssClass="table table-bordered table-striped table-hover">
                <Columns>
                    <asp:BoundField DataField="TodoDescription" HeaderText="ToDo Tasks" Visible="true" />
                    <asp:BoundField DataField="TodoNotes" HeaderText="Notes" Visible="true" />
                    <asp:BoundField DataField="Completed" HeaderText="Completed" Visible="true" />

                </Columns>
            </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>



