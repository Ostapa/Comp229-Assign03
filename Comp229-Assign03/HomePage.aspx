<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="HomePage.aspx.cs" Inherits="Comp229_Assign03.Scripts.HomePage" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server" >
    <div class="container-fluid">
            <div class="head">
                <h1 class="display-1"><span class="align-middle">Subranka College</span></h1>
                <p class="lead ">To Learn is to Change</p>
            </div>
        <hr />
            <div class="row">
                <img class="col-md-6" src="Assets/subrankaLogo.png" />
                <div class="col-md-1 col-sm-1"></div>
                <%-- Add ReGex here --%>    
                     <fieldset class="form-group col-md-5 col-sm-5">
                         <legend class="lead">You can become a student of Subranka:</legend>
                     <div>
                     <label for="txtFirstName">*First Name: </label>
                        <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control" />
                        <small><asp:RequiredFieldValidator ID="firstNameReq" runat="server"
                            ControlToValidate="txtFirstName"
                            ErrorMessage="This field is required"
                            ForeColor="Red" 
                            ValidationGroup="newStudent"
                            Display="Dynamic"/>
                        </small>
                         </div>   
                        <label for="txtLastName">*Last Name: </label>
                        <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control" />
                        <small><asp:RequiredFieldValidator ID="lastNameReq" runat="server"
                            ControlToValidate="txtLastName"
                            ErrorMessage="This field is required"
                            ForeColor="Red" 
                            ValidationGroup="newStudent" /></small><br />
                        <label for="enrollmentDate">*Enrollment Date: </label>
                        <asp:TextBox ID="enrollmentDate" runat="server"
                            CssClass="form-control en-date" Type="Date" />
                        <small><asp:RequiredFieldValidator ID="dateReq" runat="server"
                            ControlToValidate="enrollmentDate"
                            ErrorMessage="This field is required"
                            ForeColor="Red" 
                            ValidationGroup="newStudent" /></small><br />
                        <asp:Button ID="addStudent" CssClass="btn btn-primary" ValidationGroup="newStudent" OnClick="addStudent_Click" Text="Create Student" runat="server"/> 
                        &nbsp;<small class="text-muted">Fields marked with * are required</small>
                         </fieldset>
            </div>
            <div class="row">
                <h1 class="display-2">Here is a list of Subranka College's students: </h1>
                <p class="lead">You can find more informatoin about the studetn by pressing <img src="Assets/Icons/i_icon.png" alt="Info icon" /></p>
                <hr />
            </div>
            <div class="row">
                    <!--<div class="col-md-3 offset-md-3"></div>-->
                    <div class="col-md-12">
                        <asp:Repeater ID="studentNames" runat="server" OnItemCommand="studentNames_ItemCommand">   
                        <HeaderTemplate>
                            <table class="table table-hover table-inverse">
                                <thead>
                                    <tr>
                                        <th class="h2">First Name</th>
                                        <th class="h2">Last Name</th>
                                    </tr>
                                </thead>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tbody>
                                <tr>
                                    <td class="h4"><%# Eval("FirstMidName") %></td>
                                    <td class="h4"><%# Eval("LastName") %></td>
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
                    <div class="col-md-3 offset-md-3"></div>
            </div>
    </div>
</asp:Content>
  


