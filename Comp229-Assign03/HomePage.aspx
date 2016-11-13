<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="HomePage.aspx.cs" Inherits="Comp229_Assign03.Scripts.HomePage" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server" >
    <div class="container">
        <div class="jubmbotron-fluid">
            <div class="row">
                <img class="col-md-6 center" src="Assets/subrankaLogo.png" />
                <div class="row">
                    <h1 class="display-3 col-md-6"><span class="align-middle">Subranka College</span></h1>
                    <div class="col-md-5">
                        <asp:Repeater ID="studentNames" runat="server">   
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
                                    <%--  <td><asp:ImageButton ID="infoButton" runat="server"
                                                     AlternateText="Info icon"
                                                     ImageUrl="~/Assets/Icons/info_icon.png" 
                                                     OnClick="infoButton_Click"/>
                                    </td>--%>
                                </tr>
                            </tbody>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>                                                 
                    </asp:Repeater>
                    </div>
                </div>
            </div>            
        </div>
    </div>
</asp:Content>
  


