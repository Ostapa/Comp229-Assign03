<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="HomePage.aspx.cs" Inherits="Comp229_Assign03.Scripts.HomePage" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server" >
    <div class="container">
        <div class="jubmbotron-fluid">
            <div class="row">
                <img class="col-md-6 center" src="Assets/subrankaLogo.png" />
                <div class="row">
                    <h1 class="display-3 col-md-6"><span class="align-middle">Subranka College</span></h1>
                    <div class="col-md-6">
                        <asp:Repeater ID="studentNames" runat="server" OnItemCommand="studentNames_ItemCommand">   
                        <HeaderTemplate>
                            <table class="table table-hover">
                                <thead>
                                    <tr>
                                        <th>First Name</th>
                                        <th>Last Name</th>
                                    </tr>
                                </thead>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tbody>
                                <tr>
                                    <td><%# Eval("FirstMidName") %></td>
                                    <td><%# Eval("LastName") %></td>
                                    <td><asp:Label ID="studentId" Visible="false" runat="server" Text='<%# Eval("StudentID") %>' /></td>
                                    <td><asp:ImageButton ID="infoButton" runat="server"
                                                     AlternateText="Info icon"
                                                     ImageUrl="~/Assets/Icons/i_icon.png" />
                                    </td>
                                </tr>
                            </tbody>
                        </ItemTemplate> 
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>                                                 
                    </asp:Repeater>
                    </div>
                    <div class="form-group">
                        <label for="txtFirstName">*First Name: </label>
                        <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control" />
                        <asp:RequiredFieldValidator ID="firstNameReq" runat="server"
                            ControlToValidate="txtFirstName"
                            ErrorMesssage="This field is required"
                            ForeColor="Red" 
                            ValidationGroup="newStudent"/>
                        <label for="txtLastName">*Last Name: </label>
                        <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control" />
                        <asp:RequiredFieldValidator ID="lastNameReq" runat="server"
                            ControlToValidate="txtLastName"
                            ErrorMesssage="This field is required"
                            ForeColor="Red" 
                            ValidationGroup="newStudent" />
                        <label for="enrollmentDate">*Enrollment Date: </label>
                        <asp:TextBox ID="enrollmentDate" runat="server"
                            CssClass="form-control" Type="Date" />
                        <asp:RequiredFieldValidator ID="dateReq" runat="server"
                            ControlToValidate="enrollmentDate"
                            ErrorMesssage="This field is required"
                            ForeColor="Red" 
                            ValidationGroup="newStudent" />
                        <asp:Button ID="addStudent" CssClass="btn btn-success" ValidationGroup="newStudent" OnClick="addStudent_Click" Text="Create Student" runat="server"/>
                    </div>
                </div>
            </div>            
        </div>
    </div>
</asp:Content>
  


