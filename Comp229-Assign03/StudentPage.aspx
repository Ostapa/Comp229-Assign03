<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="StudentPage.aspx.cs" Inherits="Comp229_Assign03.StudentPage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server" >
    <div class="jumbotron">
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
                <tr>
                    <td>Course ID: </td>
                    <td><%# Eval("CourseID") %></td>
                </tr
                <tr>
                    <td>Title</td>
                    <td><%# Eval("Title") %></td>
                </tr>
                </tr>
                    <td>Grade</td
                    <td><%# Eval("Grade") %></td>
                </tr>
                </tbody>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
        <asp:Button CssClass="btn btn-primary" ID="updateBtn" Text="Update" runat="server" OnClick="updateBtn_Click" />
        <asp:Button CssClass="btn btn-danger" ID="deleteBtn"  Text="Delete" runat="server" OnClick="deleteBtn_Click" />
    </div>
</asp:Content>
