<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="UpdatePage.aspx.cs" Inherits="Comp229_Assign03.UpdatePage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server" >
    <div class="jumbotron">
        <label>First Name: </label>
        <asp:TextBox ID="txtFirstName" runat="server" />
        <asp:RequiredFieldValidator ID="fNameReq" runat="server"
                                    ControlToValidate="txtFirstName"
                                    ErrorMessage="Please enter student's first name"
                                    ForeColor="Red" />
        <label>Last Name: </label>
        <asp:TextBox ID="txtLastName" runat="server" />
        <asp:RequiredFieldValidator ID="lNameReq" runat="server"
                                    ControlToValidate="txtLastName"
                                    ErrorMessage="Please enter student's last name"
                                    ForeColor="Red" />
        <label>Enrollment Date:</label>
        <asp:TextBox ID="enrollmentDate" TextMode="Date" runat="server" />
        <asp:RequiredFieldValidator ID="dateReq" runat="server"
                                    ControlToValidate="enrollmentDate"
                                    ErrorMessage="Please select enrollment date"
                                    ForeColor="Red" />
        <asp:Button ID="submitBtn" CssClass="btn btn-success" Text="Add Student" runat="server" OnClick="submitBtn_Click" />
    </div>

</asp:Content>
