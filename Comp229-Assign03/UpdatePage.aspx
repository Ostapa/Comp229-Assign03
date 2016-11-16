<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="UpdatePage.aspx.cs" Inherits="Comp229_Assign03.UpdatePage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server" >
    <div class="jumbotron">
        <div class="form-group>">
            <label for="txtFirstName">First Name: </label>
            <asp:TextBox CssClass="form-control" ID="txtFirstName" runat="server" />
        
            <label>Last Name: </label>
            <asp:TextBox CssClass="form-control" ID="txtLastName" runat="server" />
        
            <label>Enrollment Date:</label>
            <asp:TextBox CssClass="form-control" ID="enrollmentDate" TextMode="DateTime" runat="server" />
        
            <asp:Button ID="submitBtn" CssClass="btn btn-success" Text="Update" runat="server" OnClick="submitBtn_Click" />
        </div>
       
    </div>

</asp:Content>
