<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="CoursePage.aspx.cs" Inherits="Comp229_Assign03.CoursePage" %>

<%-- Assignemnt 3 - Comp229-007
     Author: Ostap Hamarnyk --%>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server" >
    <div class="jumbotron">
        <div>
            <asp:Repeater ID="courses" runat="server" OnItemCommand="courses_ItemCommand">
                <HeaderTemplate>
                    <table class="table table-striped table-inverse">
                        <thead>
                            <tr>
                                <th>Course ID</th>
                                <th>Title</th>
                                <th>Students Enrolled</th>
                            </tr>
                        </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tbody>
                        <tr>
                            <td class="text-center"><%# Eval("CourseID") %></td>
                            <td class="text-center"><asp:Label ID="title" runat="server" Text='<%# Eval("Title") %>' /></td>
                            <td ><%# Eval("Total") %></td>
                            <td>
                                <asp:TextBox ID="studentIdAdd" CssClass="form-control course" runat="server" Placeholder="Enter student ID to enroll" />
                            </td>
                            <td><asp:ImageButton ID="enrollStudent" ImageUrl="~/Assets/Icons/plus_icon.png" AlternateText="Add Icon" runat="server" /></td>
                        </tr>
                    </tbody>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
            <asp:Repeater ID="enrolledStudents" runat="server" OnItemCommand="enrolledStudents_ItemCommand">
                <HeaderTemplate>
                    <p>Students Enrolled in <%# courseId.Text %></p>
                    <table class="table table-striped">
                        <thead>
                            <tr>
                                <th>Student ID</th>
                                <th>First Name</th>
                                <th>Last Name</th>
                            </tr>
                        </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tbody>
                        <tr>
                            <td><asp:Label ID="studentId" runat="server" Text='<%# Eval("StudentID") %>' /></td>
                            <td><%# Eval("FirstMidName") %></td>
                            <td><%# Eval("LastName") %></td>
                            <td><asp:ImageButton ID="deleteBtn"  ImageUrl="~/Assets/Icons/delete_icon.png" AlternateText="Delete icon" runat="server" /></td>
                        </tr>
                    </tbody>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
            <asp:TextBox ID="courseId" CssClass="form-control" Placeholder="Enter course ID..." runat="server" />
            <asp:Button ID="listStudentsBtn" Text="List Students" CssClass="btn btn-primary" OnClick="listStudentsBtn_Click" runat="server" />
        </div>
        <asp:Label id="error" runat="server" />
    </div>
</asp:Content>
