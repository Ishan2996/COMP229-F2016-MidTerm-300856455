<%@ Page Title="Todo Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TodoDetails.aspx.cs" Inherits="COMP229_F2016_MidTerm_300856455.TodoDetails" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  <div class="container">
        <div class="row">
            <div class="col-md-offset-3 col-md-6">

                <h1>Todo Details</h1>
                <h5>All Fields are required</h5>
                <br />

                <div class="form-group">
                    <label class="control-label" for="LastNameTextBox">Todo Name</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="LastNameTextBox" 
                        placeholder="Last Name" required="true"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label class="control-label" for="FirstNameTextBox">Todo Notes</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="FirstNameTextBox" 
                        placeholder="First Name" required="true"></asp:TextBox>
                </div>

                <div class="text-right">
                    <asp:Button Text="Cancel" ID="CancelButton" CssClass="btn btn-warning btn-lg" runat="server"
                        UseSubmitBehavior="false" CausesValidation="false" OnClick="CancelButton_Click" />
                    <asp:Button Text="Save" ID="SaveButton" CssClass="btn btn-primary btn-lg" runat="server"
                        OnClick="SaveButton_Click" />
                </div>

                </div>   
            </div>
      </div>
</asp:Content>
