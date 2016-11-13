<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="StudentPage.aspx.cs" Inherits="Comp229_Assign03.StudentPage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server" >
    <div class="jumbotron">
        <asp:Repeater ID="studentInfo" runat="server" >
            <HeaderTemplate>
                <table>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>First Name:</td>
                    <td><%# Eval("FirstMidName") %></td>
                </tr>
                <tr>
                    <td>Last Name:</td>
                    <td><%# Eval("LastName") %></td>
                </tr>
                <tr>
                    <td>Student ID:</td>
                    <td><%# Eval("StudentID") %></td>
                </tr>
                <tr>
                    <td>Enrollment Date:</td>
                    <td><%# Eval("EnrollmentDate") %></td>
                </tr>  
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
        <asp:Repeater ID="courses" runat="server" >
            <HeaderTemplate>
                <table>
                    <thead>
                        <tr>
                            <th>Courses</th>
                            <th>Course ID</th>
                        </tr>
                    </thead>
            </HeaderTemplate>
            <ItemTemplate>
                <tbody>
                    <tr>
                        <td><%# Eval("Title") %></td>
                        <td><%# Eval("CourseID") %></td>
                    </tr>
                </tbody>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
