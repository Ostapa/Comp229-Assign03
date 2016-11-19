<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="StudentPage.aspx.cs" Inherits="Comp229_Assign03.StudentPage" %>

<%-- Assignemnt 3 - Comp229-007
     Author: Ostap Hamarnyk --%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server" >
   <div class="container">
        <asp:Panel ID="requestPanel" runat="server">
            <h2 class="display-2">Please enter the student ID:</h2>
            <asp:TextBox ID="requestedId" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:Label ID="error" runat="server" CssClass="has-danger" />
            <asp:Button ID="provideStudentInfo" CssClass="btn btn-primary" Text="Provide Info" runat="server" OnClick="provideStudentInfo_Click" />
        </asp:Panel>
        <asp:Panel ID="studentPanel" runat="server">
            <h1 class="display-3"><asp:Label ID="studentName" runat="server" ></asp:Label></h1>
            <div class="row">
                <div class="col-xs-5">
                    <img src="Assets/profile_image.png" alt="Default profile image" />
                </div>
                <div class="col-xs-2-offset">
                </div>
                    <div class="col-xs-5">  
                        <div>  
                            <asp:Repeater ID="studentInfo" runat="server" >
                            <HeaderTemplate>
                                <table class="table table-striped">
                                    <legend>Personal Info</legend>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td><b>First Name: </b></td>
                                    <td><asp:Label ID="fName" runat="server" Text='<%# Eval("FirstMidName") %>' /></td>
                                </tr>
                                <tr>
                                    <td><b>Last Name:</b> </td>
                                    <td><asp:Label ID="lName" runat="server" Text='<%# Eval("LastName") %>' /></td>
                                </tr>
                                <tr>
                                    <td><b>Student ID: </b></td>
                                    <td><asp:Label ID="studentId" runat="server" Text='<%# Eval("StudentID") %> ' /></td>
                                </tr>
                                <tr>
                                    <td><b>Enrollment Date: </b>&nbsp;</td>
                                    <td><asp:Label ID="enDate" runat="server" Text='<%# Eval("EnDate") %>' /></td>
                                </tr> 
                            </ItemTemplate>
                            <FooterTemplate>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                        </div>
                        <div>
                            <asp:Repeater ID="courseInfo" runat="server">
                            <HeaderTemplate>
                                <table class="table table-striped">
                                    <legend>Courses</legend>
                                    <thead>
                                        <tr>
                                            <th>Course ID: </th>
                                            <th>Title: </th>
                                            <th>Grade: </th>
                                        </tr
                                    </thead>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tbody>
                                    <tr>
                                        <td><%# Eval("CourseID") %></td>
                                        <td><%# Eval("Title") %></td>
                                        <td><%# Eval("Grade") %></td>
                                    </tr>
                                </tbody>
                            </ItemTemplate>
                            <FooterTemplate>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                        </div>
                        <asp:Button CssClass="btn btn-primary" ID="updateBtn" Text="Update" runat="server" OnClick="updateBtn_Click" />
                        <asp:Button CssClass="btn btn-danger" ID="deleteBtn"  Text="Delete" runat="server" OnClick="deleteBtn_Click" />
                    </div>
            </div>
        </asp:Panel>
    </div>
</asp:Content>
