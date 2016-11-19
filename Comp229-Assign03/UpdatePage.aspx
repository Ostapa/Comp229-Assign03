<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="UpdatePage.aspx.cs" Inherits="Comp229_Assign03.UpdatePage" %>

<%-- Assignemnt 3 - Comp229-007
     Author: Ostap Hamarnyk --%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server" >
    <div class="jumbotron">
        <div class="form-group">
            <h1 class="h1">Update Student Info</h1>
            
            <label for="txtFirstName">First Name: </label>
            <asp:TextBox CssClass="form-control" ID="txtFirstName" Placeholder="Joe" runat="server" />
            
            <label>Last Name: </label>
            <asp:TextBox CssClass="form-control" ID="txtLastName" Placeholder="Doe" runat="server" />
            
            <label>Enrollment Date:</label>
            <asp:TextBox CssClass="form-control en-date" Placeholder="2016-03-10" ID="enrollmentDate" TextMode="DateTime" runat="server" />
            <asp:RegularExpressionValidator ID="dateReg" runat="server"
                ControlToValidate="enrollmentDate"
                ValidationExpression="^[0-9]{4}-[0-9]{2}-[0-9]{2}$"
                ErrorMessage ="Please enter date in the following format YYYY-MM-DD"
                ForeColor="Red" />
            
            <asp:Button ID="submitBtn" CssClass="btn btn-primary" Text="Update" runat="server" OnClick="submitBtn_Click" />
            <asp:Button ID="cancelBtn" CssClass="btn btn-danger" Text="Cancel" runat="server" OnClick="cancelBtn_Click" />
        </div>
    </div>

</asp:Content>
