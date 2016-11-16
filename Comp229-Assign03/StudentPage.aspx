<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="StudentPage.aspx.cs" Inherits="Comp229_Assign03.StudentPage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server" >
    <div class="jumbotron">
        <h1 class="display-3">Student Name</h1>
        <div class="row">
            <div class="col-xs-5">
                <!--<img src="Assets/profile_image.png" alt="Default profile image" />-->
            </div>
            <div class="col-xs-2-offset"></div>
            
            <div class="col-xs-5">    
                <asp:Repeater ID="studentInfo" runat="server" >
                    <HeaderTemplate>
                        <table>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>First Name: </td>
                            <td><%# Eval("FirstMidName") %></td>
                        </tr>
                        <tr>
                            <td>Last Name: </td>
                            <td><%# Eval("LastName") %></td>
                        </tr>
                        <tr>
                            <td>Student ID: </td>
                            <td><%# Eval("StudentID") %></td>
                        </tr>
                        <tr>
                            <td>Enrollment Date: </td>
                            <td><%# Eval("EnDate") %></td>
                        </tr> 
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
                <asp:Repeater ID="courseInfo" runat="server">
                    <HeaderTemplate>
                        <table>
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
            

        </div>
        <asp:Button CssClass="btn btn-primary" ID="updateBtn" Text="Update" runat="server" OnClick="updateBtn_Click" />
        <asp:Button CssClass="btn btn-danger" ID="deleteBtn"  Text="Delete" runat="server" OnClick="deleteBtn_Click" />
    </div>
</asp:Content>
